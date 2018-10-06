using System;
using System.Collections.Generic;

namespace CodePractice
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //Matrix m = new Matrix();
            //List<int> intList = new List<int>() { 2, 3, 5, 10, 11 };
            //foreach (var item in intList)
            //{
            //    Position P = m.GetPositionOfElelment(m.GenerateMatrix(),4,4, item);
            //    if (P.x == -1 || P.y == -1)
            //    {
            //        Console.WriteLine("Element {0} does not exist in the matrix",item);
            //    }
            //    else
            //    {
            //        Console.WriteLine("Element {0} exists at index  row ={1}, column ={2}", item, P.x, P.y);
            //    }
            //}

            //Histogram Water Collection
            //Histogram hist = new Histogram();
            //Console.WriteLine( "Total water area is "+ hist.AreaOfWaterFilled(new int[] { 10, 2, 1, 6, 5, 8 ,2,4}).ToString());

            ArrayQTest.TestFindIntersectingElements();

            Console.Read();
        }
    }
}