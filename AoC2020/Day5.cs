using System;
using System.Linq;

namespace AoC2020
{
    public static class Day5
    {
        public static int BiggestId(string[] input)
        {
            var x = 18;
            var qwe = "BFFBFBFLRL";
            var qwe1 = "BFFBFBF";
            var min = 0;
            var max = 127;
            foreach (var letter in qwe1)
            {
                if (letter == 'B') min += (int)Math.Round(0.5 * (max - min));
                if (letter == 'F') max -= (int)Math.Round(0.5 * (max - min));
            }

            var qwe2 = "LRL";
            min = 0;
            max = 7;
            
            foreach (var letter in qwe2)
            {
                if (letter == 'R') min += (int)Math.Round(0.5 * (max - min));
                if (letter == 'L') max -= (int)Math.Round(0.5 * (max - min));
            }
            throw new Exception();
        }
    }
}