using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Abstract
{
    public interface IPlateau
    {
        int X { get; set; }
        int Y { get; set; }
        bool IsReady { get; set; }
        bool CreatePlateau(string size);
    }
}
