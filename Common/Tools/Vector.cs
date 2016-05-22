using System;

namespace BotFactory.Common.Tools
{
    public class Vector
    {
        private double x = 0;
        public double X
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
            }
        }

        private double y = 0;
        public double Y
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
            }
        }

        
        public static Vector FromCoordinates(Coordinates begin, Coordinates end)
        {
            Vector v = new Vector();
            v.X = end.X - begin.X;
            v.Y = end.Y - begin.Y;
            return v;
        }
        public static double Length(Vector v)
        {
            double vecLength = Math.Sqrt((v.X * v.X) + (v.Y * v.Y));
            return vecLength;
        }
    }
}
