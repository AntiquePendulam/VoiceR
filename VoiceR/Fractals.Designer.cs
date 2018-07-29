namespace VoiceR
{
    partial class Fractals
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.MICBOX = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.MICBOX)).BeginInit();
            this.SuspendLayout();
            // 
            // MICBOX
            // 
            this.MICBOX.BackColor = System.Drawing.Color.Transparent;
            this.MICBOX.BackgroundImage = global::VoiceR.Properties.Resources.mickick;
            this.MICBOX.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.MICBOX.InitialImage = null;
            this.MICBOX.Location = new System.Drawing.Point(0, 0);
            this.MICBOX.Margin = new System.Windows.Forms.Padding(0);
            this.MICBOX.Name = "MICBOX";
            this.MICBOX.Size = new System.Drawing.Size(64, 64);
            this.MICBOX.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.MICBOX.TabIndex = 0;
            this.MICBOX.TabStop = false;
            this.MICBOX.MouseEnter += new System.EventHandler(this.Fractals_MouseEnter);
            this.MICBOX.MouseLeave += new System.EventHandler(this.MICBOX_MouseLeave);
            this.MICBOX.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MICBOX_MouseUp);
            // 
            // Fractals
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(250, 250);
            this.Controls.Add(this.MICBOX);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Fractals";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Yay";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.White;
            this.Deactivate += new System.EventHandler(this.Fractals_Deactivate);
            ((System.ComponentModel.ISupportInitialize)(this.MICBOX)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.PictureBox MICBOX;
    }
}