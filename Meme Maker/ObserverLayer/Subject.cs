using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using MemeMaker.ObserverLayer.EventArgs;

namespace MemeMaker.ObserverLayer {
    public class Subject<T, EventArgsType> where EventArgsType : ObserverEventArgs {

        private List<object> observers;
        public string HandlerName { get; set; }
        public T WatchableEntity { get; set; }

        public Subject (T watchableEntity, string handlerMethodName) {
            this.observers = new List<object> ();
            this.WatchableEntity = watchableEntity;
            this.HandlerName = handlerMethodName;
        }

        public void AddObserver(object obs) {

            observers.Add (obs);
        }
        public void RemoveObserver(object obs) {
            observers.Remove (obs);
        }

        public void NotifyAll (EventArgsType e) {

            observers.ForEach (o => {
                o.GetType ()
                 .GetMethod (HandlerName)
                 .Invoke (o, new object[] { this, e });
            });
        }

    }
}
