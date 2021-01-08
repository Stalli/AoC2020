using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC2020
{
    public static class Day24
    {
        public static int Task24_2(string[] input, int turns)
        {
            #region init

            var dict = new Dictionary<Tuple<double, int>, bool>();
            double curX = 0;
            var curY = 0;

            for (var i = 0; i < input.Length; i++)
            {
                curX = 0;
                curY = 0;
                var row = input[i];
                var curAction = "";
                var j = 0;
                while (j < row.Length)
                {
                    if (row[j] == 'w')
                    {
                        curAction = "w";
                        j++;
                        curX--;
                    }
                    else if (row[j] == 'e')
                    {
                        curAction = "e";
                        j++;
                        curX++;
                    }
                    else if (row[j] == 'n')
                    {
                        curAction = $"{row[j]}{row[j + 1]}";
                        j += 2;
                        if (curAction == "nw")
                        {
                            curX -= 0.5;
                            curY++;
                        }
                        else if (curAction == "ne")
                        {
                            curX += 0.5;
                            curY++;
                        }
                        else
                        {
                            throw new Exception();
                        }
                    }
                    else if (row[j] == 's')
                    {
                        curAction = $"{row[j]}{row[j + 1]}";
                        j += 2;
                        if (curAction == "sw")
                        {
                            curX -= 0.5;
                            curY--;
                        }
                        else if (curAction == "se")
                        {
                            curX += 0.5;
                            curY--;
                        }
                        else
                        {
                            throw new Exception();
                        }
                    }
                    else
                    {
                        throw new Exception();
                    }
                } //while

                //false means white
                var key = new Tuple<double, int>(curX, curY);
                if (!dict.ContainsKey(key))
                    dict[key] = false;
                dict[key] = !dict[key];
            }

            #endregion

            var prevMap = new Dictionary<Tuple<double, int>, bool>(dict);
            for (int i = 0; i < turns; i++)
            {
                var curMap = new Dictionary<Tuple<double, int>, bool>(prevMap);
                var maxX = curMap.Select(x => x.Key.Item1).Max();
                var maxY = curMap.Select(x => x.Key.Item2).Max();
                var minX = curMap.Select(x => x.Key.Item1).Min();
                var minY = curMap.Select(x => x.Key.Item2).Min();

                for (double j = minX - 1; j <= maxX + 1; j += 0.5)
                for (int k = minY - 1; k <= maxY + 1; k++)
                {
                    //1.5 3 -> white
                    //-0.5 2 -> black
                    //-2.5 1 -> black
                    //0.5 1 -> black
                    //1 0 -> black
                    //2 0 -> white
                    //-0.5 -1 -> black
                    //0.5 -1 -> black
                    //1.5 -1 -> black
                    //1 -2 -> white
                    //-2.5 -3 -> black
                    if (j % 1 == 0 && k % 2 != 0) continue;
                    if (Math.Abs(j % 1) == 0.5 && Math.Abs(k % 2) != 1) continue;
                    var key = new Tuple<double, int>(j, k);
                    if (!prevMap.ContainsKey(key))
                        prevMap[key] = false;

                    var blackNeig = 0;
                    if (IsBlack(j - 0.5, k + 1, maxX, maxY, prevMap)) blackNeig++;
                    if (IsBlack(j + 0.5, k + 1, maxX, maxY, prevMap)) blackNeig++;
                    if (IsBlack(j + 1, k + 0, maxX, maxY, prevMap)) blackNeig++;
                    if (IsBlack(j + 0.5, k - 1, maxX, maxY, prevMap)) blackNeig++;
                    if (IsBlack(j - 0.5, k - 1, maxX, maxY, prevMap)) blackNeig++;
                    if (IsBlack(j - 1, k - 0, maxX, maxY, prevMap)) blackNeig++;

                    if (prevMap[key] == true) //black
                    {
                        if (blackNeig == 0 || blackNeig > 2)
                            curMap[key] = false; //white;
                    }
                    else
                    {
                        if (blackNeig == 2)
                            curMap[key] = true; //black
                    }
                }

                prevMap = new Dictionary<Tuple<double, int>, bool>(curMap);
            }

            return prevMap.Count(x => x.Value == true);
        }

        public static int Task24_1(string[] input)
        {
            var dict = new Dictionary<string, int>();
            double curX = 0;
            var curY = 0;

            for (var i = 0; i < input.Length; i++)
            {
                curX = 0;
                curY = 0;
                var row = input[i];
                var curAction = "";
                var j = 0;
                while (j < row.Length)
                {
                    if (row[j] == 'w')
                    {
                        curAction = "w";
                        j++;
                        curX--;
                    }
                    else if (row[j] == 'e')
                    {
                        curAction = "e";
                        j++;
                        curX++;
                    }
                    else if (row[j] == 'n')
                    {
                        curAction = $"{row[j]}{row[j + 1]}";
                        j += 2;
                        if (curAction == "nw")
                        {
                            curX -= 0.5;
                            curY++;
                        }
                        else if (curAction == "ne")
                        {
                            curX += 0.5;
                            curY++;
                        }
                        else
                        {
                            throw new Exception();
                        }
                    }
                    else if (row[j] == 's')
                    {
                        curAction = $"{row[j]}{row[j + 1]}";
                        j += 2;
                        if (curAction == "sw")
                        {
                            curX -= 0.5;
                            curY--;
                        }
                        else if (curAction == "se")
                        {
                            curX += 0.5;
                            curY--;
                        }
                        else
                        {
                            throw new Exception();
                        }
                    }
                    else
                    {
                        throw new Exception();
                    }
                }

                if (!dict.ContainsKey($"{curX};{curY}"))
                    dict[$"{curX};{curY}"] = 0;
                dict[$"{curX};{curY}"]++;
            }

            return dict.Count(x => x.Value % 2 == 1);
        }
        
        private static bool IsBlack(double x, int y, double maxX, int maxY,
            Dictionary<Tuple<double, int>, bool> prevMap)
        {
            var key = new Tuple<double, int>(x, y);
            if (!prevMap.ContainsKey(key)) return false;

            return prevMap[key];
        }
    }
}