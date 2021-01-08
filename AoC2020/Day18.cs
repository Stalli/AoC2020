using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC2020
{
    public static class Day18
    {
        public static long Task18_1(List<string> input)
        {
            long total = 0;
            foreach (var row in input)
            {
                total+= EvaluateSimple(row);
            }

            return total;
        }
        
        public static long Task18_2(List<string> input)
        {
            long total = 0;
            
            foreach (var row in input)
            {
                var stack = new Stack<string>();
                foreach (var letter in row)
                    stack.Push(letter.ToString());
                
                var braOpened = 0;

                var innerLevel = 0;
                foreach (var c in row)
                {
                    if (c == '(')
                    {
                        braOpened++;
                        if (braOpened > innerLevel) innerLevel = braOpened;
                        continue;
                    }
                    if (c == ')')
                    {
                        braOpened--;
                        continue;
                    }
                }
                var interRes = stack;

                for (int i = 0; i <= innerLevel; i++)
                {
                    interRes = EvaluateSimple2(interRes, new[] {"+"}, innerLevel-i);
                    interRes = EvaluateSimple2(interRes, new[] {"*"}, innerLevel-i);
                }

                total += Convert.ToInt64(interRes.Pop());
            }

            return total;
        }

        private static Stack<string> EvaluateSimple2(Stack<string> s, string[] actions, int levelToProceed)
        {
            
            var braOpened = 0;
            var stack = new Stack<string>();
            foreach (var let in s.Reverse())
            {
                if (let == " ") continue;
                if (let=="(")
                {
                    braOpened++;
                    stack.Push(let.ToString());
                    continue;
                }
                
                if (let == ")")
                {
                    braOpened--;
                }

                if (braOpened<levelToProceed && !((braOpened==levelToProceed-1) && let == ")"))
                {
                    stack.Push(let.ToString());
                    continue;
                }
                
                string cur = let.ToString();

                if (let == ")")
                {
                    var num = stack.Pop();
                    if (stack.Peek() != "(")
                    {
                        stack.Push(num);
                        stack.Push(")");
                        continue;
                    }
                    stack.Pop();//remove (
                    stack.Push(num);
                    continue;
                }

                if (cur == "+" || cur == "*")
                {
                    stack.Push(cur.ToString());
                    continue;
                }

                if (!stack.Any())
                {
                    stack.Push(cur.ToString());
                    continue;
                }

                if (stack.Peek() == "(")
                {
                    stack.Push(cur.ToString());
                    continue;
                }
                if (!actions.Contains(stack.Peek()))
                {
                    stack.Push(cur.ToString());
                    continue;
                }
                var sign = stack.Pop();
                if(sign!="+" && sign!= "*") throw new Exception();
                var firstArg = stack.Pop();
                var res = sign == "+"
                    ? Convert.ToInt64(firstArg) + Convert.ToInt64(cur.ToString())
                    : Convert.ToInt64(firstArg) * Convert.ToInt64(cur.ToString());

                stack.Push(res.ToString());
            }

            return stack;
        }

        private static long EvaluateSimple(string s)
        {
            var stack = new Stack<string>();
            foreach (var let in s)
            {
                if (let == ' ') continue;
                if (let=='(')
                {
                    stack.Push(let.ToString());
                    continue;
                }
                string cur = let.ToString();

                if (let == ')')
                {
                    var num = stack.Pop();
                    if (stack.Peek()!="(") throw new Exception();
                    stack.Pop();//remove (
                    cur = num;
                }

                if (cur == "+" || cur == "*")
                {
                    stack.Push(cur.ToString());
                    continue;
                }

                if (!stack.Any())
                {
                    stack.Push(cur.ToString());
                    continue;
                }

                if (stack.Peek() == "(")
                {
                    stack.Push(cur.ToString());
                    continue;
                }
                
                var sign = stack.Pop();
                if(sign!="+" && sign!= "*") throw new Exception();
                var firstArg = stack.Pop();
                var res = sign == "+"
                    ? Convert.ToInt64(firstArg) + Convert.ToInt64(cur.ToString())
                    : Convert.ToInt64(firstArg) * Convert.ToInt64(cur.ToString());

                stack.Push(res.ToString());
            }

            if (stack.Count>1)
            {
                throw    new Exception();
            }
            return Convert.ToInt64(stack.Pop());
        }
    }
}