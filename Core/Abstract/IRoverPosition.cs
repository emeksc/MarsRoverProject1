using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Abstract
{
    public interface IRoverPosition
    {
        int X { get; set; }
        int Y { get; set; }
        Directions Direction { get; set; }
    }
}
