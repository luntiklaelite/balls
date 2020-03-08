using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace smallGame
{
    public partial class settingsForm : Form
    {
        public settingsForm()
        {
            InitializeComponent();
            colorDialog1.FullOpen = true;
            checkBox1.Checked = Properties.Settings.Default.color_ball_is;
            //colorDialog1.Color =;
        }

        private void but_fon_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = Properties.Settings.Default.color_fon;
            if (colorDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            Properties.Settings.Default.color_fon = colorDialog1.Color;
            //standart:lavander
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.color_ball_is = checkBox1.Checked;
            Properties.Settings.Default.Save();
        }

        private void but_ball_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = Properties.Settings.Default.color_ball;
            if (colorDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            Properties.Settings.Default.color_ball = colorDialog1.Color;

        }

        private void but_platf_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = Properties.Settings.Default.color_platf;
            if (colorDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            Properties.Settings.Default.color_platf = colorDialog1.Color;
            //standart:cadet_blue

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.record = 0;
        }
    }
}
