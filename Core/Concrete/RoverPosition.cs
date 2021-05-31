using Core.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Concrete
{
    public class RoverPosition : IRoverPosition
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Directions Direction { get; set; }

        public RoverPosition(Directions direction = Directions.N, int x = 0, int y = 0)
        {
            this.X = x;
            this.Y = y;
            this.Direction = direction;
        }
    }
}
