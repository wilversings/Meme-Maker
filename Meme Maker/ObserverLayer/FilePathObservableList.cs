using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MemeMaker.ObserverLayer;

namespace MemeMaker.ObserverLayer {
    class ObservableList<T> : List<T> {

        protected Subject obsSubject;
        protected Context notifyingContext;

        public ObservableList(Subject obsSubject, Context notifyingContext) : base() {
            this.obsSubject = obsSubject;
            this.notifyingContext = notifyingContext;
        }

        public new void Add (T item) {
            base.Add (item);
            obsSubject.NotifyAll(this.notifyingContext);
        }

        public new void Clear () {
            base.Clear ();
            obsSubject.NotifyAll (this.notifyingContext);
        }

        public new bool Remove (T item) {
            bool ans = base.Remove (item);
            obsSubject.NotifyAll (this.notifyingContext);
            return ans;
        }
    }
}
