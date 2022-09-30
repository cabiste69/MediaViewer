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
            this.button_NextImage = new System.Windows.Forms.Button();
            this.button_PreviousImage = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PictureOpened)).BeginInit();
            this.SuspendLayout();
            // 
            // PictureOpened
            // 
            this.PictureOpened.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PictureOpened.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PictureOpened.Location = new System.Drawing.Point(0, 0);
            this.PictureOpened.Margin = new System.Windows.Forms.Padding(0);
            this.PictureOpened.Name = "PictureOpened";
            this.PictureOpened.Size = new System.Drawing.Size(1064, 635);
            this.PictureOpened.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PictureOpened.TabIndex = 0;
            this.PictureOpened.TabStop = false;
            // 
            // button_NextImage
            // 
            this.button_NextImage.BackColor = System.Drawing.Color.Transparent;
            this.button_NextImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button_NextImage.Dock = System.Windows.Forms.DockStyle.Right;
            this.button_NextImage.FlatAppearance.BorderSize = 0;
            this.button_NextImage.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button_NextImage.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button_NextImage.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_NextImage.ForeColor = System.Drawing.Color.White;
            this.button_NextImage.Location = new System.Drawing.Point(989, 0);
            this.button_NextImage.Name = "button_NextImage";
            this.button_NextImage.Size = new System.Drawing.Size(75, 635);
            this.button_NextImage.TabIndex = 1;
            this.button_NextImage.Text = ">";
            this.button_NextImage.UseVisualStyleBackColor = false;
            this.button_NextImage.Visible = false;
            this.button_NextImage.Click += new System.EventHandler(this.button_NextImage_Click);
            // 
            // button_PreviousImage
            // 
            this.button_PreviousImage.BackColor = System.Drawing.Color.Transparent;
            this.button_PreviousImage.Dock = System.Windows.Forms.DockStyle.Left;
            this.button_PreviousImage.FlatAppearance.BorderSize = 0;
            this.button_PreviousImage.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_PreviousImage.ForeColor = System.Drawing.Color.White;
            this.button_PreviousImage.Location = new System.Drawing.Point(0, 0);
            this.button_PreviousImage.Name = "button_PreviousImage";
            this.button_PreviousImage.Size = new System.Drawing.Size(75, 635);
            this.button_PreviousImage.TabIndex = 2;
            this.button_PreviousImage.Text = "<";
            this.button_PreviousImage.UseVisualStyleBackColor = false;
            this.button_PreviousImage.Visible = false;
            this.button_PreviousImage.Click += new System.EventHandler(this.button_PreviousImage_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.ClientSize = new System.Drawing.Size(1064, 635);
            this.Controls.Add(this.button_PreviousImage);
            this.Controls.Add(this.button_NextImage);
            this.Controls.Add(this.PictureOpened);
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.PictureOpened)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PictureBox PictureOpened;
        private Button button_NextImage;
        private Button button_PreviousImage;
    }
}