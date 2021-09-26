using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Interview.Challenges
{
    public static class Arrays
    {
        /*
         * Complete the 'rotLeft' function below.
         *
         * The function is expected to return an INTEGER_ARRAY.
         * The function accepts following parameters:
         *  1. INTEGER_ARRAY a
         *  2. INTEGER d
         */

        public static List<int> rotLeft(List<int> a, int d)
        {
            List<int> response = new List<int>();

            for (int x = d; x < a.Count(); x++)
            {
                response.Add(a[x]);
            }

            for (int x = 0; x < d; x++)
            {
                response.Add(a[x]);
            }

            return response;
        }

        /*
 * Complete the 'minimumBribes' function below.
 *
 * The function accepts INTEGER_ARRAY q as parameter.
 */

        public static void minimumBribes(List<int> q)
        {
            int bribe = 0;
            bool chaotic = false;
            int n = q.Count();
            for (int i = 0; i < n; i++)
            {
                if (q[i] - (i + 1) > 2)
                {
                    chaotic = true;
                    break;
                }
                for (int j = Math.Max(0, q[i] - 2); j < i; j++)
                    if (q[j] > q[i])
                        bribe++;
            }
            if (chaotic)
                Console.WriteLine("Too chaotic");
            else
                Console.WriteLine(bribe);
        }

        // Complete the minimumSwaps function below.
        public static int minimumSwaps(int[] arr)
        {
            //int response = 0;
            //int temp = 0;
            //for (int x = 0; x < arr.Count(); x++)
            //{
            //    if (x == arr.Count() - 1)
            //    {
            //        break;
            //    }

            //    if (arr[x] > arr[x + 1])
            //    {
            //        for (int y = x + 1; y < arr.Count(); y++)
            //        {
            //            if (arr[x] > arr[y])
            //            {
            //                temp = arr[y-1];
            //                arr[y-1] = arr[y];
            //                arr[y] = temp;
            //            }
            //        }

            //        response++;
            //        x = -1;
            //    }
            //}
            //return response;
            int numSwaps = 0;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                int curVal = arr[i];
                while (curVal != i + 1)
                {
                    //Swap curVal to where it correctly belongs,
                    //and hold on to the value that it replaced.
                    int temp = arr[curVal - 1];
                    arr[curVal - 1] = curVal;
                    curVal = temp;
                    numSwaps++;
                }
            }
            return numSwaps;


        }
    }
}
