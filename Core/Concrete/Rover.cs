using Core.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Concrete
{
    public class Rover : IRover
    {
        public IRoverPosition CurrentPosition { get; set; }
        public IPlateau Plateau { get; set; }
        public IList<Action> Commands { get; set; }

        public Rover()
        {
            this.Commands = new List<Action>();
        }
        public Rover(IRoverPosition roverPosition, IPlateau plateau)
        {
            this.CurrentPosition = roverPosition;
            this.Plateau = plateau;
            this.Commands = new List<Action>();
        }

        public void Move()
        {
            CheckPlateauSize();
            this.CurrentPosition = RoverMovements.Move(this.CurrentPosition);
        }

        public void TurnLeft()
        {
            this.CurrentPosition.Direction = RoverMovements.TurnLeft(this.CurrentPosition.Direction);
        }

        public void TurnRight()
        {
            this.CurrentPosition.Direction = RoverMovements.TurnRight(this.CurrentPosition.Direction);
        }

        public bool PutRoverInPosition(string position)
        {
            var roverPosition = position.Split(' ');
            if (roverPosition.Length == 3)
            {
                try
                {
                    var x = int.Parse(roverPosition[0]);
                    var y = int.Parse(roverPosition[1]);

                    var direction = roverPosition[2].ToUpper();
                    if (direction == "N" || direction == "S" || direction == "E" || direction == "W")
                    {
                        this.CurrentPosition.Direction = (Directions)Enum.Parse(typeof(Directions), direction);
                        this.CurrentPosition.X = x;
                        this.CurrentPosition.Y = y;
                        return true;
                    }
                }
                catch (Exception)
                {
                }
            }
            return false;
        }


        public void CommandParse(string roverCommand)
        {
            foreach (var letter in roverCommand.ToCharArray())
            {
                switch (char.ToUpper(letter))
                {
                    case 'L':
                        this.Commands.Add(() => TurnLeft());
                        break;
                    case 'R':
                        this.Commands.Add(() => TurnRight());
                        break;
                    case 'M':
                        this.Commands.Add(() => Move());
                        break;
                }
            }
        }

        public IRoverPosition Calculate()
        {
            foreach (var command in this.Commands)
            {
                command.Invoke();
            }

            return this.CurrentPosition;
        }

        public void CheckPlateauSize()
        {
            var plateauX = this.Plateau.X;
            var plateauY = this.Plateau.Y;
            var currentRoverPosition = this.CurrentPosition;

            if ((currentRoverPosition.X > plateauX || currentRoverPosition.X < 0) || (currentRoverPosition.Y > plateauY || currentRoverPosition.Y < 0))
            {
                throw new Exception("Rover going out of limits");
            }
        }
    }
}
