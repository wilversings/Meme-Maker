using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Meme_Maker.UIComponents {
    class PanZoomPictureBox : PictureBox {

        float scale = 0.05F;
        int targetX = 0;
        int targetY = 0;

        public PanZoomPictureBox () : base() {

            MouseWheel += PanZoomMouseWheel;

            Paint += PanZoomPaint;

        }

        private void PanZoomMouseWheel (object sender, MouseEventArgs e) {

            float oldScale = this.scale;
            if (e.Delta > 0) {
                this.scale += 0.1F;
            } else if (e.Delta < 0) {
                this.scale -= 0.1F;
            }

            int oldX = (int)(e.X / oldScale);
            int oldY = (int)(e.Y / oldScale);

            int newX = (int)(e.X / this.scale);
            int newY = (int)(e.Y / this.scale);

            this.targetX = newX - oldX + this.targetX;
            this.targetY = newY - oldY + this.targetY;
            
            this.Invalidate ();
        }

        private void PanZoomPaint (object sender, PaintEventArgs e) {
            e.Graphics.ScaleTransform (this.scale, this.scale);
            if (Image != null)
            e.Graphics.DrawImage (Image, this.targetX, this.targetY);
        }

    }
}