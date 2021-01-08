using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC2020
{
    public static class Day20
    {
        public static long Task20_1(string[] input)
        {
            var pieces=new List<PuzzlePiece>();
            var free = new HashSet<string>();
            var dict = new Dictionary<string,List<string>>();
            foreach (var tile in input)
            {
                var id = tile.Split("\r\n")[0].Split(' ')[1];
                id = id.Replace(":", "");
                var cells=tile.Split("\r\n")[1..].Select(x => x.ToCharArray()).ToArray();
                var edge1 = new string(cells[0]);
                var edge2 = new string(cells.Last());
                var edge3 = new string(new []{cells[0].Last(),cells[1].Last(),cells[2].Last(),cells[3].Last(),cells[4].Last(),cells[5].Last(),cells[6].Last(),cells[7].Last(),cells[8].Last(),cells[9].Last()});
                var edge4 = new string(new []{cells[0].First(),cells[1].First(),cells[2].First(),cells[3].First(),cells[4].First(),cells[5].First(),cells[6].First(),cells[7].First(),cells[8].First(),cells[9].First()});
                pieces.Add(new PuzzlePiece
                {
                    Id = id,
                    Edges = new []{edge1,edge2,edge3,edge4},
                    Cells = cells
                });

                if (id=="1171")
                {
                    var qwe = 2;
                }
                free.Add(id);
                
                if (!dict.ContainsKey(edge1)) dict[edge1] = new List<string>();
                dict[edge1].Add(id);
                
                var edge1Rev = new string(edge1.ToCharArray().Reverse().ToArray());
                if (!dict.ContainsKey(edge1Rev)) dict[edge1Rev] = new List<string>();
                dict[edge1Rev].Add(id);
                
                if (!dict.ContainsKey(edge2)) dict[edge2] = new List<string>();
                dict[edge2].Add(id);
                
                var edge2Rev = new string(edge2.ToCharArray().Reverse().ToArray());
                if (!dict.ContainsKey(edge2Rev)) dict[edge2Rev] = new List<string>();
                dict[edge2Rev].Add(id);

                if (!dict.ContainsKey(edge3)) dict[edge3] = new List<string>();
                dict[edge3].Add(id);
                
                var edge3Rev = new string(edge3.ToCharArray().Reverse().ToArray());
                if (!dict.ContainsKey(edge3Rev)) dict[edge3Rev] = new List<string>();
                dict[edge3Rev].Add(id);

                if (!dict.ContainsKey(edge4)) dict[edge4] = new List<string>();
                dict[edge4].Add(id);
                
                var edge4Rev = new string(edge4.ToCharArray().Reverse().ToArray());
                if (!dict.ContainsKey(edge4Rev)) dict[edge4Rev] = new List<string>();
                dict[edge4Rev].Add(id);
            }
            var reversed= new Dictionary<string,List<string>>();
            foreach (var s in dict.Where(x=>x.Value.Count==1))
            {
                if (!reversed.ContainsKey(s.Value.First()))
                    reversed[s.Value.First()] = new List<string>();
                reversed[s.Value.First()].Add(s.Key);
            }

            long res = 1;
            foreach (var r in reversed.Where(x=>x.Value.Count==4))
                res *= Convert.ToInt64(r.Key);

            return res;
        }
        
        public static long Task20_2(string[] input)
        {
            var dict = new Dictionary<string, List<string>>();
            var pieces = new List<PuzzlePiece>();
            foreach (var tile in input)
            {
                var id = tile.Split("\r\n")[0].Split(' ')[1];
                id = id.Replace(":", "");
                var cells = tile.Split("\r\n")[1..].Select(x => x.ToCharArray()).ToArray();
                var edge1 = new string(cells[0]);
                var edge2 = new string(cells.Last());
                var edge3 = new string(new[]
                {
                    cells[0].Last(), cells[1].Last(), cells[2].Last(), cells[3].Last(), cells[4].Last(),
                    cells[5].Last(), cells[6].Last(), cells[7].Last(), cells[8].Last(), cells[9].Last()
                });
                var edge4 = new string(new[]
                {
                    cells[0].First(), cells[1].First(), cells[2].First(), cells[3].First(), cells[4].First(),
                    cells[5].First(), cells[6].First(), cells[7].First(), cells[8].First(), cells[9].First()
                });
                pieces.Add(new PuzzlePiece
                {
                    Id = id,
                    Edges = new[]
                    {
                        edge1, new string(edge1.ToCharArray().Reverse().ToArray()),
                        edge2, new string(edge2.ToCharArray().Reverse().ToArray()),
                        edge3, new string(edge3.ToCharArray().Reverse().ToArray()),
                        edge4, new string(edge4.ToCharArray().Reverse().ToArray()),
                    },
                    Cells = cells
                });

                if (!dict.ContainsKey(edge1)) dict[edge1] = new List<string>();
                dict[edge1].Add(id);

                var edge1Rev = new string(edge1.ToCharArray().Reverse().ToArray());
                if (!dict.ContainsKey(edge1Rev)) dict[edge1Rev] = new List<string>();
                dict[edge1Rev].Add(id);

                if (!dict.ContainsKey(edge2)) dict[edge2] = new List<string>();
                dict[edge2].Add(id);

                var edge2Rev = new string(edge2.ToCharArray().Reverse().ToArray());
                if (!dict.ContainsKey(edge2Rev)) dict[edge2Rev] = new List<string>();
                dict[edge2Rev].Add(id);

                if (!dict.ContainsKey(edge3)) dict[edge3] = new List<string>();
                dict[edge3].Add(id);

                var edge3Rev = new string(edge3.ToCharArray().Reverse().ToArray());
                if (!dict.ContainsKey(edge3Rev)) dict[edge3Rev] = new List<string>();
                dict[edge3Rev].Add(id);

                if (!dict.ContainsKey(edge4)) dict[edge4] = new List<string>();
                dict[edge4].Add(id);

                var edge4Rev = new string(edge4.ToCharArray().Reverse().ToArray());
                if (!dict.ContainsKey(edge4Rev)) dict[edge4Rev] = new List<string>();
                dict[edge4Rev].Add(id);
            }

            var reversed = new Dictionary<string, List<string>>();
            foreach (var s in dict.Where(x => x.Value.Count == 1))
            {
                if (!reversed.ContainsKey(s.Value.First()))
                    reversed[s.Value.First()] = new List<string>();
                reversed[s.Value.First()].Add(s.Key);
            }

            foreach (var s in dict.Where(x => x.Value.Count == 2))
            {
                var bros = pieces.Where(x => x.Edges.Contains(s.Key)).ToList();
                if (bros.Count != 2) throw new Exception("How dare you");
                bros[0].AddNeighbours(bros[1]);
                bros[1].AddNeighbours(bros[0]);
            }

            var totalPiecesOnEdge = (int) Math.Sqrt(input.Length);
            var piecesMap = new PuzzlePiece[totalPiecesOnEdge, totalPiecesOnEdge];

            var topLeftKey = reversed.First(x => x.Value.Count == 4).Key;
            var topLeftPiece = pieces.First(x => x.Id == topLeftKey);

            piecesMap[0, 0] = topLeftPiece;
            var neig0 = topLeftPiece.Neighbours[0];
            var neig1 = topLeftPiece.Neighbours[1];
            for (int i = 0; i < 4; i++)
            {
                if (!neig0.Edges.Contains(topLeftPiece.RightEdge()) || !neig1.Edges.Contains(topLeftPiece.BottomEdge()))
                    topLeftPiece.TurnRight();
                else
                    break;
            }

            if (!neig0.Edges.Contains(topLeftPiece.RightEdge()) || !neig1.Edges.Contains(topLeftPiece.BottomEdge()))
                topLeftPiece.Flip();

            for (int i = 0; i < 4; i++)
            {
                if (!neig0.Edges.Contains(topLeftPiece.RightEdge()) || !neig1.Edges.Contains(topLeftPiece.BottomEdge()))
                    topLeftPiece.TurnRight();
                else
                    break;
            }

            if (!neig0.Edges.Contains(topLeftPiece.RightEdge()))
                throw new Exception("Something is wrong");

            for (int i = 0; i < 4; i++)
            {
                if (topLeftPiece.BottomEdge() != neig1.TopEdge())
                    neig1.TurnRight();
                else
                    break;
            }

            if (topLeftPiece.BottomEdge() != neig1.TopEdge())
                neig1.Flip();

            for (int i = 0; i < 4; i++)
            {
                if (topLeftPiece.BottomEdge() != neig1.TopEdge())
                    neig1.TurnRight();
                else
                    break;
            }

            if (topLeftPiece.BottomEdge() != neig1.TopEdge())
                throw new Exception("Something is wrong");

            for (int i = 1; i < piecesMap.GetLength(0); i++)
            {
                piecesMap[0, i] = GetNextToRight(pieces, piecesMap[0, i - 1]);
            }
            //1st row is done

            var curLeft = neig1;

            for (int ii = 1; ii < Math.Sqrt(input.Length); ii++) //row
            {
                piecesMap[ii, 0] = curLeft;
                for (int i = 1; i < piecesMap.GetLength(0); i++) //column
                    piecesMap[ii, i] = GetNextToRight(pieces, piecesMap[ii, i - 1]);
                curLeft = GetNextToBottom(pieces, curLeft);
            }

            var edgeLengthWithBorders = 10;
            var edgeLengthWithoutBorders = edgeLengthWithBorders - 2;
            var pointsCountWithoutBorders = (int) Math.Sqrt(input.Length) * edgeLengthWithoutBorders;
            var map = new char[pointsCountWithoutBorders, pointsCountWithoutBorders];

            var curX = 0;
            var curY = 0;
            for (int ii = 0; ii < Math.Sqrt(input.Length); ii++) //piecesRow
            {
                curY = 0;

                for (int jj = 0; jj < Math.Sqrt(input.Length); jj++) //piecesColumn
                {
                    for (int i = 0; i < 8; i++)
                    for (int j = 0; j < 8; j++)
                        map[curX + i, curY + j] = piecesMap[ii, jj].Cells[i + 1][j + 1];

                    curY += edgeLengthWithBorders - 2;
                }

                curX += edgeLengthWithBorders - 2;
            }

            var monster = new char[3, 20];
            monster[0, 18] = '#';
            monster[1, 0] = '#';
            monster[1, 5] = '#';
            monster[1, 6] = '#';
            monster[1, 11] = '#';
            monster[1, 12] = '#';
            monster[1, 17] = '#';
            monster[1, 18] = '#';
            monster[1, 19] = '#';
            monster[2, 1] = '#';
            monster[2, 4] = '#';
            monster[2, 7] = '#';
            monster[2, 10] = '#';
            monster[2, 13] = '#';
            monster[2, 16] = '#';

            var foundMonsters = false;

            for (int ii = 0; ii < 3; ii++)
            {
                for (int i = 0; i < map.GetLength(0); i++)
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (IsMonster(map, i, j, monster))
                    {
                        MarkMonster(map, i, j, monster); //monster overlapping is not handled this way
                        foundMonsters = true;
                    }
                }

                if (!foundMonsters)
                    TurnRight(ref map);
                else
                    break;
            }

            if (!foundMonsters)
                Flip(ref map);

            for (int ii = 0; ii < 3; ii++)
            {
                for (int i = 0; i < map.GetLength(0); i++)
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (IsMonster(map, i, j, monster))
                    {
                        MarkMonster(map, i, j, monster); //monster overlapping is not handled this way
                        foundMonsters = true;
                    }
                }

                if (!foundMonsters)
                    TurnRight(ref map);
                else
                    break;
            }

            var res = 0;
            for (int i = 0; i < map.GetLength(0); i++)
            for (int j = 0; j < map.GetLength(1); j++)
            {
                if (map[i,j]=='#')
                    res++;
            }

            return res;
        }

        private static void Flip(ref char[,] map)
        {
            var N = map.GetLength(0);
            var newMatrix = new char[N,N];
            for (var x = 0; x < N; x++)
            for (var y = 0; y < N; y++)
                newMatrix[x,y] = map[x,N - 1 - y];
            
            map = newMatrix;
        }

        private static void TurnRight(ref char[,] map)
        {
            var N = map.GetLength(0);
            var newMatrix = new char[N,N];
            for (var x = 0; x < N; x++)
            for (var y = 0; y < N; y++)
                newMatrix[y,N - 1 - x] = map[x,y];

            map = newMatrix;
        }

        private static bool IsMonster(char[,] map, int i, int j, char[,] monster)
        {
            var mapLength = map.GetLength(0);
            for (int ii = 0; ii < monster.GetLength(0); ii++)
            for (int jj = 0; jj < monster.GetLength(1); jj++)
            {
                if (i + ii >= mapLength) return false;
                if (j + jj >= mapLength) return false;

                if (monster[ii, jj] == '#')
                    if(map[i + ii, j + jj] != '#') 
                        return false;
            }

            return true;
        }

        private static void MarkMonster(char[,] map, int i, int j, char[,] monster)
        {
            for (int ii = 0; ii < monster.GetLength(0); ii++)
            for (int jj = 0; jj < monster.GetLength(1); jj++)
            {
                if (monster[ii, jj] == '#')
                    map[i + ii, j + jj] = 'O';
            }
        }

        private static PuzzlePiece GetNextToBottom(List<PuzzlePiece> pieces, PuzzlePiece top)
        {
            var nextBottom = pieces.FirstOrDefault(x => x.Edges.Contains(top.BottomEdge()) && x!= top);

            if (nextBottom == null) return null;
            
            for (int i = 0; i < 4; i++)
            {
                if (nextBottom.TopEdge() != top.BottomEdge())
                    nextBottom.TurnRight();
                else
                    return nextBottom;
            }
            
            if (nextBottom.TopEdge() != top.BottomEdge())
                nextBottom.Flip();
            
            for (int i = 0; i < 4; i++)
            {
                if (nextBottom.TopEdge() != top.BottomEdge())
                    nextBottom.TurnRight();
                else
                    return nextBottom;
            }

            return null;
        }

        private static PuzzlePiece GetNextToRight(List<PuzzlePiece> pieces, PuzzlePiece left)
        {
            var nextRight = pieces.FirstOrDefault(x => x.Edges.Contains(left.RightEdge()) && x!= left);
            
            for (int i = 0; i < 4; i++)
            {
                if (nextRight.LeftEdge() != left.RightEdge())
                    nextRight.TurnRight();
                else
                    return nextRight;
            }
            
            if (nextRight.LeftEdge() != left.RightEdge())
                nextRight.Flip();
            
            for (int i = 0; i < 4; i++)
            {
                if (nextRight.LeftEdge() != left.RightEdge())
                    nextRight.TurnRight();
                else
                    return nextRight;
            }
            
            throw new Exception("Something is wrong");
        }
    }
}