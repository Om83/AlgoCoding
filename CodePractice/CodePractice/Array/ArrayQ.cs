using System;
using System.Collections.Generic;
using System.Text;

namespace CodePractice
{
    class ArrayQ
    {
        public static List<int> FindIntersectingElements(int [] A1, int[] A2, int[] A3)
        {
            int A1Pointer = 0;
            int A2Pointer = 0;
            int A3Pointer = 0;
            int A1Max = A1.Length - 1;
            int A2Max = A2.Length - 1;
            int A3Max = A3.Length - 1;

            List<int> result= new List<int>();
            while (A1Pointer!=A1Max && A2Pointer!=A2Max && A3Pointer!=A3Max)
            {
                //if all point values are equal add to array else move the move the lowest value pointer
                if(A1[A1Pointer]==A2[A2Pointer] && A1[A1Pointer]==A3[A3Pointer])
                {
                    result.Add(A1[A1Pointer]);
                    A1Pointer++;
                    A2Pointer++;
                    A3Pointer++;
                    continue;
                }
                else
                {
                    if (A1[A1Pointer] <= A2[A2Pointer] && A1[A1Pointer] <= A3[A3Pointer])
                        A1Pointer++;
                    else if (A2[A2Pointer] <= A1[A1Pointer] && A2[A2Pointer] <= A3[A3Pointer])
                        A2Pointer++;
                    else if (A3[A3Pointer] <= A1[A1Pointer] && A3[A3Pointer] <= A2[A2Pointer])
                        A3Pointer++;
                }
            }

            return result;
        }

        public static void PrintArray<T>( T[] array, string arrayName)
        {
            Console.Write(arrayName+" = {");
            int i = 0;
            int iMax = array.Length-1;
            foreach (var item in array)
            {
                Console.Write(item.ToString());
                Console.Write((i++ == iMax) ? "" : ",");
            }
            Console.WriteLine("}");
        }
    }

    public class ArrayQTest
    {
        public static void TestFindIntersectingElements()
        {
            int[] A1 = { 1, 2, 4, 5, 6, 6, 10, 12 };
            int[] A2 = {2,4,5,6,6,7,8 };
            int[] A3 = { 2,2,6,6,6,9,10,11,12};
            Console.WriteLine("Input Arrays are : ");
            ArrayQ.PrintArray(A1,"A1");
            ArrayQ.PrintArray(A2,"A2");
            ArrayQ.PrintArray(A3,"A3");


            List<int> result = ArrayQ.FindIntersectingElements(A1, A2, A3);
            if(result!=null)
            {
                Console.Write("\nIntersecting Items are : ");
                foreach (var item in result)
                {
                    Console.Write(item.ToString() + " ");
                }
            }
            Console.WriteLine("\n\n************************************************************\n");
            
        }
    }
}
