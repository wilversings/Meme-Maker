using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemeMaker.ObserverLayer {

    public enum Context {
        FilePath
    }
    public interface IObserver {
        void Notify (Context notifyingContext);
    }

}
