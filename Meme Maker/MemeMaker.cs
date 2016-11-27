using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Meme_Maker.Meme;
using System.Drawing.Text;

namespace Meme_Maker {
    public partial class MemeMaker : Form {

        private Meme.TopBottomMeme mainMeme;

        public MemeMaker () {

            InitializeComponent ();
            mainMeme = new Meme.TopBottomMeme ();

            using (var fonts = new InstalledFontCollection ()) {
                foreach (var font in fonts.Families) {
                    fontComboBox.Items.Add (font.Name);
                }
            }

        }

        private void updateMeme () {
            mainMeme.UpperText = upperText.Text;
            mainMeme.BottomText = bottomText.Text;

            meme.Image = mainMeme.createMeme ();
        }
        private void updateMeme (object sender, EventArgs e) {
            updateMeme ();
        }

        private void button1_Click (object sender, EventArgs e) { 
            if (imageOpenDialog.ShowDialog () == DialogResult.OK) {
                mainMeme.FilePath = imageOpenDialog.FileName;
                meme.Image = mainMeme.createMeme ();
            }
        }

        private void updateTextStyle (object sender, EventArgs e) {
            var newFont = new Font (
                (string)fontComboBox.SelectedItem,
                (int)fontSizeNumeric.Value,
                boldCheckBox.Checked ? FontStyle.Bold : FontStyle.Regular |
                (italicCheckBox.Checked ? FontStyle.Italic : FontStyle.Regular)
            );

            mainMeme.Font = newFont;
            meme.Image = mainMeme.createMeme ();
        }

        private void saveImage (object sender, EventArgs e) {
            if (meme.Image == null) {
                MessageBox.Show ("There is no image to be saved!", "Save error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            
            if (imageSaveDialog.ShowDialog () == DialogResult.OK)
                meme.Image.Save (imageSaveDialog.FileName);
        }

        private void changeColor (object sender, EventArgs e) {
            textColorDialog.ShowDialog ();
            mainMeme.Brush = new SolidBrush (textColorDialog.Color);
            meme.Image = mainMeme.createMeme ();
        }

        private void MemeMaker_KeyDown (object sender, KeyEventArgs e) {

            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.S) {
                saveImage (null, null);
            }

        }
    }
}
