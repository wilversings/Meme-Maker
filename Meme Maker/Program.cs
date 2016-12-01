using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MemeMaker.ObserverLayer;

namespace MemeMaker {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main () {

            ObservableList<string> pathList = new ObservableList<string> ();
            Subject<string> obsSubject = new Subject<string> (pathList);
            pathList.ObserverSubject = obsSubject;

            Application.EnableVisualStyles ();
            Application.SetCompatibleTextRenderingDefault (false);
            Application.Run (new MemeMaker (obsSubject));
        }
    }
}
