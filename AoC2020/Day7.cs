using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC2020
{
    public static class Day7
    {
        private static int ShinyGoldContainers(string[] input)
        {
            var rules = input.Select(x => new Rule(x)).ToList();
            
            var ancestors = new HashSet<Bag>();
            var nextGenWanted = new List<Bag> { new Bag{Color = "gold", Shade = "shiny"}};
            int levelCount;
            do
            {
                levelCount = 0;
                var nextGenAnc = rules
                    .Where(r => r.Childs.Any(c => nextGenWanted.Contains(c.Item2)))
                    .Select(r => r.Bag)
                    .ToList();

                nextGenWanted = new List<Bag>();
                foreach (var newAnc in nextGenAnc)
                {
                    if (!ancestors.Contains(newAnc))
                    {
                        ancestors.Add(newAnc);
                        nextGenWanted.Add(newAnc);
                        levelCount++;
                    }
                }
            } while (levelCount>0);

            return ancestors.Count();
        }

        private static int ShinyGoldDescensors2(string[] input)
        {
            var rules = input.Select(x => new Rule(x)).ToList();
            var queue = new Queue<Tuple<int, Bag>>();
            queue.Enqueue(new Tuple<int, Bag>(1, new Bag{Color = "gold", Shade = "shiny"}));
            var total = 0;
            while (queue.Count>0)
            {
                var cur = queue.Dequeue();
                var rule = rules.FirstOrDefault(r => Equals(r.Bag, cur.Item2));
                total += rule.Childs.Sum(x => x.Item1)*cur.Item1;
                foreach (var child in rule.Childs)
                {
                    queue.Enqueue(new Tuple<int, Bag>(cur.Item1*child.Item1, child.Item2));
                }
            }

            return total;
        }

        private static int ShinyGoldDescensors(string[] input)
        {
            var rules = input.Select(x => new Rule(x)).ToList();
            var nextGenWanted = new List<Tuple<int,Bag>> { new Tuple<int, Bag>(1, new Bag{Color = "gold", Shade = "shiny"})};
            var ancestors = new HashSet<Bag>();
            var total = 0;
            var nextNextGenWanted = new List<Tuple<int, Bag>>();
            do
            {

                foreach (var des in nextGenWanted)
                {
                    var nextGenDes = rules
                        .Where(r => Equals(r.Bag, des.Item2))
                        .SelectMany(r => r.Childs)
                        .GroupBy(x => x.Item2, x => x.Item1, (x, y) => new {Bag = x, Count = y.Sum()})
                        .ToList();
                    total += nextGenDes.Count * des.Item1;
                    foreach (var newDes in nextGenDes)
                    {
                        if (!ancestors.Contains(newDes.Bag))
                        {
                            ancestors.Add(newDes.Bag);
                            nextNextGenWanted.Add(new Tuple<int, Bag>(newDes.Count, newDes.Bag));
                        }
                    }
                }

                nextGenWanted = new List<Tuple<int, Bag>>();
                nextGenWanted.AddRange(nextNextGenWanted);
                nextNextGenWanted = new List<Tuple<int, Bag>>();

            } while (nextGenWanted.Count>0);

            return total;
        }
    }
}