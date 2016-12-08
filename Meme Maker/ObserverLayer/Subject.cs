using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using MemeMaker.ObserverLayer.EventArgs;

namespace MemeMaker.ObserverLayer {
    public class Subject<T, EventArgsType> {

        public delegate void handler (Subject<T, EventArgsType> sender, EventArgsType e);
        public event handler Handlers;
        public T WatchableEntity { get; set; }

        public Subject (T watchableEntity) {
            this.WatchableEntity = watchableEntity;
        }

        public void NotifyAll (EventArgsType e) {
            Handlers (this, e);
        }

    }
}
