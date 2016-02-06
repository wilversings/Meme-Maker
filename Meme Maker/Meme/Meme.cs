using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meme_Maker.Meme {

    class TopBottomMeme {

        // Image related fields
        protected Bitmap image;
        protected string filePath;

        // Top/Bottom text related fields
        protected string bottomText;
        protected string topText;

        // Style/Font related fields
        protected Font font;
        protected SolidBrush brush;

        protected const int textToImageRatio = 4;
        protected const int textMargin = 10;

        private void setDefault () {
            font = new Font ("Arial", 30);
            brush = new SolidBrush (Color.Black);
        }

        public TopBottomMeme () {
            setDefault ();
            image = null;
        }

        // Some useless constructors
        /*public Meme (Bitmap image) {
            setDefault ();
            this.image = image;
            this.filePath = null;
        }

        public Meme (Bitmap image, string bottomText, string upperText) {
            setDefault ();
            this.image = image;
            this.bottomText = bottomText;
            this.upperText = upperText;
            this.filePath = null;
        }

        public Meme (string filePath) {
            setDefault ();
            this.image = (Bitmap)Image.FromFile (filePath);
            this.filePath = filePath;
        }

        public Meme (string filePath, string bottomText, string upperText) {
            setDefault ();
            this.image = (Bitmap)Image.FromFile (filePath);
            this.bottomText = bottomText;
            this.upperText = upperText;
            this.filePath = filePath;
        }*/

        public string UpperText
        {
            set
            {
                this.topText = value;
            }
            get
            {
                return this.topText;
            }
        }
        public string BottomText
        {
            set
            {
                this.bottomText = value;
            }
            get
            {
                return this.bottomText;
            }
        }
        public Font Font
        {
            set
            {
                font = value;
            }
            get
            {
                return font;
            }
        }
        public string FilePath
        {
            set
            {
                filePath = value;
                image = null;
                image = (Bitmap)Image.FromFile (value);
            }
            get
            {
                return filePath;
            }
        }
        public Image Image
        {
            get
            {
                return image;
            }
        }
        public SolidBrush Brush
        {
            set
            {
                brush = value;
            }
            get
            {
                return brush;
            }
        }

        public virtual Bitmap createMeme () {

            if (image == null)
                return null;

            Bitmap clone = (Bitmap)image.Clone ();

            StringFormat format = new StringFormat ();
            format.LineAlignment = StringAlignment.Center;
            format.Alignment = StringAlignment.Center;

            var topRect = new Rectangle (0, textMargin, image.Width, image.Height / textToImageRatio);
            var bottomRect = new Rectangle (0, (textToImageRatio - 1) * image.Height / textToImageRatio - textMargin, image.Width, image.Height / textToImageRatio);

            using (Graphics gfx = Graphics.FromImage (clone)) {
                gfx.DrawString (topText, font, brush, topRect, format);
                gfx.DrawString (bottomText, font, brush, bottomRect, format);
            }

            return clone;

        }

    }
}
