using MemeMaker.ObserverLayer;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MemeMaker.ObserverLayer;

namespace MemeMaker.Meme {

    public class TopBottomMeme {

        private Subject<string> obsSubject;
        // Used for fast searching if the path is new or it was already loaded
        private Dictionary<string, Bitmap> loadedImages;

        public TopBottomMeme (Subject<string> obsSubject) {
            loadedImages = new Dictionary<string, Bitmap> ();
            this.SetDefaultStyle ();
            this.Image = null;
            this.obsSubject = obsSubject;
        }
        // Image related fields
        public Image Image { get; private set; }
        protected string filePath;

        public string UpperText { get; set; }
        public string BottomText { get; set; }

        // Style/Font related fields
        public Font Font { get; set; }
        public SolidBrush Brush { get; set; }

        protected const int textToImageRatio = 4;
        protected const int textMargin = 10;

        private void SetDefaultStyle () {
            Font = new Font ("Arial", 30);
            Brush = new SolidBrush (Color.Black);
        }

        public string FilePath {
            set {
                filePath = value;
                Image = null;
                Image = Image.FromFile (value) as Bitmap;
            }
            get {
                return filePath;
            }
        }

        public bool HasLoadedPath (string path) {
            return loadedImages.ContainsKey (path);
        }

        public virtual Bitmap CreateMeme () {

            if (Image == null)
                return null;

            Bitmap clone = Image.Clone () as Bitmap;

            StringFormat format = new StringFormat ();
            format.LineAlignment = StringAlignment.Center;
            format.Alignment = StringAlignment.Center;

            var topRect = new Rectangle (0, textMargin, Image.Width, Image.Height / textToImageRatio);
            var bottomRect = new Rectangle (0, (textToImageRatio - 1) * Image.Height / textToImageRatio - textMargin, Image.Width, Image.Height / textToImageRatio);

            using (Graphics gfx = Graphics.FromImage (clone)) {
                gfx.DrawString (UpperText, Font, Brush, topRect, format);
                gfx.DrawString (BottomText, Font, Brush, bottomRect, format);
            }

            return clone;

        }

        public void LoadImages () {

            foreach (string possibleNewPath in obsSubject.PathList) {
                if (!loadedImages.ContainsKey (possibleNewPath)) {
                    loadedImages[possibleNewPath] = Image.FromFile (possibleNewPath) as Bitmap;
                }
            }

            foreach (string oldPath in loadedImages.Keys.ToList()) {
                if (!obsSubject.PathList.Contains(oldPath)) {
                    loadedImages.Remove (oldPath);
                }
            }

            int totalHeight = 0, maxWidth = 0;
            // Computing the total height and width of the final image
            foreach (Bitmap image in loadedImages.Values) {
                totalHeight += image.Height;
                maxWidth = Math.Max (maxWidth, image.Width);
            }
            Bitmap finalImage = new Bitmap (maxWidth, totalHeight);
            using (Graphics gr = Graphics.FromImage (finalImage)) {
                int partialSumHeight = 0;
                foreach (Bitmap image in loadedImages.Values) {
                    gr.DrawImage (image, 0, partialSumHeight);
                    partialSumHeight += image.Height;
                }
            }
            this.Image = finalImage;
            obsSubject.NotifyAll ();

        }

        private static HashSet<string> acceptedFileFormats = new HashSet<string> (new string[]{
            "jpg", "jpeg", "jpe", "jfif", "png"
        });
        public static bool IsAcceptedFileFormat (string path) {
            return acceptedFileFormats.Contains (path.Split ('\\').Last ().Split ('.')[1]);
        }
    }
}
