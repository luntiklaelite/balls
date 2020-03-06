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
        internal float x, y, width, height, kray;
        internal PointF p_1, p_2, p_3, p_4;
        public Rect(float x, float y, float width, float height, float kray)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            this.kray = kray;
        }
        public void onDraw(Graphics g)
        {
            p_1 = new PointF(x - width / 2, y + height / 2); // 
            p_2 = new PointF(x - width / 2 + kray, y - height / 2);
            p_3 = new PointF(x + width / 2 - kray, y - height / 2);
            p_4 = new PointF(x + width / 2, y + height / 2);
            PointF[] points = { p_1, p_2, p_3, p_4 };
            g.FillPolygon(Brushes.Black, points);
        }
    }
}
