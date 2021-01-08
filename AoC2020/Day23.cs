using System;
using System.Collections.Generic;

namespace AoC2020
{
    public static class Day23
    {
        public static long Task23_2(string input, int turns)
        {
            var head = new LLNode<int>(int.Parse(input[0].ToString()));
            var cur = head;
            var maxValue = 1000000;
            var dict = new Dictionary<int, LLNode<int>> {{head.Data, head}};

            for (int i = 1; i < input.Length; i++)
            {
                var newOne = new LLNode<int>(int.Parse(input[i].ToString()));
                cur.Next = newOne;
                cur = newOne;

                dict.Add(newOne.Data, newOne);
            }

            for (int i = input.Length + 1; i <= 1000000; i++)
            {
                var newOne = new LLNode<int>(i);
                cur.Next = newOne;
                cur = newOne;

                dict.Add(newOne.Data, newOne);
            }

            cur.Next = head;
            cur = head;

            for (int i = 0; i < turns; i++)
            {
                var pickUpHead = cur.Next;
                var pickUpTail = pickUpHead.Next.Next;
                var pickUpValues = new HashSet<int> {pickUpHead.Data, pickUpHead.Next.Data, pickUpTail.Data};

                var destVal = cur.Data - 1;
                while (pickUpValues.Contains(destVal) || destVal == 0)
                {
                    destVal--;
                    if (destVal <= 0)
                        destVal = maxValue;
                }

                var destNode = dict[destVal];

                cur.Next = pickUpTail.Next;
                var temp = destNode.Next;
                destNode.Next = pickUpHead;
                pickUpTail.Next = temp;

                cur = cur.Next;
            }

            return (long) dict[1].Next.Data * (long) dict[1].Next.Next.Data;
        }

        public static string Task23_1(string input, int turns)
        {
            var head = new LLNode<int>(int.Parse(input[0].ToString()));
            var cur = head;
            var maxValue = head.Data;
            var dict = new Dictionary<int, LLNode<int>> {{head.Data, head}};

            for (int i = 1; i < input.Length; i++)
            {
                var newOne = new LLNode<int>(int.Parse(input[i].ToString()));
                cur.Next = newOne;
                cur = newOne;

                if (newOne.Data > maxValue)
                    maxValue = newOne.Data;

                dict.Add(newOne.Data, newOne);
            }

            cur.Next = head;
            cur = head;

            for (int i = 0; i < turns; i++)
            {
                var pickUpHead = cur.Next;
                var pickUpTail = pickUpHead.Next.Next;
                var pickUpValues = new HashSet<int> {pickUpHead.Data, pickUpHead.Next.Data, pickUpTail.Data};

                var destVal = cur.Data - 1;
                while (pickUpValues.Contains(destVal) || destVal == 0)
                {
                    destVal--;
                    if (destVal <= 0)
                        destVal = maxValue;
                }

                var destNode = dict[destVal];

                cur.Next = pickUpTail.Next;
                var temp = destNode.Next;
                destNode.Next = pickUpHead;
                pickUpTail.Next = temp;

                cur = cur.Next;
            }

            var answer = String.Empty;
            cur = dict[1].Next;
            while (cur != dict[1])
            {
                answer = $"{answer}{cur.Data}";
                cur = cur.Next;
            }

            return answer;
        }
    }
}