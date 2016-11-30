using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MemeMaker.ObserverLayer;
using System.Collections.ObjectModel;

namespace MemeMaker.ObserverLayer {
    class ObservableList<T> : ObservableCollection<T> {
        public ObservableList (Context notifyingContext, Subject obsSubject) : base() {
            this.CollectionChanged += (sender, eventArgs) => {
                obsSubject.NotifyAll (notifyingContext);
            };
        }
    }
}
