using System;
using System.Collections.Generic;

namespace AoC2020
{
    public static class Day8
    {
        public static int AccAfterFix(string[] input)
        {
            var tried = new HashSet<int>();
            var rows = input;
            int? firstLoopIndex = null;
            bool isLastRowVisited;
            var accTotal = 0;
            int lastChangedIndex =-1;
            do
            {
                if (firstLoopIndex.HasValue)
                    rows = Fix(input, firstLoopIndex.Value, tried, ref lastChangedIndex);
                firstLoopIndex = FirstLoopIndex(rows, out isLastRowVisited, out accTotal);
            } while (firstLoopIndex.HasValue);

            return accTotal;
        }
        
        public static int Task2(string[] input)
        {
            try
            {
                var rows = input;
                var path = new Stack<int>();
                var i = 0;
                var visited = new HashSet<int>();
                var tried = new HashSet<int>();
                var accTotal = 0;
                var lastTried = -1;
                while (i < input.Length)
                {
                    if (visited.Contains(i))
                    {
                        while (input[path.Peek()].Split(' ')[0] == "acc" || tried.Contains(path.Peek()))
                        {
                            visited.Remove(path.Pop());
                        }
                        
                        visited.Remove(path.Peek());
                        tried.Add(path.Peek());
                        lastTried = path.Peek();
                        rows = input;
                        if (rows[path.Peek()].Split(' ')[0] == "jmp")
                            rows[path.Peek()] = rows[path.Peek()].Replace("jmp", "nop");
                        else if (rows[path.Peek()].Split(' ')[0] == "nop")
                            rows[path.Peek()] = rows[path.Peek()].Replace("nop", "jmp");

                        visited.Remove(i);
                        i = path.Peek();
                        continue;
                    }

                    path.Push(i);
                    visited.Add(i);

                    var words = rows[i].Split(' ');
                    if (words[0] == "acc")
                        accTotal += Convert.ToInt32(words[1]);
                    if (words[0] == "jmp")
                        i += Convert.ToInt32(words[1]);
                    else
                        i++;
                }

                if (input[lastTried].Split(' ')[0] == "jmp")
                    input[lastTried] = input[lastTried].Replace("jmp", "nop");
                else if (input[lastTried].Split(' ')[0] == "nop")
                    input[lastTried] = input[lastTried].Replace("nop", "jmp");
                return AccBeforeLoop(input);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        public static int Task2_attempt3(string[] input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                var rows = (string[]) input.Clone();
                if (rows[i].Split(' ')[0] == "acc") continue;
                
                if(rows[i].Split(' ')[0]=="nop")
                    rows[i]=rows[i].Replace("nop", "jmp");
                else if(rows[i].Split(' ')[0]=="jmp")
                    rows[i]=rows[i].Replace("jmp", "nop");

                if (!HasLoop(rows))
                    return CountAcc(rows);
            }
            
            throw new Exception("qwe");
        }

        private static int CountAcc(string[] rows)
        {
            return AccBeforeLoop(rows);
        }

        private static bool HasLoop(string[] input)
        {
            var i = 0;
            var visited = new HashSet<int>();
            while (i<input.Length)
            {
                if (visited.Contains(i)) return true;
                visited.Add(i);
                
                var words = input[i].Split(' ');
                if (words[0] == "jmp")
                    i += Convert.ToInt32(words[1]);
                else
                    i++;
            }

            return false;
        }

        private static string[] Fix(string[] rows, int loopIndex, HashSet<int> tried, ref int lastChangedIndex)
        {
            var startPoint = lastChangedIndex != -1 ? lastChangedIndex - 1 : loopIndex - 1;
            for (int i = startPoint; i >= 0; i--)
            {
                var word = rows[i].Split(' ')[0];
                if(word=="acc") continue;
                if (tried.Contains(i)) continue;
                tried.Add(i);
                if(word=="nop")
                    rows[i]=rows[i].Replace("nop", "jmp");
                if(word=="jmp")
                    rows[i]=rows[i].Replace("jmp", "nop");
                lastChangedIndex = i;
                return rows;
            }
            
            throw new Exception("Fix not found");
        }

        private static int? FirstLoopIndex(string[] input, out bool isLastRowVisited, out int total)
        {
            var i = 0;
            var visited = new HashSet<int>();
            var accTotal = 0;
            int prevIndex = -1;
            while (i<input.Length)
            {
                if (visited.Contains(i))
                {
                    isLastRowVisited = false;
                    total = -1;//doesn't matter
                    return prevIndex;
                }
                visited.Add(i);
                
                var words = input[i].Split(' ');
                if (words[0]=="acc")
                    accTotal += Convert.ToInt32(words[1]);
                
                prevIndex = i;

                if (words[0] == "jmp")
                    i += Convert.ToInt32(words[1]);
                else
                    i++;
            }

            isLastRowVisited = visited.Contains(input.Length - 1);
            total = accTotal;
            return null;
        }

        private static int AccBeforeLoop(string[] input)
        {
            var i = 0;
            var visited = new HashSet<int>();
            var accTotal = 0;
            while (i<input.Length)
            {
                if (visited.Contains(i)) 
                    return accTotal;
                visited.Add(i);
                
                var words = input[i].Split(' ');
                if (words[0]=="acc")
                    accTotal += Convert.ToInt32(words[1]);
                if (words[0] == "jmp")
                    i += Convert.ToInt32(words[1]);
                else
                    i++;
            }

            return accTotal;
        }
    }
}