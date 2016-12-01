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

        public FileView (Subject<string> obsSubject) {
            InitializeComponent ();
            obsSubject.AddObserver (this);
            this.obsSubject = obsSubject;
        }

        public void Notify () {

            

        }
    }
}
