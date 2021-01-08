using System.Collections.Generic;
using System.Linq;

namespace AoC2020
{
    public static class Day10
    {
        private static HashSet<int> Task10Set;

        public static int Task10_1(IEnumerable<int> input)
        {
            var ordered = input.ToList();
            ordered.Add(0);
            ordered=ordered.OrderBy(x => x).ToList();
            
            var diff1 = 0;
            var diff3 = 1;
            for (int i = 1; i < ordered.Count; i++)
            {
                if (ordered[i]-ordered[i-1]==1)
                    diff1++;
                if (ordered[i]-ordered[i-1]==3)
                    diff3++;
            }

            return diff1 * diff3;
        }
        
        public static long Task10_2(IEnumerable<int> input)
        {
            var ordered = input.ToList();
            ordered.Add(0);
            ordered.Add(ordered.Max()+3);
            ordered=ordered.OrderBy(x => x).ToList();
            
            Task10Set = new HashSet<int>();
            foreach (var x in ordered)
                Task10Set.Add(x);

            long total = 1;
            var left = 0;
            for (int i = 0; i < ordered.Count-2; i++)
            {
                if (Task10Set.Contains(ordered[i]) && !Task10Set.Contains(ordered[i]+1) && !Task10Set.Contains(ordered[i]+2))
                {
                    total *= CountWays(ordered[left],ordered[i]);
                    left = i + 3;
                }
            }
            total *= CountWays(ordered[ordered.Count-3],ordered[ordered.Count-1]);

            return total;

        }

        public static long Task10_2_small(IEnumerable<int> input)
        {
            var ordered = input.ToList();
            ordered.Add(0);
            ordered.Add(ordered.Max()+3);
            ordered=ordered.OrderBy(x => x).ToList();
            var max = ordered.Last();
            
            Task10Set = new HashSet<int>();
            foreach (var x in ordered)
                Task10Set.Add(x);

            return CountWays(0,max);

        }

        private static long CountWays2(int cur, int max)
        {
            if (cur == max) return 1;
            if (cur > max) return 0;
            
            long localWays = 0;
            localWays += CountWays2(cur+1,max);
            localWays += CountWays2(cur+2,max);
            localWays += CountWays2(cur+3,max);
            
            return localWays;
        }

        private static long CountWays(int cur, int max)
        {
            if (cur == max) return 1;
            if (cur > max) return 0;
            
            long localWays = 0;
            if (Task10Set.Contains(cur + 1))
                localWays += CountWays(cur+1,max);

            if (Task10Set.Contains(cur + 2))
                localWays += CountWays(cur+2,max);

            if (Task10Set.Contains(cur + 3))
                localWays += CountWays(cur+3,max);
            
            return localWays;
        }
    }
}