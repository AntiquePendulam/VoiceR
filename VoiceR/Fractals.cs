using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VoiceR
{
    public partial class Fractals : Form
    {
        VoiceRN Vn = new VoiceRN();
        public Fractals()
        {
            Vn.SYSTEMLOADER();
                InitializeComponent();
            int left = Screen.PrimaryScreen.WorkingArea.Width - 64;
            this.SetDesktopLocation(left - 6, 40);
            Vn.GetForm = this;
            Vn.Show();
            Vn.Visible = false;
            Vn.yHide = true;
            Vn.Fractal.Start();
        }
        private void Fractals_MouseEnter(object sender, EventArgs e)
        {
            MICBOX.BackgroundImage = Properties.Resources.mickicker;
        }

        private void MICBOX_MouseLeave(object sender, EventArgs e)
        {
            MICBOX.BackgroundImage = Properties.Resources.mickick;
        }

        private void Fractals_Deactivate(object sender, EventArgs e)
        {
            MICBOX.BackgroundImage = Properties.Resources.mickick;
        }

        public Boolean yay = false;
        private void MICBOX_MouseUp(object sender, MouseEventArgs e)
        {
            yay = !yay;
            if (yay)
            {   
                this.Deactivate -= new System.EventHandler(this.Fractals_Deactivate);
                this.MICBOX.MouseEnter -= new System.EventHandler(this.Fractals_MouseEnter);
                this.MICBOX.MouseLeave -= new System.EventHandler(this.MICBOX_MouseLeave);
                Vn.Visible = true;
                //Vn.Fractal.Start();
                Vn.VoiceYay(true);
            }
            else
            {
                SYuuryo();
                //Vn.Fractal.Start();
                Vn.VoiceYay(false);
            }
        }
        public void SYuuryo()
        {
            this.Deactivate += new System.EventHandler(this.Fractals_Deactivate);
            this.MICBOX.MouseEnter += new System.EventHandler(this.Fractals_MouseEnter);
            this.MICBOX.MouseLeave += new System.EventHandler(this.MICBOX_MouseLeave);
        }
    }
}
