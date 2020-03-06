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
        Rect rect_pl;
        bool isGameStarted;
        Random rand;
        string partPl;

        public mainForm()
        {
            InitializeComponent();
            rand = new Random();
            ball = new Ball(ClientSize.Width / 2, ClientSize.Height / 2, 10, rand.Next(-5, 5), rand.Next(-5, 5));
            rect_pl = new Rect(ClientSize.Width / 2, ClientSize.Height - 20, 150, 20, 30);
            isGameStarted = false;
            partPl = "";
        }

        private void mainForm_Paint(object sender, PaintEventArgs e)
        {
            ball.onDraw(e.Graphics);
            rect_pl.onDraw(e.Graphics);
        }

        private float dlinaXY(PointF p1, PointF p2)
        {
            return (float)Math.Sqrt(Math.Pow(p2.X - p1.X,2) + Math.Pow(p2.Y - p1.Y,2));
        }

        private float getProectY(Ball ball, Rect rect_pl)
        {
            float proectY = 0;
            float gypotinuz = dlinaXY(rect_pl.p_1, rect_pl.p_2);
            if (ball.x >= rect_pl.p_1.X && ball.x < rect_pl.p_2.X) // левый треугольник
            {
                partPl = "trian";
                float cosA = rect_pl.kray / gypotinuz;
                float kray2 = dlinaXY(new PointF(rect_pl.p_1.X, rect_pl.p_1.Y), new PointF(ball.x, rect_pl.p_1.Y));
                float gyp2 = kray2 / cosA;
                float offset = (float)Math.Sqrt(Math.Pow(gyp2, 2) - Math.Pow(kray2, 2));
                proectY = rect_pl.p_1.Y - offset;
                
            }
            else if(ball.x >= rect_pl.p_2.X && ball.x <= rect_pl.p_3.X) //прямоугольник
            {
                partPl = "middle";
                proectY = rect_pl.p_2.Y;
            }
            else if(ball.x > rect_pl.p_3.X && ball.x <= rect_pl.p_4.X) //правый треугольник
            {
                partPl = "trian";
                float cosA = rect_pl.kray / gypotinuz;
                float kray2 = dlinaXY(new PointF(rect_pl.p_4.X, rect_pl.p_4.Y), new PointF(ball.x, rect_pl.p_4.Y));
                float gyp2 = kray2 / cosA;
                float offset = (float)Math.Sqrt(Math.Pow(gyp2, 2) - Math.Pow(kray2, 2));
                proectY = rect_pl.p_4.Y - offset;
            }
            return proectY;
        }

        private bool inBall(Ball ball, Rect rect_pl)
        {
            if (dlinaXY(new PointF(ball.x, getProectY(ball, rect_pl)), new PointF(ball.x, ball.y)) <= ball.rad)
                return true;
            return false;
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (ball.x + ball.rad >= ClientSize.Width || ball.x - ball.rad <= 0)
                ball.speedX = -ball.speedX;
            if (ball.y + ball.rad >= ClientSize.Height || ball.y - ball.rad <= 0)
                ball.speedY = -ball.speedY;
            if (ball.y + ball.rad >= rect_pl.p_2.Y && inBall(ball, rect_pl) && partPl == "middle")
                ball.speedY = -ball.speedY;
            if (ball.y + ball.rad >= rect_pl.p_2.Y && inBall(ball, rect_pl) && partPl == "trian")
            {
                ball.speedX = -ball.speedX;
                ball.speedY = -ball.speedY;
            }
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

        private void mainForm_MouseMove(object sender, MouseEventArgs e)
        {
            rect_pl.x = e.X;
        }
    }
}
