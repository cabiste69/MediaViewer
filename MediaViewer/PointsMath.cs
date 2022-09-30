using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaViewer
{
    public static class PointsMath
    {
        static public Point Add(Point a, Point b)
        {
            return new Point(a.X + b.X, a.Y + b.Y);
        }
        static public Point Subtract(Point a, Point b)
        {
            return new Point(a.X - b.X, a.Y - b.Y);
        }
    }
}
