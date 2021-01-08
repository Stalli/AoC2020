using System.Linq;

namespace AoC2020
{
    public static class Day11
    {
        public static int Task11_1(string[] input)
        {
            var changedLastRound = 0;
            var lastState = (string[]) input.Clone();

            do
            {
                var newState = (string[]) lastState.Clone();
                changedLastRound = 0;
                for (int i = 0; i < input.Length; i++)
                for (int j = 0; j < input[0].Length; j++)
                {
                    var occNeig = 0;
                    if (i-1>=0 && j-1>=0 && lastState[i - 1][j - 1] == '#') occNeig++;
                    if (i-1>=0 && lastState[i - 1][j] == '#') occNeig++;
                    if (i-1>=0 && j+1<input[0].Length && lastState[i - 1][j+1] == '#') occNeig++;
                    if (j+1<input[0].Length && lastState[i][j+1] == '#') occNeig++;
                    if (i+1<input.Length && j+1<input[0].Length && lastState[i+1][j+1] == '#') occNeig++;
                    if (i+1<input.Length && lastState[i+1][j] == '#') occNeig++;
                    if (i+1<input.Length && j-1>=0 && lastState[i+1][j-1] == '#') occNeig++;
                    if (j-1>=0 && lastState[i][j-1] == '#') occNeig++;

                    if (lastState[i][j] == 'L' && occNeig == 0)
                    {
                        newState[i]=newState[i].Remove(j,1).Insert(j,"#");
                        changedLastRound++;
                    }

                    if (lastState[i][j] == '#' && occNeig >= 4)
                    {
                        newState[i]=newState[i].Remove(j,1).Insert(j,"L");
                        changedLastRound++;
                    }
                }
                
                lastState = (string[]) newState.Clone();
            } while (changedLastRound>0);

            return lastState.Sum(x => x.Count(y => y == '#'));
        }
        
        public static int Task11_2(string[] input)
        {
            var changedLastRound = 0;
            var lastState = (string[]) input.Clone();

            do
            {
                var newState = (string[]) lastState.Clone();
                changedLastRound = 0;
                for (int i = 0; i < input.Length; i++)
                for (int j = 0; j < input[0].Length; j++)
                {
                    var occNeig = 0;
                    if (HasNeighbour(-1,-1,i,j, lastState)) occNeig++;
                    if (HasNeighbour(-1,0,i,j, lastState)) occNeig++;
                    if (HasNeighbour(-1,1,i,j, lastState)) occNeig++;
                    if (HasNeighbour(0,1,i,j, lastState)) occNeig++;
                    if (HasNeighbour(1,1,i,j, lastState)) occNeig++;
                    if (HasNeighbour(1,0,i,j, lastState)) occNeig++;
                    if (HasNeighbour(1,-1,i,j, lastState)) occNeig++;
                    if (HasNeighbour(0,-1,i,j, lastState)) occNeig++;
                    
                    if (lastState[i][j] == 'L' && occNeig == 0)
                    {
                        newState[i]=newState[i].Remove(j,1).Insert(j,"#");
                        changedLastRound++;
                    }

                    if (lastState[i][j] == '#' && occNeig >= 5)
                    {
                        newState[i]=newState[i].Remove(j,1).Insert(j,"L");
                        changedLastRound++;
                    }
                }
                
                lastState = (string[]) newState.Clone();
            } while (changedLastRound>0);

            return lastState.Sum(x => x.Count(y => y == '#'));
        }

        private static bool HasNeighbour(int rowDir, int colDir, int curRow, int curCol, string[] lastState)
        {
            var curNeighI = curRow;
            var curNeighJ = curCol;
            do
            {
                curNeighI += rowDir;
                curNeighJ += colDir;

                if (curNeighI<0 ||
                    curNeighI>=lastState.Length ||
                    curNeighJ<0 ||
                    curNeighJ>=lastState[0].Length)
                    return false;
                if (lastState[curNeighI][curNeighJ] == '#') return true;
                if (lastState[curNeighI][curNeighJ] == 'L') return false;
            } while (true);
        }
    }
}