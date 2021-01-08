using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC2020
{
    public static class Day22
    {
        public static int Task22_1(string[] input)
        {
            var player1Deck =
                new Queue<int>(input[0].Split("Player 1:\r\n")[1].Split("\r\n").Select(x => Convert.ToInt32(x)));
            var player2Deck =
                new Queue<int>(input[1].Split("Player 2:\r\n")[1].Split("\r\n").Select(x => Convert.ToInt32(x)));

            while (player1Deck.Any() && player2Deck.Any())
            {
                var p1C = player1Deck.Dequeue();
                var p2C = player2Deck.Dequeue();
                if (p1C >= p2C)
                {
                    player1Deck.Enqueue(p1C);
                    player1Deck.Enqueue(p2C);
                }
                else
                {
                    player2Deck.Enqueue(p2C);
                    player2Deck.Enqueue(p1C);
                }
            }

            var res = 0;
            if (player1Deck.Any())
            {
                var total = player1Deck.Count;
                var i = 0;
                while (i < total)
                {
                    res += player1Deck.Dequeue() * (total - i);
                    i++;
                }
            }
            else
            {
                var total = player2Deck.Count;
                var i = 0;
                while (i < total)
                {
                    res += player2Deck.Dequeue() * (total - i);
                    i++;
                }
            }

            throw new NotImplementedException();
        }
        
        public static int Task22_2(string[] input)
        {
            var player1Deck =
                new Queue<int>(input[0].Split("Player 1:\r\n")[1].Split("\r\n").Select(x => Convert.ToInt32((string?) x)));
            var player2Deck =
                new Queue<int>(input[1].Split("Player 2:\r\n")[1].Split("\r\n").Select(x => Convert.ToInt32(x)));


            return SubGame(new Queue<int>(player1Deck), new Queue<int>(player2Deck), true);
        }

        private static int SubGame(Queue<int> player1Deck, Queue<int> player2Deck, bool firstCall = false)
        {
            var Rounds = new HashSet<string>();
            while (player1Deck.Any() && player2Deck.Any())
            {
                var hash = $"{String.Join(',', player1Deck.ToArray())};{String.Join(',', player2Deck.ToArray())}";
                if (!Rounds.Contains(hash))
                {
                    Rounds.Add(hash);
                }
                else
                {
                    return 1;
                }

                var p1C = player1Deck.Dequeue();
                var p2C = player2Deck.Dequeue();
                if (player1Deck.Count >= p1C && player2Deck.Count >= p2C)
                {
                    var winner = SubGame(new Queue<int>(player1Deck.Take(p1C)), new Queue<int>(player2Deck.Take(p2C)));

                    if (winner == 1)
                    {
                        player1Deck.Enqueue(p1C);
                        player1Deck.Enqueue(p2C);
                    }
                    else
                    {
                        player2Deck.Enqueue(p2C);
                        player2Deck.Enqueue(p1C);
                    }

                    continue;
                }

                if (p1C >= p2C)
                {
                    player1Deck.Enqueue(p1C);
                    player1Deck.Enqueue(p2C);
                }
                else
                {
                    player2Deck.Enqueue(p2C);
                    player2Deck.Enqueue(p1C);
                }
            }

            if (!firstCall)
                return player1Deck.Any() ? 1 : 2;

            var res = 0;
            if (player1Deck.Any())
            {
                var total = player1Deck.Count;
                var i = 0;
                while (i < total)
                {
                    res += player1Deck.Dequeue() * (total - i);
                    i++;
                }
            }
            else
            {
                var total = player2Deck.Count;
                var i = 0;
                while (i < total)
                {
                    res += player2Deck.Dequeue() * (total - i);
                    i++;
                }
            }

            return res;
        }
    }
}