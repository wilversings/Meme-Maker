using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using MemeMaker.ObserverLayer.EventArgs;

namespace MemeMaker.ObserverLayer {
    public class Subject<T> {

        private List<IObserver> observers;
        public string Name { get; set; }
        public T WatchableEntity { get; set; }

        public Subject (T watchableEntity, string name) {
            this.observers = new List<IObserver> ();
            this.WatchableEntity = watchableEntity;
            this.Name = name;
        }

        public void AddObserver(IObserver obs) {

            observers.Add (obs);
        }
        public void RemoveObserver(IObserver obs) {
            observers.Remove (obs);
        }

        public void NotifyAll () {
            observers.ForEach (o => o.Notify <T>(this));
        }
        public void NotifyBy (Func<IObserver, bool> byFn) {
            observers.ForEach (o => {
                if (byFn (o)) {
                    o.Notify <T>(this);
                }
            });
        }

    }
}
