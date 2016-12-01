using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MemeMaker.Meme;
using System.Drawing.Text;
using MemeMaker.ObserverLayer;

namespace MemeMaker {
    public partial class MemeMaker : Form, IObserver {

        private Meme.TopBottomMeme mainMeme;
        private Subject<string> obsSubject;

        public MemeMaker (Subject<string> obsSubject) {

            InitializeComponent ();

            this.obsSubject = obsSubject;
            obsSubject.AddObserver (this);
            mainMeme = new Meme.TopBottomMeme (obsSubject);

            using (var fonts = new InstalledFontCollection ()) {
                foreach (var font in fonts.Families) {
                    fontComboBox.Items.Add (font.Name);
                }
            }

        }

        private void UpdateMeme () {
            mainMeme.UpperText = upperText.Text;
            mainMeme.BottomText = bottomText.Text;

            meme.Image = mainMeme.CreateMeme ();
        }
        private void UpdateMeme (object sender, EventArgs e) {
            UpdateMeme ();
        }

        private void BrowseForImageClick (object sender, EventArgs e) { 
            if (imageOpenDialog.ShowDialog () == DialogResult.OK) {
                mainMeme.FilePath = imageOpenDialog.FileName;
                meme.Image = mainMeme.CreateMeme ();
            }
        }

        private void UpdateTextStyle (object sender, EventArgs e) {
            var newFont = new Font (
                fontComboBox.SelectedItem as string,
                (int)fontSizeNumeric.Value,
                boldCheckBox.Checked ? FontStyle.Bold : FontStyle.Regular |
                (italicCheckBox.Checked ? FontStyle.Italic : FontStyle.Regular)
            );

            mainMeme.Font = newFont;
            meme.Image = mainMeme.CreateMeme ();
        }

        private void SaveImage (object sender, EventArgs e) {
            if (meme.Image == null) {
                MessageBox.Show ("There is no image to be saved!", "Save error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            
            if (imageSaveDialog.ShowDialog () == DialogResult.OK)
                meme.Image.Save (imageSaveDialog.FileName);
        }

        private void ChangeColor (object sender, EventArgs e) {
            textColorDialog.ShowDialog ();
            mainMeme.Brush = new SolidBrush (textColorDialog.Color);
            meme.Image = mainMeme.CreateMeme ();
        }

        private void MemeMakerKeyDown (object sender, KeyEventArgs e) {

            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.S) {
                SaveImage (null, null);
            }

        }

        private void MemeMakerDragDrop (object sender, DragEventArgs e) {
            string[] droppedFiles;
            // We passed the DragEnter event, and we can assure that the user dropped
            // files, with the right format
            droppedFiles = e.Data.GetData (DataFormats.FileDrop) as string[];
            mainMeme.FilePath = droppedFiles.First ();
            meme.Image = mainMeme.CreateMeme ();

        }
        private void MemeMakerDragEnter (object sender, DragEventArgs e) {
            string[] droppedFiles;
            try {
                droppedFiles = e.Data.GetData (DataFormats.FileDrop) as string[];
            }
            catch (System.ArgumentNullException ex) {
                // Handling dragging anything other than files
                return;
            }
            // Checking the file formats
            foreach (string path in droppedFiles) {
                if (!TopBottomMeme.IsAcceptedFileFormat(path)) {
                    return;
                }
            }
            e.Effect = DragDropEffects.Copy;
        }

        public void Notify () {


        }
    }
}
