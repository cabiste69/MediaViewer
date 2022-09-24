using System.Linq;

namespace MediaViewer
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.PictureOpened = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PictureOpened)).BeginInit();
            this.SuspendLayout();
            // 
            // PictureOpened
            // 
            this.PictureOpened.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PictureOpened.Location = new System.Drawing.Point(0, 0);
            this.PictureOpened.Margin = new System.Windows.Forms.Padding(20);
            this.PictureOpened.Name = "PictureOpened";
            this.PictureOpened.Size = new System.Drawing.Size(1064, 635);
            this.PictureOpened.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PictureOpened.TabIndex = 0;
            this.PictureOpened.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.ClientSize = new System.Drawing.Size(1064, 635);
            this.Controls.Add(this.PictureOpened);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.PictureOpened)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PictureBox PictureOpened;
    }
}