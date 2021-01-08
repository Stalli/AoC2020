namespace AoC2020
{
    public static class Day3
    {
        public static int HowManyTrees(string[] input)
        {
            var i = 0;
            var j = 0;
            var res = 0;
            
            while (i<input.Length-1)
            {
                i += 2;
                j += 1;
                if (j >= input[i].Length) j -= input[i].Length;
                
                if (input[i].Trim()[j]=='#')
                    res++;
            }

            return res;
        }
    }
}