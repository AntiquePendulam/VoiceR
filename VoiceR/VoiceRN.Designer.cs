namespace VoiceR
{
    partial class VoiceRN
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VoiceRN));
            this.SunLight = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MoonLight = new System.Windows.Forms.Label();
            this.Fractal = new System.Windows.Forms.Timer(this.components);
            this.Blade = new System.Windows.Forms.Timer(this.components);
            this.SunLight.SuspendLayout();
            this.SuspendLayout();
            // 
            // SunLight
            // 
            this.SunLight.BackColor = System.Drawing.Color.DimGray;
            this.SunLight.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stopToolStripMenuItem});
            this.SunLight.Name = "SunLight";
            this.SunLight.Size = new System.Drawing.Size(102, 26);
            // 
            // stopToolStripMenuItem
            // 
            this.stopToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            this.stopToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            this.stopToolStripMenuItem.Size = new System.Drawing.Size(101, 22);
            this.stopToolStripMenuItem.Text = "Stop";
            this.stopToolStripMenuItem.Click += new System.EventHandler(this.stopToolStripMenuItem_Click);
            // 
            // MoonLight
            // 
            this.MoonLight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.MoonLight.BackColor = System.Drawing.Color.Transparent;
            this.MoonLight.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.MoonLight.ForeColor = System.Drawing.Color.White;
            this.MoonLight.Location = new System.Drawing.Point(0, 66);
            this.MoonLight.Name = "MoonLight";
            this.MoonLight.Size = new System.Drawing.Size(350, 50);
            this.MoonLight.TabIndex = 1;
            this.MoonLight.Text = "MoonLight";
            this.MoonLight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Fractal
            // 
            this.Fractal.Interval = 5;
            this.Fractal.Tick += new System.EventHandler(this.Fractal_Tick);
            // 
            // Blade
            // 
            this.Blade.Interval = 1000;
            this.Blade.Tick += new System.EventHandler(this.Blade_Tick);
            // 
            // VoiceRN
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(350, 180);
            this.ContextMenuStrip = this.SunLight;
            this.ControlBox = false;
            this.Controls.Add(this.MoonLight);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "VoiceRN";
            this.Opacity = 0.8D;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.Blue;
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.VoiceRN_MouseDoubleClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.VoiceRN_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.VoiceRN_MouseMove);
            this.SunLight.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip SunLight;
        private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
        private System.Windows.Forms.Label MoonLight;
        public System.Windows.Forms.Timer Fractal;
        private System.Windows.Forms.Timer Blade;
    }
}

