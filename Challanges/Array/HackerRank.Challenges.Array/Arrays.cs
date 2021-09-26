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


        #region Longest Increasing Subsequence

        // Binary search (note boundaries
        // in the caller) A[] is ceilIndex
        // in the caller
        static int CeilIndex(int[] A, int l,
                             int r, int key)
        {
            while (r - l > 1)
            {
                int m = l + (r - l) / 2;

                if (A[m] >= key)
                    r = m;
                else
                    l = m;
            }

            return r;
        }

        // Array, Binary Search, Dynamic Programming
        // The loop runs for N elements.In the worst case (what is worst case input?), we may end up querying ceil value using binary search(log i) for many A[i].
        // Therefore, T(n) < O(log N! )  = O(N log N). Analyse to ensure that the upper and lower bounds are also O(N log N ). The complexity is THETA(N log N).
        public static int LengthOfLIS(int[] nums)
        {
            // Add boundary case, when array size
            // is one

            int[] tailTable = new int[nums.Length];
            int len; // always points empty slot

            tailTable[0] = nums[0];
            len = 1;
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] < tailTable[0])
                    // new smallest value
                    tailTable[0] = nums[i];

                else if (nums[i] > tailTable[len - 1])

                    // A[i] wants to extend largest
                    // subsequence
                    tailTable[len++] = nums[i];

                else

                    // A[i] wants to be current end
                    // candidate of an existing
                    // subsequence. It will replace
                    // ceil value in tailTable
                    tailTable[CeilIndex(tailTable, -1,
                                        len - 1, nums[i])]
                        = nums[i];
            }

            return len;
        }
        #endregion
    }
}
