using System;
using System.Collections.Generic;

namespace CodePractice
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("             Welcome to coding Practice!\n");
            Console.WriteLine("\n************************************************************\n");

            MatrixTest.ElementExistsInSortedMatrix();

            ArrayQTest.TestFindIntersectingElements();

            BTreeTest.BuildBTreeFromTwoTraversals();

            Console.Read();
        }
    }
}