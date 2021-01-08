using System.Collections.Generic;
using System.Linq;

namespace AoC2020
{
    public static class Day19
    {
        private static List<string> res31;
        private static Dictionary<string,string> rulesDict;
        
        public static int Task19_1(string[] rulesInput, string[] dataInput)
        {
            rulesDict = new Dictionary<string,string>();
            foreach (var ruleInput in rulesInput)
            {
                var id = ruleInput.Split(": ")[0];
                var data = ruleInput.Split(": ")[1];
                rulesDict.Add(id,data);
            }

            var res = GetValues("0");
            var allPossible = new HashSet<string>();

            foreach (var possibleVal in res)
                allPossible.Add(possibleVal);

            var total = dataInput.Count(data => allPossible.Contains(data));

            return total;
        }
        
        public static int Task19_2(string[] rulesInput, string[] dataInput)
        {
            rulesDict = new Dictionary<string,string>();
            foreach (var ruleInput in rulesInput)
            {
                var id = ruleInput.Split(": ")[0];
                var data = ruleInput.Split(": ")[1];
                rulesDict.Add(id,data);
            }

            var res = GetValues2("0", dataInput);
            var allPossible = new HashSet<string>();

            foreach (var possibleVal in res)
                allPossible.Add(possibleVal);

            var total = dataInput.Count(data => allPossible.Contains(data));

            return total;
        }

        private static List<string> GetValues2(string id, string[]? dataInput =null)
        {
            if (id == "\"a\"") return new List<string> { "a" };
            if (id == "\"b\"") return new List<string> { "b" };
            var qwe1=GetValues2(rulesDict[id].Split(" | ")[0].Split(' ')[0]);
            var qwe2 = rulesDict[id].Split(" | ")[0].Contains(' ')
                ? GetValues2(rulesDict[id].Split(" | ")[0].Split(' ')[1])
                : new List<string>();

            if (id=="0")
            {
                var filtered = new List<string>();
                var total = 0;
                var w1 = qwe1[0].Length;
                var w2 = res31[0].Length;
                foreach (var mes in dataInput)
                {
                    var message = mes;
                    var totalTails = 0;
                    while (message!="" && res31.Contains(message[^w2..]))
                    {
                        message = message.Substring(0, message.Length - w2);
                        totalTails++;
                    }
                    if (message.Length == 0)
                    {
                        continue;
                    }
                    
                    message = mes;
                    var totalHeads = 0;
                    while (message!="" && qwe1.Contains(message[..w1]))
                    {
                        message = message.Substring(w1, message.Length - w1);
                        totalHeads++;
                    }

                    if ((totalTails+totalHeads)*8==mes.Length && totalTails>=1 && totalHeads>=1+totalTails)
                    {
                        total++;
                    }
                    
                    /*if (message.Length == 0)
                    {
                        total++;
                    }*/
                }
                
                var filtered2 = new List<string>();
                
                foreach (var mes in filtered)
                {
                    //if (qwe1.Contains(mes[..w1]))// || res31.Contains(mes[^w2..]))
                    if (qwe1.Contains(mes))
                        filtered2.Add(mes);
                    else if (qwe1.Contains(mes[..w1]) && res31.Contains(mes[^w2..]))
                    {
                        
                    }
                }

            }
            var intersection1 = qwe2.Any()
                ? qwe1.SelectMany(x => qwe2, (x, y) => x + y).ToList()
                : qwe1;

            /*if (id=="11")
            {
                intersection1.AddRange(qwe1.SelectMany(x => qwe2, (x, y) => x+x+y+y).ToList());
                intersection1.AddRange(qwe1.SelectMany(x => qwe2, (x, y) => x+x+x+y+y+y).ToList());
                intersection1.AddRange(qwe1.SelectMany(x => qwe2, (x, y) => x+x+x+x+y+y+y+y).ToList());
            }

            if (id=="8")
            {
                intersection1.AddRange(intersection1.Select(x => x+x).ToList());
                intersection1.AddRange(intersection1.Select(x => x+x+x).ToList());
                intersection1.AddRange(intersection1.Select(x => x+x+x+x).ToList());
            }*/
            
            var intersection2 = new List<string>();
            if (rulesDict[id].Contains('|'))
            {
                var qwe3 = GetValues2(rulesDict[id].Split(" | ")[1].Split(' ')[0]);
                var qwe4 = rulesDict[id].Split(" | ")[1].Contains(' ')
                    ? GetValues2(rulesDict[id].Split(" | ")[1].Split(' ')[1])
                    : new List<string>();

                intersection2 = qwe4.Any()
                    ? qwe3.SelectMany(x => qwe4, (x, y) => x + y).ToList()
                    : qwe3;
            }

            var res = new List<string>();
            res.AddRange(intersection1);
            res.AddRange(intersection2);

            if (id=="8" || id=="11")
            {
                var qweqwe = 2;
            }
            if (id=="42" || id=="8" || id=="31" || id=="11")
            {
                var qweqwe = 2;
            }
            if (id=="31")
            {
                //res31 = res;
                res31=new List<string>(res);
            }
            return res;
        }

        private static List<string> GetValues(string id)
        {
            if (id == "\"a\"") return new List<string> { "a" };
            if (id == "\"b\"") return new List<string> { "b" };
            var qwe1=GetValues(rulesDict[id].Split(" | ")[0].Split(' ')[0]);
            var qwe2 = rulesDict[id].Split(" | ")[0].Contains(' ')
                ? GetValues(rulesDict[id].Split(" | ")[0].Split(' ')[1])
                : new List<string>();

            var intersection1 = qwe2.Any()
                ? qwe1.SelectMany(x => qwe2, (x, y) => x + y).ToList()
                : qwe1;
            
            var intersection2 = new List<string>();
            if (rulesDict[id].Contains('|'))
            {
                var qwe3 = GetValues(rulesDict[id].Split(" | ")[1].Split(' ')[0]);
                var qwe4 = rulesDict[id].Split(" | ")[1].Contains(' ')
                    ? GetValues(rulesDict[id].Split(" | ")[1].Split(' ')[1])
                    : new List<string>();

                intersection2 = qwe4.Any()
                    ? qwe3.SelectMany(x => qwe4, (x, y) => x + y).ToList()
                    : qwe3;
            }

            var res = new List<string>();
            res.AddRange(intersection1);
            res.AddRange(intersection2);

            return res;
        }
    }
}