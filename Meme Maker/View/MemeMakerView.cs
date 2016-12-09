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
    public partial class MemeMakerView : Form {

        private MemeService MemeService { get; set; }
        public FileView FileView { get; set; }
        private int selectedPath;

        public MemeMakerView (MemeService memeService) {

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
            this.FileView.Show ();

        }
        private async Task UpdateMemeAsync () {
            MemeService.UserImageList[this.selectedPath].UpperText = upperText.Text;
            MemeService.UserImageList[this.selectedPath].BottomText = bottomText.Text;

            Bitmap img = await MemeService.CreateMemeAsync ();
            Console.WriteLine (img);
            meme.Image = img;
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

            UserImage selectedIm = MemeService.UserImageList[e.NewIndex];

            object itemToSelect = null;
            foreach (object fontComboBoxItem in fontComboBox.Items) {
                if (fontComboBoxItem as string == selectedIm.Font.Name) {
                    itemToSelect = fontComboBoxItem;
                }
            }

            suppressUpdateTextStyle = suppressBoxTextChanged = true;
            fontComboBox.SelectedItem = itemToSelect;
            upperText.Text = selectedIm.UpperText;
            bottomText.Text = selectedIm.BottomText;
            fontSizeNumeric.Value = (decimal)selectedIm.Font.Size;
            boldCheckBox.Checked = selectedIm.Font.Bold;
            italicCheckBox.Checked = selectedIm.Font.Italic;
            suppressUpdateTextStyle = suppressBoxTextChanged = false;

        }

        bool suppressUpdateTextStyle = false;
        private void UpdateTextStyle (object sender, EventArgs e) {
            if (suppressUpdateTextStyle)
                return;

            var newFont = new Font (
                fontComboBox.SelectedItem as string,
                (int)fontSizeNumeric.Value,
                boldCheckBox.Checked ? FontStyle.Bold : FontStyle.Regular |
                (italicCheckBox.Checked ? FontStyle.Italic : FontStyle.Regular)
            );
                
            MemeService.UserImageList[this.selectedPath].Font = newFont;
        }

        bool suppressBoxTextChanged = false;
        private void BoxTextChanged (object sender, EventArgs e) {
            if (suppressBoxTextChanged)
                return;

            UserImage selectedIm = MemeService.UserImageList[this.selectedPath];

            selectedIm.BottomText = bottomText.Text;
            selectedIm.UpperText = upperText.Text;

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
            MemeService.UserImageList[this.selectedPath].Brush = new SolidBrush (textColorDialog.Color);
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

        public async void FileListChanged (object sender, ObserverEventArgs e) {
             await this.UpdateMemeAsync ();
        }

        private async void MakeMemeButtonClick (object sender, EventArgs e) {
            await this.UpdateMemeAsync ();
        }

        
    }
}
