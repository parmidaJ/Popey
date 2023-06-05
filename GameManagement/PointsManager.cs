using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PJNKFinalProject.GameManagement
{
    public static class PointsManager
    {
        //point, heart point, and counter with 75 secounds
        private static int points, pointsHeart, counter = 7500;
        public static int Points { get => points; set => points = value; }
        public static int PointsHearts { get => pointsHeart; set => pointsHeart = value; }
        public static int Counter { get => counter; set => counter = value; }
    }
}
