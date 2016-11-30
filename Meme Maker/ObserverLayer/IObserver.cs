using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meme_Maker.ObserverLayer {

    public enum Context {
        FilePath
    }
    public interface IObserver {
        void notify (Context notifyingContext);
    }

}
