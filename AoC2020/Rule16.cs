using System;

namespace AoC2020
{
    public class Rule16
    {
        public Tuple<int,int> Rule1 { get; set; }
        public Tuple<int,int> Rule2 { get; set; }

        public bool IsOk(int num)
        {
            if (num >= Rule1.Item1 && num <= Rule1.Item2) return true;
            if (num >= Rule2.Item1 && num <= Rule2.Item2) return true;
            return false;
        }
    }
}