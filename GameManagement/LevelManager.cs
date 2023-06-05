using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PJNKFinalProject.GameManagement
{
    public static class LevelManager
    {
        //level and secound properties, secound is for sound effect
        private static int level = 1, second = 0;
        public static int Level { get => level; set => level = value; }
        public static int Second { get => second; set => second = value; }
    }
}
