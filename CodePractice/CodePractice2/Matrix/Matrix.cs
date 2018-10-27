using System;
using System.Collections.Generic;
using System.Text;

namespace CodePractice2
{
    struct Position
    {
        public int x;
        public int y;
    }
    class Matrix
    {
        public int[,] matrix;
        public Matrix(int [,] matrix)
        {
            this.matrix = matrix;
        }

        public static void PrintMatrix(Matrix m)
        {
            Console.WriteLine("Given Matrix is : ");
            int rowCount = m.matrix.GetLength(0);
            int colCount = m.matrix.GetLength(1);

            for (int i = 0; i < rowCount; i++)
            {
                Console.Write("                 ");
                for (int j = 0; j < colCount; j++)
                {
                    Console.Write(m.matrix[i,j]);
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public Position GetPositionOfElelment(Matrix mat,int element)
        {
            Position pos = new Position();
            pos.x = -1;
            pos.y = -1;

            int rowMaxIndex = mat.matrix.GetLength(0)-1;
            int colMaxIndex = mat.matrix.GetLength(1) - 1;
            int column = colMaxIndex;
            int row = 0;// rowMaxIndex;
            int value;

            //Start from top right corner. There are three posibilities 
            //(a) right corner is the element
            //(b) We can eliminate a row
            //(c) We can eliminate a column
            while(row<=rowMaxIndex && column>-1)
            {
                value = mat.matrix[row, column];
                if (element == value)
                {
                    pos.x = row;
                    pos.y = column;
                    return pos;
                }

                else if (element < value)
                {
                    column--;
                }
                else
                {
                    row++;
                }
            }
            return pos;
        }
    }

    public static class MatrixTest
    {
        public static void ElementExistsInSortedMatrix()
        {
            //Sorted matrix
            Matrix m = new Matrix(new int[,] { 
                                { 1,4,7,15},
                                {3,5,10,16 },
                                {6,8,11,18 },
                                {12,14,19,22 }});
            Matrix.PrintMatrix(m);
            List<int> intList = new List<int>() { 2, 3, 5, 10, 11 };
            foreach (var item in intList)
            {
                
                Position P = m.GetPositionOfElelment(m, item);
                if (P.x == -1 || P.y == -1)
                {
                    Console.WriteLine("Element {0} does not exist in the matrix", item);
                }
                else
                {
                    Console.WriteLine("Element {0} exists at index  row ={1}, column ={2}", item, P.x, P.y);
                }
            }

            Console.WriteLine("\n************************************************************\n");
        }
    }
}
