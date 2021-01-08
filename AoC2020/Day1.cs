using System;
using System.Collections.Generic;

namespace AoC2020
{
    public static class Day1
    {
        public static List<int> Get2020_task1(string[] input)
        {
            for (int i = 0; i < input.Length-1; i++)
            for (int j = i+1; j < input.Length; j++)
            {
                try
                {
                    var num1 = Convert.ToInt32(input[i].Trim());
                    var num2 = Convert.ToInt32(input[j].Trim());
                    if (num1+num2==2020)
                        return new List<int> { num1, num2};
                }
                catch (Exception e)
                {
                }
            }
            return new List<int>();
        }
        
        public static int Get2020_task2(string[] input)
        {
            var numbers = new List<int>();
            foreach (var x in input)
            {
                try
                {
                    numbers.Add(Convert.ToInt32(x.Trim()));
                }
                catch (Exception e)
                {
                }
            }

            for (int i = 0; i < numbers.Count-2; i++)
            for (int j = i+1; j < numbers.Count-1; j++)
            for (int k = j+1; k < numbers.Count; k++)
            {
                if (numbers[i] + numbers[j] + numbers[k] == 2020)
                    return numbers[i] * numbers[j] * numbers[k];
            }
            throw new Exception("Not found! OMG");
        }
    }
}