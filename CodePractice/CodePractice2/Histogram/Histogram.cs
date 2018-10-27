using System;
using System.Collections.Generic;
using System.Text;

namespace CodePractice2
{
    class Histogram
    {
        public float AreaOfWaterFilled(int[] histogram)
        {
            int refColumn = 0;
            float areaSum = 0;
            int refColumnLength = histogram[refColumn];
            int refBoundrySoFar = 0; //Longest column smaller than the ref column
            int lastColumnLength = histogram[histogram.Length - 1];

            //for (int i = refColumn + 1; i < histogram.Length; i++)
            //{

            //    if (histogram[i] < refColumnLength)
            //    {
            //        areaSum = areaSum + (refColumnLength - histogram[i]);
            //        refBoundrySoFar = refBoundrySoFar > histogram[i] ? refBoundrySoFar : histogram[i];
            //    }
            //    else
            //    {
            //        refColumn = i;
            //        refColumnLength = histogram[refColumn];
            //    }
            //}
            ////Adjust if largetSoFar is less than the refColumn and we have traverserd the whole stack
            //if (refColumnLength > lastColumnLength)
            //{
            //    areaSum = areaSum - (refColumnLength - lastColumnLength) * (histogram.Length - refColumn - 2);
            //}

            //while()

            return areaSum;
        }

        float GetSubArea(int[] histogram, int startIndex, int endIndex, float height)
            {
                float areaSum = 0;
                for(int i=startIndex+1; i<endIndex; i++)
                {
                    areaSum = areaSum + height - histogram[i];
                }
                return areaSum;
            }
    }
}
