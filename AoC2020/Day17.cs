using System.Collections.Generic;

namespace AoC2020
{
    public static class Day17
    {
        public static int Task17_2(List<string> input)
        {
            var turns = 6;
            var finalLength = input.Count + turns * 2;
            char[,,,] field = new char[finalLength,finalLength,finalLength,finalLength];
            
            for (int i = 0; i < finalLength; i++)
            for (int j = 0; j < finalLength; j++)
            for (int z = 0; z < finalLength; z++)
            for (int w = 0; w < finalLength; w++)
            {
                field[i,j,z,w] = '.';
            }

            var offset = turns;
            for (int i = 0; i < input.Count; i++)
            for (int j = 0; j < input.Count; j++)
            for (int w = 0; w < input.Count; w++)
            {
                field[i+offset,j+offset,offset,offset] = input[i][j];
            }

            var lastState = (char[,,,]) field.Clone();
            
            for (int x = 0; x < turns; x++)
            {
                var newState = (char[,,,]) lastState.Clone();

                for (int i = 0; i < finalLength; i++)
                for (int j = 0; j < finalLength; j++)
                for (int z = 0; z < finalLength; z++)
                for (int w = 0; w < finalLength; w++)
                {
                    var neigh = 0;
                    if (HasNeighbour(i, j, z,w, 0, 0, 0,-1, lastState, finalLength)) neigh++;
                    if (HasNeighbour(i, j, z,w, 0, 0, 0,1, lastState, finalLength)) neigh++;
                    if (HasNeighbour(i, j, z,w, 0, 0, -1,0, lastState, finalLength)) neigh++;
                    if (HasNeighbour(i, j, z,w, 0, 0, -1,-1, lastState, finalLength)) neigh++;
                    if (HasNeighbour(i, j, z,w, 0, 0, -1,1, lastState, finalLength)) neigh++;
                    if (HasNeighbour(i, j, z,w, 0, 0, 1,0, lastState, finalLength)) neigh++;
                    if (HasNeighbour(i, j, z,w, 0, 0, 1,-1, lastState, finalLength)) neigh++;
                    if (HasNeighbour(i, j, z,w, 0, 0, 1,1, lastState, finalLength)) neigh++;
                    if (HasNeighbour(i, j, z,w, 0, -1, -1,-1, lastState, finalLength)) neigh++;
                    if (HasNeighbour(i, j, z,w, 0, -1, -1,0, lastState, finalLength)) neigh++;
                    if (HasNeighbour(i, j, z,w, 0, -1, -1,1, lastState, finalLength)) neigh++;
                    if (HasNeighbour(i, j, z,w, 0, -1, 0,-1, lastState, finalLength)) neigh++;
                    if (HasNeighbour(i, j, z,w, 0, -1, 0,0, lastState, finalLength)) neigh++;
                    if (HasNeighbour(i, j, z,w, 0, -1, 0,1, lastState, finalLength)) neigh++;
                    if (HasNeighbour(i, j, z,w, 0, -1, 1,-1, lastState, finalLength)) neigh++;
                    if (HasNeighbour(i, j, z,w, 0, -1, 1,0, lastState, finalLength)) neigh++;
                    if (HasNeighbour(i, j, z,w, 0, -1, 1,1, lastState, finalLength)) neigh++;
                    if (HasNeighbour(i, j, z,w, 0, 1, 0,-1, lastState, finalLength)) neigh++;
                    if (HasNeighbour(i, j, z,w, 0, 1, 0,0, lastState, finalLength)) neigh++;
                    if (HasNeighbour(i, j, z,w, 0, 1, 0,1, lastState, finalLength)) neigh++;
                    if (HasNeighbour(i, j, z,w, 0, 1, -1,0, lastState, finalLength)) neigh++;
                    if (HasNeighbour(i, j, z,w, 0, 1, -1,-1, lastState, finalLength)) neigh++;
                    if (HasNeighbour(i, j, z,w, 0, 1, -1,1, lastState, finalLength)) neigh++;
                    if (HasNeighbour(i, j, z,w, 0, 1, 1,0, lastState, finalLength)) neigh++;
                    if (HasNeighbour(i, j, z,w, 0, 1, 1,-1, lastState, finalLength)) neigh++;
                    if (HasNeighbour(i, j, z,w, 0, 1, 1,1, lastState, finalLength)) neigh++;
                    
                    if (HasNeighbour(i, j, z,w, -1, 0, 0,-1, lastState, finalLength)) neigh++;
                    if (HasNeighbour(i, j, z,w, -1, 0, 0,0, lastState, finalLength)) neigh++;
                    if (HasNeighbour(i, j, z,w, -1, 0, 0,1, lastState, finalLength)) neigh++;
                    if (HasNeighbour(i, j, z,w, -1, 0, -1,0, lastState, finalLength)) neigh++;
                    if (HasNeighbour(i, j, z,w, -1, 0, -1,-1, lastState, finalLength)) neigh++;
                    if (HasNeighbour(i, j, z,w, -1, 0, -1,1, lastState, finalLength)) neigh++;
                    if (HasNeighbour(i, j, z,w, -1, 0, 1,0, lastState, finalLength)) neigh++;
                    if (HasNeighbour(i, j, z,w, -1, 0, 1,-1, lastState, finalLength)) neigh++;
                    if (HasNeighbour(i, j, z,w, -1, 0, 1,1, lastState, finalLength)) neigh++;
                    if (HasNeighbour(i, j, z,w, -1, -1, -1,-1, lastState, finalLength)) neigh++;
                    if (HasNeighbour(i, j, z,w, -1, -1, -1,0, lastState, finalLength)) neigh++;
                    if (HasNeighbour(i, j, z,w, -1, -1, -1,1, lastState, finalLength)) neigh++;
                    if (HasNeighbour(i, j, z,w, -1, -1, 0,-1, lastState, finalLength)) neigh++;
                    if (HasNeighbour(i, j, z,w, -1, -1, 0,0, lastState, finalLength)) neigh++;
                    if (HasNeighbour(i, j, z,w, -1, -1, 0,1, lastState, finalLength)) neigh++;
                    if (HasNeighbour(i, j, z,w, -1, -1, 1,-1, lastState, finalLength)) neigh++;
                    if (HasNeighbour(i, j, z,w, -1, -1, 1,0, lastState, finalLength)) neigh++;
                    if (HasNeighbour(i, j, z,w, -1, -1, 1,1, lastState, finalLength)) neigh++;
                    if (HasNeighbour(i, j, z,w, -1, 1, 0,-1, lastState, finalLength)) neigh++;
                    if (HasNeighbour(i, j, z,w, -1, 1, 0,0, lastState, finalLength)) neigh++;
                    if (HasNeighbour(i, j, z,w, -1, 1, 0,1, lastState, finalLength)) neigh++;
                    if (HasNeighbour(i, j, z,w, -1, 1, -1,0, lastState, finalLength)) neigh++;
                    if (HasNeighbour(i, j, z,w, -1, 1, -1,-1, lastState, finalLength)) neigh++;
                    if (HasNeighbour(i, j, z,w, -1, 1, -1,1, lastState, finalLength)) neigh++;
                    if (HasNeighbour(i, j, z,w, -1, 1, 1,0, lastState, finalLength)) neigh++;
                    if (HasNeighbour(i, j, z,w, -1, 1, 1,-1, lastState, finalLength)) neigh++;
                    if (HasNeighbour(i, j, z,w, -1, 1, 1,1, lastState, finalLength)) neigh++;
                    
                    if (HasNeighbour(i, j, z,w, 1, 0, 0,-1, lastState, finalLength)) neigh++;
                    if (HasNeighbour(i, j, z,w, 1, 0, 0,0, lastState, finalLength)) neigh++;
                    if (HasNeighbour(i, j, z,w, 1, 0, 0,1, lastState, finalLength)) neigh++;
                    if (HasNeighbour(i, j, z,w, 1, 0, -1,0, lastState, finalLength)) neigh++;
                    if (HasNeighbour(i, j, z,w, 1, 0, -1,-1, lastState, finalLength)) neigh++;
                    if (HasNeighbour(i, j, z,w, 1, 0, -1,1, lastState, finalLength)) neigh++;
                    if (HasNeighbour(i, j, z,w, 1, 0, 1,0, lastState, finalLength)) neigh++;
                    if (HasNeighbour(i, j, z,w, 1, 0, 1,-1, lastState, finalLength)) neigh++;
                    if (HasNeighbour(i, j, z,w, 1, 0, 1,1, lastState, finalLength)) neigh++;
                    if (HasNeighbour(i, j, z,w, 1, -1, -1,-1, lastState, finalLength)) neigh++;
                    if (HasNeighbour(i, j, z,w, 1, -1, -1,0, lastState, finalLength)) neigh++;
                    if (HasNeighbour(i, j, z,w, 1, -1, -1,1, lastState, finalLength)) neigh++;
                    if (HasNeighbour(i, j, z,w, 1, -1, 0,-1, lastState, finalLength)) neigh++;
                    if (HasNeighbour(i, j, z,w, 1, -1, 0,0, lastState, finalLength)) neigh++;
                    if (HasNeighbour(i, j, z,w, 1, -1, 0,1, lastState, finalLength)) neigh++;
                    if (HasNeighbour(i, j, z,w, 1, -1, 1,-1, lastState, finalLength)) neigh++;
                    if (HasNeighbour(i, j, z,w, 1, -1, 1,0, lastState, finalLength)) neigh++;
                    if (HasNeighbour(i, j, z,w, 1, -1, 1,1, lastState, finalLength)) neigh++;
                    if (HasNeighbour(i, j, z,w, 1, 1, 0,-1, lastState, finalLength)) neigh++;
                    if (HasNeighbour(i, j, z,w, 1, 1, 0,0, lastState, finalLength)) neigh++;
                    if (HasNeighbour(i, j, z,w, 1, 1, 0,1, lastState, finalLength)) neigh++;
                    if (HasNeighbour(i, j, z,w, 1, 1, -1,0, lastState, finalLength)) neigh++;
                    if (HasNeighbour(i, j, z,w, 1, 1, -1,-1, lastState, finalLength)) neigh++;
                    if (HasNeighbour(i, j, z,w, 1, 1, -1,1, lastState, finalLength)) neigh++;
                    if (HasNeighbour(i, j, z,w, 1, 1, 1,0, lastState, finalLength)) neigh++;
                    if (HasNeighbour(i, j, z,w, 1, 1, 1,-1, lastState, finalLength)) neigh++;
                    if (HasNeighbour(i, j, z,w, 1, 1, 1,1, lastState, finalLength)) neigh++;

                    if (lastState[i,j,z,w] == '#' && neigh != 2 && neigh != 3) newState[i,j,z,w]='.';
                    if (lastState[i, j, z,w] == '.' && neigh == 3) newState[i, j, z,w] = '#';
                }
                lastState = (char[,,,]) newState.Clone();
                var total = GetTotal(lastState, finalLength);
            }

            return GetTotal(lastState, finalLength);
        }

