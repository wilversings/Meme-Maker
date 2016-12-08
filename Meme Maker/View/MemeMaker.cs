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
using MemeMaker.Domain;
using MemeMaker.ObserverLayer.EventArgs;

namespace MemeMaker {
    public partial class MemeMaker : Form {

        private MemeService MemeService { get; set; }
        public FileView FileView { get; set; }
        private int selectedPath;

        private bool suppressUpdateMeme = false;

        public MemeMaker (MemeService memeService) {

            InitializeComponent ();

            // Registering component to Subject Containers
            memeService.UserImageSubject.Handlers += FileListChanged;
            memeService.SelectedUserImageSubject.Handlers += FileListSelectionChanged;

            this.MemeService = memeService;

            using (var fonts = new InstalledFontCollection ()) {
                foreach (var font in fonts.Families) {
                    fontComboBox.Items.Add (font.Name);
                }
            }

            this.FileView = new FileView (MemeService);

        }

        private void UpdateMeme () {
            MemeService.UserImageList[this.selectedPath].UpperText = upperText.Text;
            MemeService.UserImageList[this.selectedPath].BottomText = bottomText.Text;

            meme.Image = MemeService.CreateMeme ();
        }
        private void UpdateMeme (object sender, EventArgs e) {
            if (suppressUpdateMeme)
                return;
            UpdateMeme ();
        }

        private void BrowseForImageClick (object sender, EventArgs e) { 
            if (imageOpenDialog.ShowDialog () == DialogResult.OK) {
                MemeService.UserImageList.Add (new UserImage (imageOpenDialog.FileName));
                MemeService.LoadImages ();
                meme.Image = MemeService.CreateMeme ();
            }
        }

        public void FileListSelectionChanged (object sender, SelectionChangeEventArgs e) {
            this.selectedPath = e.NewIndex;
            suppressUpdateMeme = true;
            upperText.Text = MemeService.UserImageList[e.NewIndex].UpperText;
            bottomText.Text = MemeService.UserImageList[e.NewIndex].BottomText;
            suppressUpdateMeme = false;
        }

        private void UpdateTextStyle (object sender, EventArgs e) {
            var newFont = new Font (
                fontComboBox.SelectedItem as string,
                (int)fontSizeNumeric.Value,
                boldCheckBox.Checked ? FontStyle.Bold : FontStyle.Regular |
                (italicCheckBox.Checked ? FontStyle.Italic : FontStyle.Regular)
            );
                
            MemeService.Font = newFont;
            meme.Image = MemeService.CreateMeme ();
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
            MemeService.Brush = new SolidBrush (textColorDialog.Color);
            meme.Image = MemeService.CreateMeme ();
        }

        private void MemeMakerKeyDown (object sender, KeyEventArgs e) {

            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.S) {
                SaveImage (sender, e);
            }

        }

        private void MemeMakerDragDrop (object sender, DragEventArgs e) {
            UnifiedViewController.HandleDragDrop (sender, e, MemeService);
        }
        private void MemeMakerDragEnter (object sender, DragEventArgs e) {
            UnifiedViewController.HandleDragEnter (sender, e, MemeService);
        }

        public void FileListChanged (object sender, ObserverEventArgs e) {
             this.UpdateMeme ();
        }
    }
}
