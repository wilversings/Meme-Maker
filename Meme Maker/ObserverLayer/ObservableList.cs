using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MemeMaker.ObserverLayer;
using System.Collections.ObjectModel;

namespace MemeMaker.ObserverLayer {
    public class ObservableList<T> : ObservableCollection<T> {
        public ObservableList (Subject<T> obsSubject) : base() {
            this.ObserverSubject = obsSubject;
        }
        public ObservableList () : base () { }

        private Subject<T> observerSubject;
        public Subject<T> ObserverSubject {
            get {
                return observerSubject;
            }
            set {
                this.observerSubject = value;
                this.CollectionChanged += (sender, eventArgs) => {
                    value.NotifyAll ();
                };
            }
        }

    }
}
