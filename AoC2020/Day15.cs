using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC2020
{
    public static class Day15
    {
        public static int Task15_1(string[] input)
        {
            var dict = new Dictionary<int,Tuple<int?,int?>>();
            for (int i = 1; i <= input.Length; i++)
            {
                var num = Convert.ToInt32(input[i-1]);
                dict[num] = new Tuple<int?,int?>(i,null);
            }

            var curPos = input.Length + 1;
            var last = Convert.ToInt32(input.Last());
            while (curPos!=30000000+1)
            {
                if (dict[last].Item2==null)
                {
                    last = 0;
                    if (dict[0].Item2==null)
                    {
                        dict[0]=new Tuple<int?, int?>(dict[0].Item1, curPos);
                    }
                    else
                    {
                        dict[0]=new Tuple<int?, int?>(dict[0].Item2, curPos);
                    }
                }
                else
                {
                    last = dict[last].Item2.Value - dict[last].Item1.Value;
                    if(!dict.ContainsKey(last))
                        dict[last]=new Tuple<int?, int?>(curPos,null);
                    else
                    {
                        if (dict[last].Item2==null)
                        {
                            dict[last]=new Tuple<int?, int?>(dict[last].Item1, curPos);
                        }
                        else
                        {
                            dict[last]=new Tuple<int?, int?>(dict[last].Item2, curPos);
                        }
                    }
                }

                curPos++;
            }

            return last;
        }
    }
}