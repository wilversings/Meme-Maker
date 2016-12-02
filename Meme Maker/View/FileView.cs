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

namespace MemeMaker.Meme {
    public partial class FileView : Form, IObserver {

        private Subject<string> obsSubject;

        private TopBottomMeme MemeService { get; set; }

        private int selectedMenuIndex;
        private readonly ContextMenuStrip contextMenu;

        public FileView (Subject<string> obsSubject, TopBottomMeme memeService) {
            InitializeComponent ();
            obsSubject.AddObserver (this);
            this.MemeService = memeService;
            this.obsSubject = obsSubject;
            foreach(string path in MemeService.PathList) {
                this.fileList.Items.Add (path);
            }
            contextMenu = new ContextMenuStrip ();
            contextMenu.Items.Add ("Remove");
            contextMenu.ItemClicked += ContextMenuItemClicked;
        }

        private void ContextMenuItemClicked (object sender, ToolStripItemClickedEventArgs e) {

            switch (e.ClickedItem.Text) {
                case "Remove":
                    MemeService.PathList.RemoveAt (selectedMenuIndex);
                    this.MemeService.LoadImages ();
                    break;
            }

        }

        public void Notify () {

            if (MemeService.PathList.Count > 1) {
                this.Show ();
                this.fileList.Items.Clear ();
                foreach (string path in MemeService.PathList) {
                    this.fileList.Items.Add (path);
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
    }
}
