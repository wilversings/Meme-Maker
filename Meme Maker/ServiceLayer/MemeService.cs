using MemeMaker.ObserverLayer;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MemeMaker.Domain;
using MemeMaker.ObserverLayer.EventArgs;

namespace MemeMaker.Meme {

    public class MemeService {

        public Subject<List<UserImage>, ObserverEventArgs> UserImageSubject { get; private set; }
        public Subject<int, SelectionChangeEventArgs> SelectedUserImageSubject { get; private set; }

        // Used for fast searching if the path is new or it was already loaded
        private Dictionary<string, Bitmap> loadedImages;

        public MemeService () {
            loadedImages = new Dictionary<string, Bitmap> ();
            this.SetDefaultStyle ();
            this.Image = null;
            this.UserImageSubject = new Subject<List<UserImage>, ObserverEventArgs> (new List<UserImage>());
            this.SelectedUserImageSubject = new Subject<int, SelectionChangeEventArgs> (new int());
        }
        // Image related fields
        public Image Image { get; private set; }

        // Style/Font related fields
        public Font Font { get; set; }
        public SolidBrush Brush { get; set; }

        protected const int textToImageRatio = 4;
        protected const int textMargin = 10;

        public IList<UserImage> UserImageList {
            get {
                return UserImageSubject.WatchableEntity;
            }
        }

        private void SetDefaultStyle () {
            Font = new Font ("Arial", 30);
            Brush = new SolidBrush (Color.Black);
        }

        public bool HasLoadedPath (string path) {
            return loadedImages.ContainsKey (path);
        }

        protected virtual void DrawOn (UserImage im) {

            Bitmap image = im.CleanImage.Clone () as Bitmap;

            StringFormat format = new StringFormat ();
            format.LineAlignment = StringAlignment.Center;
            format.Alignment = StringAlignment.Center;

            var topRect = new Rectangle (0, textMargin, image.Width, image.Height / textToImageRatio);
            var bottomRect = new Rectangle (0, (textToImageRatio - 1) * image.Height / textToImageRatio - textMargin, image.Width, image.Height / textToImageRatio);

            using (Graphics gfx = Graphics.FromImage (image)) {
                gfx.DrawString (im.UpperText, Font, Brush, topRect, format);
                gfx.DrawString (im.BottomText, Font, Brush, bottomRect, format);
            }

            im.DirtyImage = image;

        }

        public virtual Bitmap CreateMeme () {

            int totalHeight = 0, maxWidth = 0;

            foreach (UserImage im in this.UserImageList) {
                this.DrawOn (im);
            }

            // Computing the total height and width of the final image
            foreach (Bitmap image in loadedImages.Values) {
                totalHeight += image.Height;
                maxWidth = Math.Max (maxWidth, image.Width);
            }
            Bitmap finalImage = new Bitmap (maxWidth, totalHeight);
            using (Graphics gr = Graphics.FromImage (finalImage)) {
                int partialSumHeight = 0;
                foreach (UserImage image in this.UserImageList) {
                    gr.DrawImage (image.DirtyImage, 0, partialSumHeight);
                    partialSumHeight += image.DirtyImage.Height;
                }
            }
            this.Image = finalImage;
            return finalImage;

        }
        public virtual async Task<Bitmap> CreateMemeAsync() {
            return await Task.Run(() => CreateMeme ());
        }

        public void LoadImages () {

            foreach (UserImage possibleNewImage in UserImageSubject.WatchableEntity) {
                if (!loadedImages.ContainsKey (possibleNewImage.Path)) {
                    loadedImages[possibleNewImage.Path] = Image.FromFile (possibleNewImage.Path) as Bitmap;
                }
                possibleNewImage.CleanImage = loadedImages[possibleNewImage.Path];
            }

            foreach (string oldPath in loadedImages.Keys.ToList()) {
                if (!UserImageSubject.WatchableEntity.Select(u => u.Path).Contains(oldPath)) {
                    loadedImages.Remove (oldPath);
                }
            }

            this.UserImageSubject.NotifyAll (new ObserverEventArgs ());

        }

        private static HashSet<string> acceptedFileFormats = new HashSet<string> (new string[]{
            "jpg", "jpeg", "jpe", "jfif", "png"
        });
        public static bool IsAcceptedFileFormat (string path) {
            return acceptedFileFormats.Contains (path.Split ('\\').Last ().Split ('.')[1]);
        }
    }
}
