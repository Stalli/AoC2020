using System;
using System.Collections.Generic;

namespace AoC2020
{
    public class Rule
    {
        public Rule(string row)
        {
            var bagDesc = row.Split(" bags")[0];
            Bag = new Bag { Shade = bagDesc.Split(' ')[0], Color = bagDesc.Split(' ')[1]};
            
            var childsDesc = row.Split("contain ")[1];
            Childs=new List<Tuple<int, Bag>>();
            if (childsDesc=="no other bags.")
                return;
            foreach (var child in childsDesc.Split(','))
            {
                var words = child.Replace(".","").Trim().Split(' ');
                try
                {
                    Childs.Add(new Tuple<int, Bag>(Convert.ToInt32(words[0]), new Bag {Shade = words[1], Color = words[2]}));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }
        public Bag Bag { get; set; }
        public List<Tuple<int,Bag>> Childs { get; set; }
    }
}