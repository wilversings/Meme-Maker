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

namespace MemeMaker.Meme {
    public partial class FileView : Form, IObserver {

        private TopBottomMeme MemeService { get; set; }

        private int selectedMenuIndex;
        private readonly ContextMenuStrip contextMenu;

        public FileView (TopBottomMeme memeService) {
            InitializeComponent ();

            // Registering component to Subject Containers
            memeService.UserImageSubject.AddObserver (this);
            memeService.SelectedUserImageSubject.AddObserver (this);

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
                    this.MemeService.LoadImages ();
                    break;
            }

        }

        public void Notify <WatchableType> (Subject<WatchableType> sender) where WatchableType : new() {

            if (MemeService.UserImageList.Count > 1) {
                this.Show ();
                this.fileList.Items.Clear ();
                foreach (UserImage userImage in MemeService.UserImageList) {
                    this.fileList.Items.Add (userImage.Path);
                }
            }
            else {
                this.Hide ();
            }

        }

        private void fileList_MouseDown (object sender, MouseEventArgs e) {
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
            MemeService.SelectedUserImageSubject.NotifyAll ();
        }
    }
}
