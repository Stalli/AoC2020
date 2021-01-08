using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC2020
{
    public static class Day14
    {
        public static long Task14_2(string[] input)
        {
            var res = 0;
            var curMask = "";
            var qwe = new Dictionary<string,long>();

            foreach (var row in input)
            {
                if (row.StartsWith("mask"))
                {
                    curMask = row.Split(" = ")[1];
                    continue;
                }

                var number = Convert.ToInt32(row.Split(" = ")[1]);
                var index = Convert.ToInt32(row.Split(" = ")[0][4..(row.Split(" = ")[0].Length-1)]);
                
                var binaryAddress = Convert.ToString(index, 2);
                while (binaryAddress.Length != 36)
                {
                    binaryAddress = "0" + binaryAddress;
                }
                for (int i = 0; i < curMask.Length; i++)
                {
                    if (curMask[i]=='0') continue;
                    binaryAddress=binaryAddress.Remove(i,1).Insert(i,curMask[i].ToString());
                }

                var indeces = new List<string> { binaryAddress };
                var curAddress = binaryAddress;
                while (curAddress!=null)
                {
                    indeces.Remove(curAddress);
                    var i= curAddress.IndexOf('X');
                    indeces.Add(curAddress.Remove(i,1).Insert(i,"0"));
                    indeces.Add(curAddress.Remove(i,1).Insert(i,"1"));
                    curAddress = indeces.FirstOrDefault(x => x.Contains('X'));
                }

                foreach (var ind in indeces)
                    qwe[ind] = number;
            }

            return qwe.Sum(x => x.Value);
        }

        public static long Task14_1(string[] input)
        {
            var res = 0;
            var curMask = "";
            var qwe = new Dictionary<int,long>();

            foreach (var row in input)
            {
                if (row.StartsWith("mask"))
                {
                    curMask = row.Split(" = ")[1];
                    continue;
                }

                var number = Convert.ToInt32(row.Split(" = ")[1]);
                var index = Convert.ToInt32(row.Split(" = ")[0][4..(row.Split(" = ")[0].Length-1)]);
                var binary = Convert.ToString(number, 2);
                while (binary.Length != 36)
                {
                    binary = "0" + binary;
                }
                for (int i = 0; i < curMask.Length; i++)
                {
                    if (curMask[i]=='X') continue;
                    binary=binary.Remove(i,1).Insert(i,curMask[i].ToString());
                }

                var maskedInt = Convert.ToInt64(binary, 2);

                qwe[index] = maskedInt;
            }

            return qwe.Sum(x => x.Value);
        }
    }
}