using System;

namespace ragoz_oop_2
{
    public static class Utils
    {
        private static double GetRadians(double angle)
        {
            return angle * Math.PI / 180;
        }

        public static double GetCos(double angle)
        {
            return Math.Cos(GetRadians(angle));
        }
        
        public static double GetSin(double angle)
        {
            return Math.Sin(GetRadians(angle));
        }
    }
}