using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smallGame
{
    public class Ball
    {
        internal float x, y, rad, speedX, speedY, x45, y45, xminus45, yminus45;
        Random rand;
        internal SolidBrush brush;
        internal RectangleF bounds;
        public Ball(float x, float y, float rad, float speedX, float speedY)
        {
            rand = new Random();
            this.x = x;
            this.y = y;
            this.rad = rad;
            this.speedX = speedX;
            this.speedY = speedY;
            xminus45 = x + rad * (float)Math.Cos((225 * Math.PI) / 180);
            yminus45 = y + rad * (float)Math.Sin((225 * Math.PI) / 180);
            x45 = x + rad * (float)Math.Cos((315 * Math.PI) / 180);
            y45 = y + rad * (float)Math.Sin((315 * Math.PI) / 180);
            //x = r * cos(fi)
            //y = r * sin(fi)
            if (Properties.Settings.Default.color_ball_is)
                brush = new SolidBrush(Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255)));
            else
                brush = new SolidBrush(Properties.Settings.Default.color_ball);
        }
        public void onDraw(Graphics g)
        {
            g.FillEllipse(brush, x - rad, y - rad, 2 * rad, 2 * rad);
            bounds = g.ClipBounds;
        }
        public void move()
        {
            this.x += speedX;
            this.y += speedY;
        }
    }
}
