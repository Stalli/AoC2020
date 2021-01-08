using System.Linq;

namespace AoC2020
{
    public static class Day6
    {
        public static int YesAnswers(string[] input)
        {
            var res = 0;
            foreach (var group in input)
            {
                var oneLine = @group.Replace("\r\n", "");
                var uniqueCount = oneLine.GroupBy(x => x).Count();
                res += uniqueCount;
            }

            return res;
        }

        public static int EveryoneYesAnswers(string[] input)
        {
            var res = 0;
            foreach (var group in input)
            {
                var personsCount = @group.Split("\r\n").Length;
                var oneLine = @group.Replace("\r\n", "");
                var uniqueCount = oneLine.GroupBy(x=>x).Count(x => x.Count<char>()==personsCount);
                res += uniqueCount;
            }

            return res;
        }
    }
}