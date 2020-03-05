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
        internal float x, y, rad, speedX, speedY;
        Random rand;
        SolidBrush brush;
        public Ball(float x, float y, float rad, float speedX, float speedY)
        {
            rand = new Random();
            this.x = x;
            this.y = y;
            this.rad = rad;
            this.speedX = speedX;
            this.speedY = speedY;
            brush = new SolidBrush(Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255)));
        }
        public void onDraw(Graphics g)
        {
            g.FillEllipse(brush, x - rad, y - rad, 2 * rad, 2 * rad);
        }
        public void move()
        {
            this.x += speedX;
            this.y += speedY;
        }
    }
}
