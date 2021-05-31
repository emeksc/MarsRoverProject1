using Core.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Abstract
{
    public class RoverMovements
    {
        public static IRoverPosition Move(IRoverPosition roverPosition)
        {
            IRoverPosition currentRoverPosition = roverPosition;

            if (roverPosition.Direction == Directions.N) currentRoverPosition = new RoverPosition(roverPosition.Direction, roverPosition.X, roverPosition.Y + 1);
            else if (roverPosition.Direction == Directions.E) currentRoverPosition = new RoverPosition(roverPosition.Direction, roverPosition.X, roverPosition.Y - 1);
            else if (roverPosition.Direction == Directions.S) currentRoverPosition = new RoverPosition(roverPosition.Direction, roverPosition.X - 1, roverPosition.Y);
            else if (roverPosition.Direction == Directions.W) currentRoverPosition = new RoverPosition(roverPosition.Direction, roverPosition.X + 1, roverPosition.Y);

            return currentRoverPosition;
        }

        public static Directions TurnRight(Directions roverDirection)
        {
            Directions currentRoverDirection = roverDirection;

            if (roverDirection == Directions.N) currentRoverDirection = Directions.E;
            else if (roverDirection == Directions.E) currentRoverDirection = Directions.S;
            else if (roverDirection == Directions.S) currentRoverDirection = Directions.W;
            else if (roverDirection == Directions.W) currentRoverDirection = Directions.N;

            return currentRoverDirection;
        }

        public static Directions TurnLeft(Directions roverDirection)
        {
            Directions currentRoverDirection = roverDirection;

            if (roverDirection == Directions.N) currentRoverDirection = Directions.W;
            else if (roverDirection == Directions.E) currentRoverDirection = Directions.N;
            else if (roverDirection == Directions.S) currentRoverDirection = Directions.E;
            else if (roverDirection == Directions.W) currentRoverDirection = Directions.S;

            return currentRoverDirection;
        }
    }
}
