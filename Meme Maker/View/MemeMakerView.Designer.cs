namespace MemeMaker {
    partial class MemeMakerView {
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
            this.components = new System.ComponentModel.Container();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.upperText = new System.Windows.Forms.RichTextBox();
            this.bottomText = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.meme = new MemeMaker.UIComponents.PanZoomPictureBox();
            this.browseButton = new System.Windows.Forms.Button();
            this.imageOpenDialog = new System.Windows.Forms.OpenFileDialog();
            this.fontComboBox = new System.Windows.Forms.ComboBox();
            this.fontSizeNumeric = new System.Windows.Forms.NumericUpDown();
            this.saveAsButton = new System.Windows.Forms.Button();
            this.imageSaveDialog = new System.Windows.Forms.SaveFileDialog();
            this.boldCheckBox = new System.Windows.Forms.CheckBox();
            this.italicCheckBox = new System.Windows.Forms.CheckBox();
            this.textColorDialog = new System.Windows.Forms.ColorDialog();
            this.changeColorButton = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.appendToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.makeMemeButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.meme)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fontSizeNumeric)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // upperText
            // 
            this.upperText.Location = new System.Drawing.Point(12, 92);
            this.upperText.Name = "upperText";
            this.upperText.Size = new System.Drawing.Size(193, 60);
            this.upperText.TabIndex = 0;
            this.upperText.Text = "";
            this.upperText.TextChanged += new System.EventHandler(this.BoxTextChanged);
            // 
            // bottomText
            // 
            this.bottomText.Location = new System.Drawing.Point(212, 92);
            this.bottomText.Name = "bottomText";
            this.bottomText.Size = new System.Drawing.Size(212, 61);
            this.bottomText.TabIndex = 1;
            this.bottomText.Text = "";
            this.bottomText.TextChanged += new System.EventHandler(this.BoxTextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Top text";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(363, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Bottom text";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.meme);
            this.groupBox1.Location = new System.Drawing.Point(12, 262);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(412, 305);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Meme";
            // 
            // meme
            // 
            this.meme.Location = new System.Drawing.Point(8, 19);
            this.meme.Name = "meme";
            this.meme.Size = new System.Drawing.Size(394, 267);
            this.meme.TabIndex = 0;
            this.meme.TabStop = false;
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(12, 190);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(108, 23);
            this.browseButton.TabIndex = 5;
            this.browseButton.Text = "Browse for image...";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.BrowseForImageClick);
            // 
            // imageOpenDialog
            // 
            this.imageOpenDialog.FileName = "openFileDialog1";
            this.imageOpenDialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif;" +
    " *.png\";";
            // 
            // fontComboBox
            // 
            this.fontComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fontComboBox.FormattingEnabled = true;
            this.fontComboBox.Location = new System.Drawing.Point(127, 191);
            this.fontComboBox.Name = "fontComboBox";
            this.fontComboBox.Size = new System.Drawing.Size(133, 21);
            this.fontComboBox.TabIndex = 6;
            this.fontComboBox.SelectedIndexChanged += new System.EventHandler(this.UpdateTextStyle);
            // 
            // fontSizeNumeric
            // 
            this.fontSizeNumeric.Location = new System.Drawing.Point(267, 191);
            this.fontSizeNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.fontSizeNumeric.Name = "fontSizeNumeric";
            this.fontSizeNumeric.Size = new System.Drawing.Size(39, 20);
            this.fontSizeNumeric.TabIndex = 7;
            this.fontSizeNumeric.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.fontSizeNumeric.ValueChanged += new System.EventHandler(this.UpdateTextStyle);
            // 
            // saveAsButton
            // 
            this.saveAsButton.Location = new System.Drawing.Point(348, 219);
            this.saveAsButton.Name = "saveAsButton";
            this.saveAsButton.Size = new System.Drawing.Size(75, 23);
            this.saveAsButton.TabIndex = 8;
            this.saveAsButton.Text = "Save as...";
            this.saveAsButton.UseVisualStyleBackColor = true;
            this.saveAsButton.Click += new System.EventHandler(this.SaveImage);
            // 
            // imageSaveDialog
            // 
            this.imageSaveDialog.Filter = "Bitmap Image (.bmp)|*.bmp|Gif Image (.gif)|*.gif|JPEG Image (.jpeg)|*.jpeg|Png Im" +
    "age (.png)|*.png|Tiff Image (.tiff)|*.tiff|Wmf Image (.wmf)|*.wmf";
            // 
            // boldCheckBox
            // 
            this.boldCheckBox.AutoSize = true;
            this.boldCheckBox.Location = new System.Drawing.Point(312, 192);
            this.boldCheckBox.Name = "boldCheckBox";
            this.boldCheckBox.Size = new System.Drawing.Size(47, 17);
            this.boldCheckBox.TabIndex = 9;
            this.boldCheckBox.Text = "Bold";
            this.boldCheckBox.UseVisualStyleBackColor = true;
            this.boldCheckBox.CheckedChanged += new System.EventHandler(this.UpdateTextStyle);
            // 
            // italicCheckBox
            // 
            this.italicCheckBox.AutoSize = true;
            this.italicCheckBox.Location = new System.Drawing.Point(366, 193);
            this.italicCheckBox.Name = "italicCheckBox";
            this.italicCheckBox.Size = new System.Drawing.Size(48, 17);
            this.italicCheckBox.TabIndex = 10;
            this.italicCheckBox.Text = "Italic";
            this.italicCheckBox.UseVisualStyleBackColor = true;
            this.italicCheckBox.CheckedChanged += new System.EventHandler(this.UpdateTextStyle);
            // 
            // changeColorButton
            // 
            this.changeColorButton.Location = new System.Drawing.Point(12, 219);
            this.changeColorButton.Name = "changeColorButton";
            this.changeColorButton.Size = new System.Drawing.Size(75, 23);
            this.changeColorButton.TabIndex = 11;
            this.changeColorButton.Text = "Text Color...";
            this.changeColorButton.UseVisualStyleBackColor = true;
            this.changeColorButton.Click += new System.EventHandler(this.ChangeColor);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(436, 24);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.appendToolStripMenuItem,
            this.toolStripSeparator1,
            this.saveAsToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.BrowseForImageClick);
            // 
            // appendToolStripMenuItem
            // 
            this.appendToolStripMenuItem.Name = "appendToolStripMenuItem";
            this.appendToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.appendToolStripMenuItem.Text = "Append";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(118, 6);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.saveAsToolStripMenuItem.Text = "Save as...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.SaveImage);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.closeToolStripMenuItem.Text = "Close";
            // 
            // makeMemeButton
            // 
            this.makeMemeButton.Location = new System.Drawing.Point(348, 159);
            this.makeMemeButton.Name = "makeMemeButton";
            this.makeMemeButton.Size = new System.Drawing.Size(75, 23);
            this.makeMemeButton.TabIndex = 13;
            this.makeMemeButton.Text = "Make";
            this.makeMemeButton.UseVisualStyleBackColor = true;
            this.makeMemeButton.Click += new System.EventHandler(this.MakeMemeButtonClick);
            // 
            // MemeMakerView
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 561);
            this.Controls.Add(this.makeMemeButton);
            this.Controls.Add(this.changeColorButton);
            this.Controls.Add(this.italicCheckBox);
            this.Controls.Add(this.boldCheckBox);
            this.Controls.Add(this.saveAsButton);
            this.Controls.Add(this.fontSizeNumeric);
            this.Controls.Add(this.fontComboBox);
            this.Controls.Add(this.browseButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bottomText);
            this.Controls.Add(this.upperText);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MemeMakerView";
            this.Text = "Meme Maker";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MemeMakerDragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MemeMakerDragEnter);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MemeMakerKeyDown);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.meme)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fontSizeNumeric)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.RichTextBox upperText;
        private System.Windows.Forms.RichTextBox bottomText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.OpenFileDialog imageOpenDialog;
        private System.Windows.Forms.ComboBox fontComboBox;
        private System.Windows.Forms.NumericUpDown fontSizeNumeric;
        private System.Windows.Forms.Button saveAsButton;
        private System.Windows.Forms.SaveFileDialog imageSaveDialog;
        private System.Windows.Forms.CheckBox italicCheckBox;
        private System.Windows.Forms.CheckBox boldCheckBox;
        private System.Windows.Forms.ColorDialog textColorDialog;
        private System.Windows.Forms.Button changeColorButton;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem appendToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private UIComponents.PanZoomPictureBox meme;
        private System.Windows.Forms.Button makeMemeButton;
    }
}

