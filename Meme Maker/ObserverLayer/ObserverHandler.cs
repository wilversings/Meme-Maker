﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemeMaker.ObserverLayer {
    class ObserverHandler : System.Attribute {

        string SubjectName { get; set; }
        public ObserverHandler (string subjectName) {
            this.SubjectName = subjectName;
        }

    }
}
