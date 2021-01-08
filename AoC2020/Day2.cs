using System;
using System.Linq;

namespace AoC2020
{
    public static class Day2
    {
        public static int PassportsValid(string[] input)
        {
            var validCount = 0;
            foreach (var row in input)
            {
                if (!row.Contains(':')) continue;
                var rule = row.Split(':')[0];
                var passport = row.Split(':')[1].Trim();

                var ruleLimits = rule.Split(' ')[0];
                var ruleChar = rule.Split(' ')[1].ToCharArray()[0];

                var downLimit = Convert.ToInt32(ruleLimits.Split('-')[0]);
                var upLimit = Convert.ToInt32(ruleLimits.Split('-')[1]);

                var count = passport.Count(x => x == ruleChar);
                if (count>=downLimit && count<=upLimit)
                    validCount++;
            }

            return validCount;
        }

        public static int PassportsValid2(string[] input)
        {
            var validCount = 0;
            foreach (var row in input)
            {
                if (!row.Contains(':')) continue;
                var rule = row.Split(':')[0];
                var passport = row.Split(':')[1].Trim();

                var ruleLimits = rule.Split(' ')[0];
                var ruleChar = rule.Split(' ')[1].ToCharArray()[0];

                var position1 = Convert.ToInt32(ruleLimits.Split('-')[0])-1;
                var position2 = Convert.ToInt32(ruleLimits.Split('-')[1])-1;

                if ((passport[position1]==ruleChar || passport[position2]==ruleChar) 
                    && passport[position1] != passport[position2])
                    validCount++;
            }

            return validCount;
        }
    }
}