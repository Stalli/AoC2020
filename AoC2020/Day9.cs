using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC2020
{
    public static class Day9
    {
        private static long Task9_2(long sum, string[] input)
        {
            var nums = input.Select(x => Convert.ToInt64((string?) x)).ToList();
            var a = 0;
            var b = 1;
            var total = nums.GetRange(a,b-a+1).Sum();
            while (total != sum)
            {
                if (total<sum)
                    b++;
                else
                {
                    a++;
                    b--;
                }
                total = nums.GetRange(a,b-a+1).Sum();
            }

            var qwe= nums.GetRange(a, b - a + 1).OrderBy(x => x).ToList();
            return qwe.First() + qwe.Last();
        }

        private static long Task9_1(string[] input)
        {
            var set = new HashSet<long>();
            var list = new List<long>();
            
            for (int i = 0; i < input.Length; i++)
            {
                var num = Convert.ToInt64(input[i]);
                set.Add(num);
                list.Add(num);
                if (i < 25) continue;

                if (!list.Any(firstTerm=> set.Contains(num-firstTerm)))
                    return num;
            }
            
            throw new Exception("Not found");
        }
    }
}