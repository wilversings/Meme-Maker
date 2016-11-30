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
        public FileView (Subject obsSubject) {
            InitializeComponent ();
        }

        public void Notify (Context notifyingContext) {

            switch (notifyingContext) {
                case Context.FilePath:
                    throw new NotImplementedException ();
                    break;
            }

        }
    }
}
