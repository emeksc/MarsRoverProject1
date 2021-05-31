using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Abstract
{
    public interface IRover
    {
        IRoverPosition CurrentPosition { get; set; }
        IPlateau Plateau { get; set; }
        IList<Action> Commands { get; set; }
        void Move();
        void TurnRight();
        void TurnLeft();
        bool PutRoverInPosition(string position);
        void CommandParse(string roverCommand);
        IRoverPosition Calculate();
    }
}
