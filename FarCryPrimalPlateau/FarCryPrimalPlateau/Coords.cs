﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarCryPrimalPlateau
{
    public struct Coords
    {
        public Coords(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }

        public override string ToString() => $"({X}, {Y})";
    }
}
