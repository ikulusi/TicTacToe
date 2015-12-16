using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ticTacToe.Logic
{
    public class Matrix
    {
        int[,] matrix = new int[3, 3];
        int[] path = new int[12];
        int pathCounter;
       

        public Matrix()
        {
            Reset();
        }

        public bool IsRowFull(int i)
        {
            if (matrix[i, 0] == matrix[i, 1] && matrix[i, 0] == matrix[i, 2] && matrix[i, 0] != 0)
            {
                path[pathCounter++] = i; path[pathCounter++] = 0;
                path[pathCounter++] = i; path[pathCounter++] = 1;
                path[pathCounter++] = i; path[pathCounter++] = 2;
                return true;
            }
            else return false;
        }

        public void Reset()
        {
            for (int i = 0; i < 3; ++i)
                for (int j = 0; j < 3; ++j)
                    matrix[i, j] = 0;
            for (int i = 0; i < 12; ++i)
                path[i] = -1;
            pathCounter = 0;
        }

        public bool IsColumnFull(int i)
        {
            if (matrix[0, i] == matrix[1, i] && matrix[0, i] == matrix[2, i] && matrix[0, i] != 0)
            {
                path[pathCounter++] = 0; path[pathCounter++] = i;
                path[pathCounter++] = 1; path[pathCounter++] = i;
                path[pathCounter++] = 2; path[pathCounter++] = i;
                return true;
            }
            else return false;
        }

        public bool IsDiagonalFull()
        {
            if ((matrix[0, 0] == matrix[1, 1] && matrix[1, 1] == matrix[2, 2] && matrix[0, 0] != 0) )
            {
                path[pathCounter++] = 0; path[pathCounter++] = 0;
                path[pathCounter++] = 1; path[pathCounter++] = 1;
                path[pathCounter++] = 2; path[pathCounter++] = 2;
                return true;
            }

            else return false;
        }

        public bool IsReversedDiagonalFull()
        {
            if ((matrix[0, 2] == matrix[1, 1] && matrix[1, 1] == matrix[2, 0] && matrix[1, 1] != 0))
            {
                path[pathCounter++] = 0; path[pathCounter++] = 2;
                path[pathCounter++] = 1; path[pathCounter++] = 1;
                path[pathCounter++] = 2; path[pathCounter++] = 0;
                return true;
            }
            else return false;
        }

        public bool IsWin(int i, int j)
        {
            bool win = false;
            /* 
            pozivam za svaku funkciju posebno jer se ovako zaustavi izvrsavanje cim je jedna f-ja prosla, a trebaju se sve
            izvrsit da bi se ispunio path
                if (IsColumnFull(j) || IsRowFull(i) || IsDiagonalFull() || IsReversedDiagonalFull() ) return true;
            */
            if (IsColumnFull(j)) win = true;
            if (IsRowFull(i)) win = true;
            if (IsDiagonalFull()) win = true;
            if (IsReversedDiagonalFull()) win = true;


            return win;
        }

        public int element(int i, int j)
        {
            return matrix[i, j];
        }

        public void set(int i, int j, string player)
        {
            if (player == "o") matrix[i, j] = 1;
            else matrix[i, j] = 2;
        }

        public bool HasSomebodyWon()
        {
            for (int i = 0; i < 2; ++i)
                for (int j = 0; j < 2; ++j)
                    if (IsWin(i, j)) return true;
            return false;
        }

        public int[] WiningPath()
        {
            return path;
        } 

              
    }
}
