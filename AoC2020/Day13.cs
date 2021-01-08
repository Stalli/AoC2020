using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC2020
{
    public static class Day13
    {
        public static long Task13_2(string[] input)
        {
            var numbers = input[1].Split(',');
            var equations = new List<Tuple<int,int>>();
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i]=="x") continue;
                var num = Convert.ToInt32(numbers[i]);
                equations.Add(new Tuple<int, int>((num-i)%num,num));
            }

            long x0 = 0;
            long M=1;
            foreach (var m in equations)
                M *= m.Item2;
            
            var Ms = new List<long>();
            foreach (var equation in equations)
                Ms.Add(M/equation.Item2);
            
            var Ys = new List<int>();
            for (int i = 0; i < equations.Count; i++)
            {
                var Mb = Ms[i];
                var ms = equations[i].Item2;
                for (int j = 1; j < ms; j++)
                {
                    if ((Mb * j - 1) % ms == 0)
                    {
                        Ys.Add(j);
                        break;
                    }
                }
            }

            for (int i = 0; i < Ms.Count; i++)
            {
                x0 += Ms[i] * Ys[i] * equations[i].Item1;
            }

            var x = x0 % M;
            return x;
        }

        public static int Task13_1(string[] input)
        {
            var timeStamp = Convert.ToInt32(input[0]);
            var buses = input[1].Split(',').Where(x=> x!="x").Select(x=> Convert.ToInt32(x));
            var qwe = buses
                .Select(x => new Tuple<int, int>(x, (x-timeStamp % x)))
                .OrderBy(x => x.Item2)
                .Select(x => x.Item1 * x.Item2).First();

            return qwe;
        }
    }
}