using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC2020
{
    public static class Day4
    {
        public static int CountPassportsValid(string[] input)
        {
            var res = 0;
            var obligFields = new List<string>{"byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid"};
            foreach (var pas in input)
            {
                var fields = pas.Split( new[]{' ', '\n'});
                var fieldNames = fields.Select(f => f.Trim().Split(':')[0]);
                if (obligFields.All(x => fieldNames.Contains(x)))
                    res++;
            }

            return res;
        }

        public static int CountPassportsValid_Task2(string[] input)
        {
            var res = 0;
            var eyeColors = new List<string> { "amb", "blu", "brn", "gry", "grn", "hzl", "oth"};
            foreach (var pas in input)
            {
                var fields = pas.Split( new[]{' ', '\n'});
                var byrValue = fields.FirstOrDefault(x => x.Trim().Split(':')[0] == "byr")?.Trim().Split(':')[1];
                var iyrValue = fields.FirstOrDefault(x => x.Trim().Split(':')[0] == "iyr")?.Trim().Split(':')[1];
                var eyrValue = fields.FirstOrDefault(x => x.Trim().Split(':')[0] == "eyr")?.Trim().Split(':')[1];
                var hgtValue = fields.FirstOrDefault(x => x.Trim().Split(':')[0] == "hgt")?.Trim().Split(':')[1];
                var hclValue = fields.FirstOrDefault(x => x.Trim().Split(':')[0] == "hcl")?.Trim().Split(':')[1];
                var eclValue = fields.FirstOrDefault(x => x.Trim().Split(':')[0] == "ecl")?.Trim().Split(':')[1];
                var pidValue = fields.FirstOrDefault(x => x.Trim().Split(':')[0] == "pid")?.Trim().Split(':')[1];

                if (!int.TryParse(byrValue, out var byrIntValue) || byrIntValue<1920 || byrIntValue>2002) continue;
                if (!int.TryParse(iyrValue, out var iyrIntValue) || iyrIntValue<2010 || iyrIntValue>2020) continue;
                if (!int.TryParse(eyrValue, out var eyrIntValue) || eyrIntValue<2020 || eyrIntValue>2030) continue;
                if(hgtValue is null) continue;
                var metric = hgtValue.Substring(hgtValue.Length - 2);
                var hgtValueValue = Convert.ToInt32(hgtValue.Substring(0,hgtValue.Length - 2));//try catch
                if(metric!="cm" && metric!="in") continue;
                if(metric=="cm" && (hgtValueValue<150 || hgtValueValue>193)) continue;
                if(metric=="in" && (hgtValueValue<59 || hgtValueValue>76)) continue;
                if(hclValue is null) continue;
                if(hclValue.Length!=7) continue;
                if (!(hclValue.Substring(1, hclValue.Length - 1).All(x => (x <= 57 && x >= 48) || (x>=97 && x<=102)))) continue;
                if(eclValue is null) continue;
                if(!eyeColors.Contains(eclValue)) continue;
                if(pidValue is null) continue;
                if(pidValue.Length!=9) continue;
                if(pidValue.Any(x => x < 48 && x > 57)) continue;
                res++;
            }

            return res;
        }
    }
}