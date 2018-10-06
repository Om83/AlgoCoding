using System;
using System.Collections.Generic;
using System.Text;

namespace CodePractice
{
    struct Position
    {
        public int x;
        public int y;
    }
    class Matrix
    {
        /// <summary>
        /// Sorted Martix in terms of Row and Column
        /// </summary>
        /// <returns></returns>
        public int[,] GenerateMatrix()
        {
            return new int[,] { { 1,4,7,15},
                                {3,5,10,16 },
                                {6,8,11,18 },
                                {12,14,19,22 }};

        }

        public Position GetPositionOfElelment(int [,] mat, int rows, int columns, int element)
        {
            Position pos = new Position();
            pos.x = -1;
            pos.y = -1;

            int rowMaxIndex = rows-1;
            int colMaxIndex = columns-1;
            int column = colMaxIndex;
            int row = rowMaxIndex;
            while (column > -1 && row >-1)
            {
                //Find row for the potentional element
                if (element < mat[row, 0] && row >= 1)
                {
                    row--;
                    continue;
                }
                else if (element < mat[0, column])
                {
                    column--;
                }
                else
                    break;
            }
            if (mat[row, column] == element)
            {
                pos.x = row;
                pos.y = column;
            }
            else if(row>0 && column>0)
            {
                pos = GetPositionOfElelment(mat, row+1, column+1, element);
            }

            return pos;

        }
    }
}
