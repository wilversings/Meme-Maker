using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemeMaker.ObserverLayer.EventArgs {
    public class SelectionChangeEventArgs : ObserverEventArgs {

        public int OldIndex { get; set; }
        public int NewIndex { get; set; }
        public string NewPath { get; set; }

    }
}
