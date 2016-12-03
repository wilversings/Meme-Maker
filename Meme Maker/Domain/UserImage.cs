using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemeMaker.Domain {
    public class UserImage {

        public UserImage (string Path) {
            this.Path = Path;
            this.UpperText = "";
            this.BottomText = "";
            this.Visible = true;
        }

        public string Path { get; set; }
        public string UpperText { get; set; }
        public string BottomText { get; set; }
        public bool Visible { get; set; }

    }
}