        public static int Task17_1(List<string> input)
        {
            var turns = 6;
            var finalLength = input.Count + turns * 2;
            char[,,] field = new char[finalLength,finalLength,finalLength];
            
            for (int i = 0; i < finalLength; i++)
            for (int j = 0; j < finalLength; j++)
            for (int z = 0; z < finalLength; z++)
            {
                field[i,j,z] = '.';
            }

            var offset = turns;
            for (int i = 0; i < input.Count; i++)
            for (int j = 0; j < input.Count; j++)
            {
                field[i+offset,j+offset,offset] = input[i][j];
            }

            var lastState = (char[,,]) field.Clone();
            
            for (int x = 0; x < turns; x++)
            {
                var newState = (char[,,]) lastState.Clone();

                for (int i = 0; i < finalLength; i++)
                for (int j = 0; j < finalLength; j++)
                for (int z = 0; z < finalLength; z++)
                {
                    var neigh = 0;
                    if (HasNeighbour(i, j, z, -1, -1, 0, lastState, finalLength)) neigh++;
                    if (HasNeighbour(i, j, z, -1, 0, 0, lastState, finalLength)) neigh++;
                    if (HasNeighbour(i, j, z, -1, 1, 0, lastState, finalLength)) neigh++;
                    if (HasNeighbour(i, j, z, 0, 1, 0, lastState, finalLength)) neigh++;
                    if (HasNeighbour(i, j, z, 1, 1, 0, lastState, finalLength)) neigh++;
                    if (HasNeighbour(i, j, z, 1, 0, 0, lastState, finalLength)) neigh++;
                    if (HasNeighbour(i, j, z, 1, -1, 0, lastState, finalLength)) neigh++;
                    if (HasNeighbour(i, j, z, 0, -1, 0, lastState, finalLength)) neigh++;
                    
                    if (HasNeighbour(i, j, z, -1, -1, -1, lastState, finalLength)) neigh++;
                    if (HasNeighbour(i, j, z, -1, 0, -1, lastState, finalLength)) neigh++;
                    if (HasNeighbour(i, j, z, -1, 1, -1, lastState, finalLength)) neigh++;
                    if (HasNeighbour(i, j, z, 0, 1, -1, lastState, finalLength)) neigh++;
                    if (HasNeighbour(i, j, z, 1, 1, -1, lastState, finalLength)) neigh++;
                    if (HasNeighbour(i, j, z, 1, 0, -1, lastState, finalLength)) neigh++;
                    if (HasNeighbour(i, j, z, 1, -1, -1, lastState, finalLength)) neigh++;
                    if (HasNeighbour(i, j, z, 0, -1, -1, lastState, finalLength)) neigh++;
                    if (HasNeighbour(i, j, z, 0, 0, -1, lastState, finalLength)) neigh++;

                    if (HasNeighbour(i, j, z, -1, -1, 1, lastState, finalLength)) neigh++;
                    if (HasNeighbour(i, j, z, -1, 0, 1, lastState, finalLength)) neigh++;
                    if (HasNeighbour(i, j, z, -1, 1, 1, lastState, finalLength)) neigh++;
                    if (HasNeighbour(i, j, z, 0, 1, 1, lastState, finalLength)) neigh++;
                    if (HasNeighbour(i, j, z, 1, 1, 1, lastState, finalLength)) neigh++;
                    if (HasNeighbour(i, j, z, 1, 0, 1, lastState, finalLength)) neigh++;
                    if (HasNeighbour(i, j, z, 1, -1, 1, lastState, finalLength)) neigh++;
                    if (HasNeighbour(i, j, z, 0, -1, 1, lastState, finalLength)) neigh++;
                    if (HasNeighbour(i, j, z, 0, 0, 1, lastState, finalLength)) neigh++;

                    if (lastState[i,j,z] == '#' && neigh != 2 && neigh != 3) newState[i,j,z]='.';
                    if (lastState[i, j, z] == '.' && neigh == 3) newState[i, j, z] = '#';
                }
                lastState = (char[,,]) newState.Clone();
                var total = GetTotal(lastState, finalLength);
            }

            return GetTotal(lastState, finalLength);
        }

