using System.Text;

namespace ConnectionsSquare
{
    public class Point
    {
        public int x, y;
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            Point compareTo = (Point)obj;
            return compareTo.x == x && compareTo.y == y;
        }
        public override string ToString()
        {
            return "(" + x + ", " + y + ")";
        }
    }

}
