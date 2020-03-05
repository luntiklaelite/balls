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
    public partial class mainForm : Form
    {
        Ball ball;
        bool isGameStarted;
        Random rand;
        Graphics g;
        public mainForm()
        {
            InitializeComponent();
            rand = new Random();
            ball = new Ball(ClientSize.Width / 2, ClientSize.Height / 2, 10f, rand.Next(-5, 5), rand.Next(-5, 5));
            isGameStarted = false;
        }

        private void mainForm_Paint(object sender, PaintEventArgs e)
        {
            ball.onDraw(e.Graphics);
            g = e.Graphics;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (ball.x + ball.rad >= ClientSize.Width || ball.x - ball.rad <= 0)
                ball.speedX = -ball.speedX;
            if (ball.y + ball.rad >= ClientSize.Height || ball.y - ball.rad <= 0)
                ball.speedY = -ball.speedY;
            ball.move();
            Refresh();
        }

        private void mainForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ' && !isGameStarted)
            {
                timer1.Start();
                isGameStarted = true;
            }
        }
    }
}