        private static int GetTotal(char[,,,] lastState, int finalLength)
        {
            var total = 0;
            for (int i = 0; i < finalLength; i++)
            for (int j = 0; j < finalLength; j++)
            for (int z = 0; z < finalLength; z++)
            for (int w = 0; w < finalLength; w++)
                if (lastState[i,j,z,w] == '#') total++;

            return total;
        }

        private static int GetTotal(char[,,] lastState, int finalLength)
        {
            var total = 0;
            for (int i = 0; i < finalLength; i++)
            for (int j = 0; j < finalLength; j++)
            for (int z = 0; z < finalLength; z++)
                if (lastState[i,j,z] == '#') total++;

            return total;
        }

        private static bool HasNeighbour(int curRow, int curCol, int curDeep, int curW, int rowDir, int colDir, int deepDir, int wDir, char[,,,] lastState, int len)
        {
            if (rowDir+curRow<0 ||
                rowDir+curRow>=len ||
                colDir+curCol<0 ||
                colDir+curCol>=len ||
                deepDir+curDeep<0 ||
                deepDir+curDeep>=len ||
                curW+wDir<0 ||
                curW+wDir>=len)
                return false;
            if (lastState[rowDir+curRow,colDir+curCol,deepDir+curDeep,curW+wDir] == '#') return true;
            return false;
        }

        private static bool HasNeighbour(int curRow, int curCol, int curDeep, int rowDir, int colDir, int deepDir, char[,,] lastState, int len)
        {
            if (rowDir+curRow<0 ||
                rowDir+curRow>=len ||
                colDir+curCol<0 ||
                colDir+curCol>=len ||
                deepDir+curDeep<0 ||
                deepDir+curDeep>=len)
                return false;
            if (lastState[rowDir+curRow,colDir+curCol,deepDir+curDeep] == '#') return true;
            return false;
        }
    }
}