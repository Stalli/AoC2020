using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC2020
{
    public class PuzzlePiece
    {
        public string Id { get; set; }
        public char[][] Cells { get; set; }
        public string[] Edges { get; set; }
        
        public List<PuzzlePiece> Neighbours { get; set; }

        public PuzzlePiece()
        {
            Neighbours=new List<PuzzlePiece>();
        }

        public void AddNeighbours(PuzzlePiece bro)
        {
            if (Neighbours.Any(x => x.Id == bro.Id)) return;
            
            Neighbours.Add(bro);
        }

        public string RightEdge()
        {
            var res = "";
            for (int i = 0; i < Cells.Length; i++)
                res+=Cells[i].Last();
            return res;
        }
        
        public string LeftEdge()
        {
            var res = "";
            for (int i = 0; i < Cells.Length; i++)
                res+=Cells[i].First();
            return res;
        }
        
        public string TopEdge()
        {
            return new string(Cells.First());
        }
        
        public string BottomEdge()
        {
            return new string(Cells.Last());
        }

        public void TurnRight()
        {
            var N = Cells.GetLength(0);
            var newMatrix = new char[N][];
            for (int i = 0; i < N; i++)
            {
                newMatrix[i] = new char[N];
            }
            for (var x = 0; x < N; x++)
            for (var y = 0; y < N; y++)
                newMatrix[y][N - 1 - x] = Cells[x][y];

            Cells = newMatrix;
        }

        public void Flip()
        {
            var N = Cells.GetLength(0);
            var newMatrix = new char[N][];
            for (int i = 0; i < N; i++)
            {
                newMatrix[i] = new char[N];
            }
            for (var x = 0; x < N; x++)
            for (var y = 0; y < N; y++)
                newMatrix[x][y] = Cells[x][N - 1 - y];
            
            Cells = newMatrix;
        }
    }
}