using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeGame
{
    public class Point
    {
        int x;
        int y;
        public int X
        {
            get
            {
                return x;
            }
            set
            {
                if (value < 0)
                {
                    x = Game.Width - 1;
                }
                else if (value >= Game.Width)
                {
                    x = 0;
                }
                else
                {
                    x = value;
                }
            }
        }
        public int Y
        {
            get
            {
                return y;
            }
            set
            {
                if (value < 0)
                {
                    y = Game.Height - 1;
                }
                else if (value >= Game.Height)
                {
                    y = 0;
                }
                else
                {
                    y = value;
                }
            }
        }
        public override bool Equals(Object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Point p = (Point)obj;
                return (x == p.x) && (y == p.y);
            }
        }

        public override int GetHashCode()
        {
            return x ^ y;
        }
    }
}
