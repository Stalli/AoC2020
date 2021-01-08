using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC2020
{
    public static class Day21
    {
        public static int Task21_1_V2(string[] input, string raw)
        {
            var map = new Dictionary<Tuple<string, string>, int>(); // aler ingr
            var rawIng = new List<string>();
            for (var j = 0; j < input.Length; j++)
            {
                var row = input[j];
                var ingredients = row.Split(" (")[0].Split(' ');
                rawIng.AddRange(ingredients);
                var allergens = row.Replace(")", "").Split(" (contains ")[1].Split(", ");
                foreach (var allergen in allergens)
                foreach (var ingredient in ingredients)
                {
                    var key = new Tuple<string, string>(allergen, ingredient);
                    if (!map.ContainsKey(key)) map[key] = 0;
                    map[key]++;
                }
            }

            var qwe2 = map.OrderByDescending(m => m.Value).ToList();
            //then a bit of excel
            /*dhfng	znrzgs	ntggc	nqbnmzx	pgblcd	dstct	xhkdc	ghlzj
            1	dairy	13							
            7	soy		13	13	13				
            2	eggs				11	11			
            8	wheat	11	11						
            5	sesame	8			8	8	8		
            3	fish		8	8	8			8	
            4	peanuts	8			8		8	8	8
            6	shellfish	7	7		7				
									
									
            dhfng,pgblcd,xhkdc,ghlzj,dstct,nqbnmzx,ntggc,znrzgs		*/

            var ingToExclude = new List<string>
            {
                "dhfng",
                "znrzgs",
                "ntggc",
                "nqbnmzx",
                "pgblcd",
                "dstct",
                "xhkdc",
                "ghlzj"
            };
            var okIngredients = map.Where(x => !ingToExclude.Contains(x.Key.Item2)).Select(x => x.Key.Item2).Distinct()
                .ToList();
            var total = 0;
            foreach (var q in okIngredients)
            {
                total += rawIng.Count(x => x == q);
            }

            throw new NotImplementedException();
        }
    }
}