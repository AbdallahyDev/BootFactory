namespace BotFactory.Common.Tools
{
    public class Coordinates
    {
        public Coordinates()
        {
            x = 0;
            y = 0;
        }
        public Coordinates(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
        private double x;
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

        private double y;
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
        public bool Equals(Coordinates coord1, Coordinates coord2)
        {
            bool areEqual = false;
            if (((coord1.X == coord2.X) & (coord1.Y == coord2.Y)))
            {
                areEqual = true;
            }
            return areEqual;
        }

        public override string ToString()
        {
            return $"({X}, {Y})";
        }
    }
}
