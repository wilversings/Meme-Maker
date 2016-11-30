using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemeMaker.ObserverLayer {
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

        public void NotifyAll (Context context) {
            observers.ForEach (o => o.Notify (context));
        }
        public void NotifyBy (Context context, Func<IObserver, bool> byFn) {
            observers.ForEach (o => {
                if (byFn (o)) {
                    o.Notify (context);
                }
            });
        }

    }
}
