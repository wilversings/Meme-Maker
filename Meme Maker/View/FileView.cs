using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MemeMaker.ObserverLayer;
using MemeMaker.Domain;
using MemeMaker.ObserverLayer.EventArgs;

namespace MemeMaker.Meme {
    public partial class FileView : Form {

        private MemeService MemeService { get; set; }

        private int selectedMenuIndex;
        private readonly ContextMenuStrip contextMenu;

        public FileView (MemeService memeService) {
            InitializeComponent ();

            // Registering component to Subject Containers
            memeService.UserImageSubject.Handlers += FileListChanged;
            memeService.SelectedUserImageSubject.Handlers += FileListSelectionChanged;

            this.MemeService = memeService;
            foreach(UserImage userImage in MemeService.UserImageList) {
                this.fileList.Items.Add (userImage.Path);
            }
            contextMenu = new ContextMenuStrip ();
            contextMenu.Items.Add ("Remove");
            contextMenu.ItemClicked += ContextMenuItemClicked;
        }

        private void ContextMenuItemClicked (object sender, ToolStripItemClickedEventArgs e) {

            switch (e.ClickedItem.Text) {
                case "Remove":
                    MemeService.UserImageList.RemoveAt (selectedMenuIndex);
                    MemeService.ClearUnusedImages ();
                    MemeService.UserImageSubject.NotifyAll (null);
                    break;
            }

        }

        public void FileListSelectionChanged (object sender, SelectionChangeEventArgs e) {

        }

        public void FileListChanged (object sender, ObserverEventArgs e) {
            if (MemeService.UserImageList.Count > 1) {
                this.fileList.Items.Clear ();
                foreach (UserImage userImage in MemeService.UserImageList) {
                    this.fileList.Items.Add (userImage.Path);
                }
                this.Show ();
            } 
            else {
                this.Hide ();
            }

        }
        private void FileListMouseDown (object sender, MouseEventArgs e) {
            if (e.Button != MouseButtons.Right)
                return;

            var index = fileList.IndexFromPoint (e.Location);
            if (index != ListBox.NoMatches) {
                this.selectedMenuIndex = index;
                contextMenu.Show (Cursor.Position);
                contextMenu.Visible = true;
            }

        }

        private void ItemSelectionChanged (object sender, EventArgs e) {
            MemeService.SelectedUserImageSubject.WatchableEntity = this.fileList.SelectedIndex;
            MemeService.SelectedUserImageSubject.NotifyAll (new ObserverLayer.EventArgs.SelectionChangeEventArgs {
                NewIndex = fileList.SelectedIndex,
                NewPath = fileList.SelectedItem.ToString()
            });
        }
    }
}
