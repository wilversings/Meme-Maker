using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MemeMaker.ObserverLayer;

namespace MemeMaker.ObserverLayer {
    class ObservableList<T> : ICollection<T> {

        protected List<T> filePaths;
        protected Subject obsSubject;
        protected Context notifyingContext;

        public ObservableList(Subject obsSubject, Context notifyingContext) {
            filePaths = new List<T> ();
            this.obsSubject = obsSubject;
            this.notifyingContext = notifyingContext;
        }

        public int Count {
            get {
                return filePaths.Count;
            }
        }

        public bool IsReadOnly {
            get {
                return false;
            }
        }

        public void Add (T item) {
            filePaths.Add (item);
            obsSubject.NotifyAll(this.notifyingContext);
        }

        public void Clear () {
            filePaths.Clear ();
            obsSubject.NotifyAll (this.notifyingContext);
        }

        public bool Contains (T item) {
            return filePaths.Contains (item);
        }

        public void CopyTo (T[] array, int arrayIndex) {
            filePaths.CopyTo (array, arrayIndex);
        }

        public IEnumerator<T> GetEnumerator () {
            return filePaths.GetEnumerator ();
        }

        public bool Remove (T item) {
            bool ans = filePaths.Remove (item);
            obsSubject.NotifyAll (this.notifyingContext);
            return ans;
        }

        IEnumerator IEnumerable.GetEnumerator () {
            return filePaths.GetEnumerator ();
        }
    }
}
