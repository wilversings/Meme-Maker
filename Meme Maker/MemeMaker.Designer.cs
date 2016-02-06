namespace Meme_Maker {
    partial class MemeMaker {
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
            this.meme = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.imageOpenDialog = new System.Windows.Forms.OpenFileDialog();
            this.fontComboBox = new System.Windows.Forms.ComboBox();
            this.fontSizeNumeric = new System.Windows.Forms.NumericUpDown();
            this.button2 = new System.Windows.Forms.Button();
            this.imageSaveDialog = new System.Windows.Forms.SaveFileDialog();
            this.boldCheckBox = new System.Windows.Forms.CheckBox();
            this.italicCheckBox = new System.Windows.Forms.CheckBox();
            this.textColorDialog = new System.Windows.Forms.ColorDialog();
            this.changeColorButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.meme)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fontSizeNumeric)).BeginInit();
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
            this.upperText.Location = new System.Drawing.Point(12, 48);
            this.upperText.Name = "upperText";
            this.upperText.Size = new System.Drawing.Size(193, 60);
            this.upperText.TabIndex = 0;
            this.upperText.Text = "";
            this.upperText.TextChanged += new System.EventHandler(this.updateMeme);
            // 
            // bottomText
            // 
            this.bottomText.Location = new System.Drawing.Point(212, 48);
            this.bottomText.Name = "bottomText";
            this.bottomText.Size = new System.Drawing.Size(212, 61);
            this.bottomText.TabIndex = 1;
            this.bottomText.Text = "";
            this.bottomText.TextChanged += new System.EventHandler(this.updateMeme);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Top text";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(364, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Bottom text";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.meme);
            this.groupBox1.Location = new System.Drawing.Point(12, 187);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(412, 349);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Meme";
            // 
            // meme
            // 
            this.meme.ImageLocation = "";
            this.meme.Location = new System.Drawing.Point(6, 19);
            this.meme.Name = "meme";
            this.meme.Size = new System.Drawing.Size(400, 324);
            this.meme.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.meme.TabIndex = 0;
            this.meme.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 115);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(108, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Browse for image...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
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
            this.fontComboBox.Location = new System.Drawing.Point(127, 116);
            this.fontComboBox.Name = "fontComboBox";
            this.fontComboBox.Size = new System.Drawing.Size(133, 21);
            this.fontComboBox.TabIndex = 6;
            this.fontComboBox.SelectedIndexChanged += new System.EventHandler(this.updateTextStyle);
            // 
            // fontSizeNumeric
            // 
            this.fontSizeNumeric.Location = new System.Drawing.Point(267, 116);
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
            this.fontSizeNumeric.ValueChanged += new System.EventHandler(this.updateTextStyle);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(349, 158);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "Save as...";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.saveImage);
            // 
            // imageSaveDialog
            // 
            this.imageSaveDialog.Filter = "Bitmap Image (.bmp)|*.bmp|Gif Image (.gif)|*.gif|JPEG Image (.jpeg)|*.jpeg|Png Im" +
    "age (.png)|*.png|Tiff Image (.tiff)|*.tiff|Wmf Image (.wmf)|*.wmf";
            // 
            // boldCheckBox
            // 
            this.boldCheckBox.AutoSize = true;
            this.boldCheckBox.Location = new System.Drawing.Point(312, 117);
            this.boldCheckBox.Name = "boldCheckBox";
            this.boldCheckBox.Size = new System.Drawing.Size(47, 17);
            this.boldCheckBox.TabIndex = 9;
            this.boldCheckBox.Text = "Bold";
            this.boldCheckBox.UseVisualStyleBackColor = true;
            this.boldCheckBox.CheckedChanged += new System.EventHandler(this.updateTextStyle);
            // 
            // italicCheckBox
            // 
            this.italicCheckBox.AutoSize = true;
            this.italicCheckBox.Location = new System.Drawing.Point(366, 118);
            this.italicCheckBox.Name = "italicCheckBox";
            this.italicCheckBox.Size = new System.Drawing.Size(48, 17);
            this.italicCheckBox.TabIndex = 10;
            this.italicCheckBox.Text = "Italic";
            this.italicCheckBox.UseVisualStyleBackColor = true;
            this.italicCheckBox.CheckedChanged += new System.EventHandler(this.updateTextStyle);
            // 
            // changeColorButton
            // 
            this.changeColorButton.Location = new System.Drawing.Point(12, 144);
            this.changeColorButton.Name = "changeColorButton";
            this.changeColorButton.Size = new System.Drawing.Size(75, 23);
            this.changeColorButton.TabIndex = 11;
            this.changeColorButton.Text = "Text Color...";
            this.changeColorButton.UseVisualStyleBackColor = true;
            this.changeColorButton.Click += new System.EventHandler(this.changeColor);
            // 
            // MemeMaker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 544);
            this.Controls.Add(this.changeColorButton);
            this.Controls.Add(this.italicCheckBox);
            this.Controls.Add(this.boldCheckBox);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.fontSizeNumeric);
            this.Controls.Add(this.fontComboBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bottomText);
            this.Controls.Add(this.upperText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "MemeMaker";
            this.Text = "Meme Maker";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MemeMaker_KeyDown);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.meme)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fontSizeNumeric)).EndInit();
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
        private System.Windows.Forms.PictureBox meme;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.OpenFileDialog imageOpenDialog;
        private System.Windows.Forms.ComboBox fontComboBox;
        private System.Windows.Forms.NumericUpDown fontSizeNumeric;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.SaveFileDialog imageSaveDialog;
        private System.Windows.Forms.CheckBox italicCheckBox;
        private System.Windows.Forms.CheckBox boldCheckBox;
        private System.Windows.Forms.ColorDialog textColorDialog;
        private System.Windows.Forms.Button changeColorButton;
    }
}

