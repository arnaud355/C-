﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarCryPrimalPlateau
{
    public static class Singleton
    {
        public static List<int> gamesCoordX = new List<int>();
        public static List<int> gamesCoordY = new List<int>();

        public static int GetRandom()
        {
            Random random = new Random();

            return random.Next(0, 7);
        }
    }
}