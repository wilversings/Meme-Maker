using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meme_Maker.ObserverLayer {
    public class Subject {

        private List<IObserver> observers;

        public Subject () {
            this.observers = new List<IObserver> ();
        }
        public void AddObserver(IObserver obs) {
            observers.Add (obs);
        }
        public void RemoveObserver(IObserver obs) {
            observers.Remove (obs);
        }

        public void notify (Context context) {
            observers.ForEach (o => o.notify (context));
        }

    }
}
