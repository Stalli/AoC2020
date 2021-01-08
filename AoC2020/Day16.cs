using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC2020
{
    public static class Day16
    {
        public static int Task16_2(string[] rulesInput, string[] ticketsInput)
        {
            var rules = new List<Rule16>();
            foreach (var inputRule in rulesInput)
            {
                var x= inputRule.Split(": ")[1];
                var y = x.Split(' ')[0];
                var n1 = Convert.ToInt32(y.Split('-')[0]);
                var n2 = Convert.ToInt32(y.Split('-')[1]);
                var z = x.Split(' ')[2];
                var n3 = Convert.ToInt32(z.Split('-')[0]);
                var n4 = Convert.ToInt32(z.Split('-')[1]);
                var rule = new Rule16{Rule1 = new Tuple<int, int>(n1,n2), Rule2 = new Tuple<int, int>(n3,n4)};
                rules.Add(rule);
            }

            var ticketsToRemove = new HashSet<string>();
            foreach (var ticket in ticketsInput)
            {
                var nums = ticket.Split(',').Select(x => Convert.ToInt32((string?) x)).ToList();
                foreach (var num in nums)
                {
                    if (rules.All(r => !r.IsOk(num)) && !ticketsToRemove.Contains(ticket))
                        ticketsToRemove.Add(ticket);
                }
            }
            
            var tickets = ticketsInput.Where(ticket=> !ticketsToRemove.Contains(ticket)).Select(t => t.Split(',').Select(t => Convert.ToInt32(t)).ToList()).ToList();
            var res = new Dictionary<int,List<int>>();//rule ticket 

            for (int i = 0; i < rules.Count; i++)
            for (int j = 0; j < rules.Count; j++)
            {
                if (tickets.All(t => rules[i].IsOk(t[j])))
                {
                    if(!res.ContainsKey(i)) res[i]=new List<int>();
                    res[i].Add(j);
                }
            }

            throw new Exception();
        }

        public static int Task16_1(string[] rulesInput, string[] tickets)
        {
            var rules = new List<Rule16>();
            foreach (var inputRule in rulesInput)
            {
                var x= inputRule.Split(": ")[1];
                var y = x.Split(' ')[0];
                var n1 = Convert.ToInt32(y.Split('-')[0]);
                var n2 = Convert.ToInt32(y.Split('-')[1]);
                var z = x.Split(' ')[2];
                var n3 = Convert.ToInt32(z.Split('-')[0]);
                var n4 = Convert.ToInt32(z.Split('-')[1]);
                var rule = new Rule16{Rule1 = new Tuple<int, int>(n1,n2), Rule2 = new Tuple<int, int>(n3,n4)};
                rules.Add(rule);
            }

            var res = 0;

            foreach (var ticket in tickets)
            {
                var nums = ticket.Split(',').Select(x => Convert.ToInt32(x)).ToList();
                foreach (var num in nums)
                {
                    if (rules.All(r=>!r.IsOk(num)))
                        res += num;
                }
            }

            return res;
        }
    }
}