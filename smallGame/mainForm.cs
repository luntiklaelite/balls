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
        int score;

        public mainForm()
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            rand = new Random();
            newGame();
        }

        private void newGame()
        {
            score = 0;
            scoreLabel.Text = "SCORE: ";
            recordLabel.Text = "TOP SCORE: " + Properties.Settings.Default.record;
            ball = new Ball(ClientSize.Width / 2, ClientSize.Height / 2, 10, rand.Next(-5, 5), rand.Next(-5, 5));
            while (ball.speedX > -2 && ball.speedX < 2)
                ball.speedX = rand.Next(-5, 5);
            while (ball.speedY > -2 && ball.speedY < 2)
                ball.speedY = rand.Next(-5, 5);
            rect_pl = new Rect(ClientSize.Width / 2, ClientSize.Height - 20, 150, 20, 30);
            ball.setColor();
            rect_pl.brush = new SolidBrush(Properties.Settings.Default.color_platf);
            BackColor = Properties.Settings.Default.color_fon;
            isGameStarted = false;
            partPl = "";
            Refresh();
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
            /*if (ball.bounds.IntersectsWith(rect_pl.bounds))
            {
                if (ball.x >= rect_pl.p_2.X && ball.x <= rect_pl.p_3.X)
                    partPl = "middle";
                else
                    partPl = "trian";
                return true;
            }
            return false;*/
            if (dlinaXY(new PointF(ball.x, getProectY(ball, rect_pl)), new PointF(ball.x, ball.y)) <= ball.rad)
                return true;
            return false;
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (ball.y > rect_pl.p_4.Y)
            {
                timer1.Stop();
                isGameStarted = false;
                if (Properties.Settings.Default.record < score)
                {
                    MessageBox.Show("Вы проиграли!\nВами установлен новый рекорд: " + score + "!");
                    Properties.Settings.Default.record = score;
                    Properties.Settings.Default.Save();
                }
                else
                    MessageBox.Show("Вы проиграли!\nПрошлый рекорд (" + Properties.Settings.Default.record + ") не был побит.");
                newGame();
                return;
            }
            if (ball.x + ball.rad >= ClientSize.Width || ball.x - ball.rad <= 0)
                ball.speedX = -ball.speedX;
            if (ball.y - ball.rad <= menuStrip1.Height)
            {
                ball.speedY = -ball.speedY;
                score++;
                scoreLabel.Text = "SCORE: " + score;
            }
            if (ball.y + ball.rad >= rect_pl.p_2.Y && inBall(ball, rect_pl) && partPl == "middle")
            {
                ball.speedY += rand.Next(20) / 10;
                ball.speedX += rand.Next(20) / 10;
                ball.speedY = -ball.speedY;

            }
            if ((ball.y + ball.rad >= rect_pl.p_2.Y || ball.y45 >= rect_pl.p_2.Y || ball.yminus45 >= rect_pl.p_2.Y) && inBall(ball, rect_pl) && partPl == "trian")
            {
                ball.speedY += rand.Next(20) / 10;
                ball.speedX += rand.Next(20) / 10;
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
            else if (e.KeyChar == ' ' && isGameStarted)
            {
                timer1.Stop();
                isGameStarted = false;
            }
        }

        private void mainForm_MouseMove(object sender, MouseEventArgs e)
        {
            rect_pl.x = e.X;
            if(inBall(ball, rect_pl) && ball.y + ball.rad > rect_pl.p_2.Y + rect_pl.height/2)
            {
                ball.x -= rect_pl.height;
                ball.speedY += rand.Next(20) / 10;
                ball.speedX += rand.Next(20) / 10;
                ball.speedY = -ball.speedY;
            }
        }

        private void gameToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            isGameStarted = false;
            settingsForm setform = new settingsForm();
            setform.ShowDialog();
            ball.setColor();
            rect_pl.brush = new SolidBrush(Properties.Settings.Default.color_platf);
            BackColor = Properties.Settings.Default.color_fon;
            recordLabel.Text = "TOP SCORE: " + Properties.Settings.Default.record;
            Refresh();
            Properties.Settings.Default.Save();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            
        }
    }
}
