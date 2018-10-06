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
    }

    public class ArrayQTest
    {
        public static void TestFindIntersectingElements()
        {
            int[] A1 = { 1, 2, 4, 5, 6, 6, 10, 12 };
            int[] A2 = {2,4,5,6,6,7,8 };
            int[] A3 = { 2,2,6,6,6,9,10,11,12};
            List<int> result = ArrayQ.FindIntersectingElements(A1, A2, A3);
            if(result!=null)
            {
                Console.WriteLine("Intersecting Items are : ");
                foreach (var item in result)
                {
                    Console.Write(item.ToString() + " ");
                }
            }
            
        }
    }
}
