namespace MemeMaker.Meme {
    partial class FileView {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose (bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose ();
            }
            base.Dispose (disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent () {
            this.fileList = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // fileList
            // 
            this.fileList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.fileList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fileList.FormattingEnabled = true;
            this.fileList.Location = new System.Drawing.Point(0, 0);
            this.fileList.Name = "fileList";
            this.fileList.Size = new System.Drawing.Size(149, 404);
            this.fileList.TabIndex = 1;
            this.fileList.SelectedIndexChanged += new System.EventHandler(this.ItemSelectionChanged);
            this.fileList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FileListMouseDown);
            // 
            // FileView
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(149, 404);
            this.ControlBox = false;
            this.Controls.Add(this.fileList);
            this.Name = "FileView";
            this.Text = "FileView";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox fileList;
    }
}