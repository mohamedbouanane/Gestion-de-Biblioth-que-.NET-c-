using IHM.Components;
using IHM.Components.Animation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TacosCodeForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ScrollBarEnhanced d = new ScrollBarEnhanced();

        }

        private void flexPicturButton1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("fffffff");
            Form f = new Form();

            TacosCode_FormOpacityEffects fv = new TacosCode_FormOpacityEffects(f);
            fv.Show();
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void Form1_MouseEnter(object sender, EventArgs e)
        {
            //MessageBox.Show("eeeeee");
        }

        private void Form1_MouseLeave(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //tacosCode_AutoResizeControl1.ExpandHight();
            //tacosCode_AutoResizeControl1.ExpandWidth();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            //tacosCode_AutoResizeControl1.ContractHeight();
            //tacosCode_AutoResizeControl1.ReduceWidth();
        }

        private void button1_DockChanged(object sender, EventArgs e)
        {

        }
    }
}
