using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smallGame
{
    public class Rect
    {
        internal float x, y, width, height;
        public Rect(float x, float y, float width, float height)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }
        public void onDraw(Graphics g)
        {
            g.FillRectangle(Brushes.GreenYellow, x - width / 2, y - height / 2, width, height);
        }
    }
}
