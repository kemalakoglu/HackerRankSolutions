using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.DataStructure.Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            CallReverseArray();
            CallHourclass();
            CallDynamicArray();
            CallSparseArrays();
        }

        #region CallingMethods
        private static void CallReverseArray()
        {
            int[] a = new int[4];
            a[0] = 1;
            a[1] = 2;
            a[2] = 3;
            a[3] = 4;

            reverseArray(a);
        }
        private static void CallHourclass()
        {
            int[][] arr = new int[6][];

            for (int i = 0; i < 6; i++)
            {
                arr[i] = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp));
            }

            int result = hourglassSum(arr);
            Console.WriteLine(result);
        }
        private static void CallDynamicArray()
        {
            //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            string[] nq = Console.ReadLine().TrimEnd().Split(' ');

            int n = Convert.ToInt32(nq[0]);

            int q = Convert.ToInt32(nq[1]);

            List<List<int>> queries = new List<List<int>>();

            for (int i = 0; i < q; i++)
            {
                queries.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(queriesTemp => Convert.ToInt32(queriesTemp)).ToList());
            }

            List<int> result = dynamicArray(n, queries);

            //textWriter.WriteLine(String.Join("\n", result));

            //textWriter.Flush();
            //textWriter.Close();
        }
        private static void CallSparseArrays()
        {
            //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int stringsCount = Convert.ToInt32(Console.ReadLine());

            string[] strings = new string[stringsCount];

            for (int i = 0; i < stringsCount; i++)
            {
                string stringsItem = Console.ReadLine();
                strings[i] = stringsItem;
            }

            int queriesCount = Convert.ToInt32(Console.ReadLine());

            string[] queries = new string[queriesCount];

            for (int i = 0; i < queriesCount; i++)
            {
                string queriesItem = Console.ReadLine();
                queries[i] = queriesItem;
            }

            int[] res = matchingStrings(strings, queries);

            //textWriter.WriteLine(string.Join("\n", res));

            //textWriter.Flush();
            //textWriter.Close();
        }
        #endregion

        #region arrays
        //reverseArray
        static int[] reverseArray(int[] a)
        {

            for (int i = 0; i <= (a.Length - 1) / 2; i++)
            {
                int selectedValue = a[i];
                int reversedValue = a[a.Length - i - 1];

                a[i] = reversedValue;
                a[a.Length - i - 1] = selectedValue;
            }

            return a;
        }

        // Complete the hourglassSum function below.
        static int hourglassSum(int[][] arr)
        {

            int sum = 0;
            int compare = 0;
            bool isNegative = false;

            for (int i = 0; i < arr.GetLength(0) - 2; i++)
            {
                // for -y line
                for (int j = i; j < arr.GetLength(0) - 2; j++)
                {
                    compare = arr[j][i] + arr[j][i + 1] + arr[j][i + 2] + arr[j + 1][i + 1] + arr[j + 2][i] + arr[j + 2][i + 1] + arr[j + 2][i + 2];

                    if (compare >= 0)
                        isNegative = false;
                    else
                        isNegative = true;

                    if (!isNegative && compare > 0 && sum < compare)
                    {
                        sum = compare;
                    }
                    else if (sum < 0 && compare > -1)
                    {
                        sum = compare;
                    }
                    else if (isNegative && compare < 0 && i == 0 && j == 0)
                    {
                        sum = compare;
                    }
                    else if (isNegative && compare < 0 && sum < compare)
                    {
                        sum = compare;
                    }
                }

                //for -x line
                for (int j = i + 1; j < arr.GetLength(0) - 2; j++)
                {
                    compare = arr[i][j] + arr[i][j + 1] + arr[i][j + 2] + arr[i + 1][j + 1] + arr[i + 2][j] + arr[i + 2][j + 1] + arr[i + 2][j + 2];
                    if (compare >= 0)
                        isNegative = false;
                    else
                        isNegative = true;

                    if (!isNegative && compare > 0 && sum < compare)
                    {
                        sum = compare;
                    }
                    else if (sum < 0 && compare > -1)
                    {
                        sum = compare;
                    }
                    else if (isNegative && compare < 0 && i == 0 && j == 0 && sum != 0)
                    {
                        sum = compare;
                    }
                    else if (isNegative && compare < 0 && sum < compare)
                    {
                        sum = compare;
                    }
                }
            }

            return sum;
        }

        // Complete the dynamicArray function below.
        static List<int> dynamicArray(int n, List<List<int>> queries)
        {
            List<int> seq;
            List<int> result = new List<int>();
            var numberOfSequences = n;
            var seqList = new List<List<int>>(new List<int>[numberOfSequences]);
            var lastAns = 0;
            for (var i = 0; i < queries.Count; i++)
            {
                var queryType = queries[i][0];
                var x = queries[i][1];
                var y = queries[i][2];
                var seqIndex = (x ^ lastAns) % numberOfSequences;
                switch (queryType)
                {
                    case 1:
                        if (seqList[seqIndex] != null)
                            seqList[seqIndex].Add(y);
                        else
                        {
                            seq = new List<int>();
                            seq.Add(y);
                            seqList[seqIndex] = seq;
                        }
                        break;
                    case 2:
                        seq = seqList[seqIndex];
                        lastAns = seq[y % seq.Count];
                        result.Add(lastAns);
                        break;
                }
            }

            return result;
        }

        // Complete the matchingStrings function below.
        static int[] matchingStrings(string[] strings, string[] queries)
        {
            List<int> result = new List<int>();
            foreach (var item in queries)
            {
                int count = 0;
                foreach (var strItem in strings)
                {
                    if (strItem == item)
                    {
                        count++;
                    }
                }
                result.Add(count);
            }

            return result.ToArray();

        }

        // Complete the arrayManipulation function below.
        static long arrayManipulation(int n, int[][] queries)
        {
            long[] computation = new long[n];

            for (int i = 0; i < queries.Count(); i++)
            {
                int a = queries[i][0] - 1;
                int b = queries[i][1] - 1;
                int k = queries[i][2];

                computation[a] += k;
                if (b + 1 < n)
                {
                    computation[b + 1] -= k;
                }
            }

            long max = 0; long sum = 0;
            for (int i = 0; i < n; i++)
            {
                sum += computation[i];
                max = Math.Max(max, sum);
            }

            return max;
        }
        #endregion
    }
}
