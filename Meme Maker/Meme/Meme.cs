using MemeMaker.ObserverLayer;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MemeMaker.ObserverLayer;

namespace MemeMaker.Meme {

    class TopBottomMeme : IObserver {

        private Subject obsSubject;

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

        public TopBottomMeme (Subject obsSubject) {
            this.SetDefaultStyle ();
            this.Image = null;
            this.obsSubject = obsSubject;
        }
       
        public void AppendFilePath (string filePath) {
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

        public void Notify (Context notifyingContext) {
            throw new NotImplementedException ();
        }

        private static HashSet<string> acceptedFileFormats = new HashSet<string> (new string[]{
            "jpg", "jpeg", "jpe", "jfif", "png"
        });
        public static bool IsAcceptedFileFormat (string path) {
            return acceptedFileFormats.Contains (path.Split ('\\').Last ().Split ('.')[1]);
        }
    }
}
