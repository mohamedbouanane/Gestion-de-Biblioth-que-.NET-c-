using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IHM.Components.Animation;

namespace TacosCodeForm.Tools
{
    public partial class UC_Head : UserControl
    {

        TacosCode_FormOpacityEffects formViewEffects;

        public UC_Head()
        {
            InitializeComponent();
        }

        private void UC_Head_Load(object sender, EventArgs e)
        {
            if (this.ParentForm != null)
                try
                {
                    formViewEffects = new TacosCode_FormOpacityEffects(this.ParentForm, 1);
                    formViewEffects.Show();

                }
                catch (Exception x) { Msg.Show(x); }
        }


        private void tacosPictBtnExit_Click(object sender, EventArgs e)
        {
            if (formViewEffects != null)
                formViewEffects.Exite();
        }

        private void tacosPictBtnMaximize_Click(object sender, EventArgs e)
        {
            if (this.ParentForm != null)
                try
                {
                    if (this.ParentForm.WindowState == FormWindowState.Normal) this.ParentForm.WindowState = FormWindowState.Maximized;
                    else if (this.ParentForm.WindowState == FormWindowState.Maximized) this.ParentForm.WindowState = FormWindowState.Normal;
                    //Properties.Resources.Expand_24px;
                }
                catch (Exception x) { Msg.Show(x); }
        }

        private void tacosPictBtnMinimize_Click(object sender, EventArgs e)
        {
            if (this.ParentForm != null)
                this.ParentForm.WindowState = FormWindowState.Minimized;
        }


        Point lastPoint;
        private void panel_head_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                lastPoint = new Point(e.X, e.Y);
            }
            catch (Exception x) { Msg.Show(x); }
        }

        private void panel_head_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Left && this.ParentForm != null)
                {
                    this.ParentForm.Left += e.X - lastPoint.X;
                    this.ParentForm.Top += e.Y - lastPoint.Y;
                }
            }
            catch (Exception x) { Msg.Show(x); }
        }

    }
}
