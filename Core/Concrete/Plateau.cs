using Core.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Concrete
{
    public class Plateau : IPlateau
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool IsReady { get; set; }
        public bool CreatePlateau(string size)
        {
            this.IsReady = false;
            size = size.Trim();
            if (!String.IsNullOrEmpty(size))
            {
                var plateauSize = size.Split(' ');
                if (plateauSize.Length == 2)
                {
                    var xSize = Convert.ToInt32(plateauSize[0]);
                    var ySize = Convert.ToInt32(plateauSize[1]);

                    if (xSize > 0 && ySize > 0)
                    {
                        this.X = xSize;
                        this.Y = ySize;
                        this.IsReady = true;
                    }
                }
            }
            return this.IsReady;
        }
    }
}
