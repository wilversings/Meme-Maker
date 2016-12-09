using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemeMaker.Domain {
    public class UserImage {

        public UserImage () {
            this.Path = "";
            this.UpperText = "";
            this.BottomText = "";
            this.Visible = true;
            this.SetDefaultStyle ();
        }
        public UserImage (string Path) {
            this.Path = Path;
            this.UpperText = "";
            this.BottomText = "";
            this.Visible = true;
            this.SetDefaultStyle ();
        }

        public string Path { get; set; }
        public string UpperText { get; set; }
        public string BottomText { get; set; }
        public bool Visible { get; set; }
        public Bitmap CleanImage { get; set; }
        public Bitmap DirtyImage { get; set; }
        public Font Font { get; set; }
        public SolidBrush Brush { get; set; }

        private void SetDefaultStyle () {
            Font = new Font ("Arial", 30);
            Brush = new SolidBrush (Color.Black);
        }

    }
}
