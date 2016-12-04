using MemeMaker.Domain;
using MemeMaker.Meme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemeMaker {
    static class UnifiedViewController {

        public static void HandleDragEnter (object sender, DragEventArgs e, TopBottomMeme memeService) {
            string[] droppedFiles;
            try {
                droppedFiles = e.Data.GetData (DataFormats.FileDrop) as string[];
            }
            catch (System.ArgumentNullException ex) {
                // Handling dragging anything other than files
                return;
            }
            // Checking the file formats

            string file = droppedFiles.FirstOrDefault (f => TopBottomMeme.IsAcceptedFileFormat (f) && !memeService.HasLoadedPath (f));
            if (file == null) {
                return;
            }
            e.Effect = DragDropEffects.Copy;
        }

        public static void HandleDragDrop (object sender, DragEventArgs e, TopBottomMeme memeService) {

            string[] droppedFiles;
            // We passed the DragEnter event, and we can assure that the user dropped
            // files, with the right format
            droppedFiles = e.Data.GetData (DataFormats.FileDrop) as string[];
            droppedFiles = droppedFiles.Where (f => TopBottomMeme.IsAcceptedFileFormat (f) && !memeService.HasLoadedPath (f))
                                       .ToArray ();
            foreach (string path in droppedFiles) {
                memeService.UserImageSubject.WatchableEntity.Add (new UserImage (path));
            }
            memeService.LoadImages ();
        }

    }
}
