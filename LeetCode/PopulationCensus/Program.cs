using System;
using System.Collections.Generic;
using System.Linq;
namespace PopulationCensus
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> pop = new List<int> { 18897109, 12828837, 9661105, 6371773, 5965343, 5926800, 5582170, 5564635, 5268860, 4552402, 4335391, 4296250, 4224851, 4192887, 3439809, 3279933, 3095213, 2812896, 2783243, 2710489, 2543482, 2356285, 2226009, 2149127, 2142508, 2134411 };
            int target = 101000000;

            //List<int> pop = new List<int> { 3, 6, 2, 5, 100, 103 };
            //int target = 14;

            for (int i = 2; i <= pop.Count; i++)
            {
                var arr = Setup(i);
                int lastPositionIndex = i - 1;
                int maxPositionValue = pop.Count - 1;
                int curr = lastPositionIndex;
                int minPositionValue = pop.Count - i;
                while (true)
                {
                    Console.WriteLine(string.Join(",", arr));

                    if (maxPositionValue == arr[curr])
                    {
                        if (minPositionValue == arr[0])
                            break;
                        for (int j = curr - 1; j >= 0; j--)
                        {
                            if (arr[j] + 1 < arr[j + 1])
                            {
                                arr[j]++;
                                for (int k = j + 1; k <= lastPositionIndex; k++)
                                {
                                    arr[k] = arr[k - 1] + 1;
                                }
                                break;
                            }
                        }
                    }
                    else
                        arr[curr]++;
                }

            }


        }

        static int[] Setup(int n)
        {
            int[] arr = new int[n];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = i;
            }
            return arr;
        }

        static void PopulationCensusBruteForce()
        {
            List<int> pop = new List<int> { 18897109, 12828837, 9661105, 6371773, 5965343, 5926800, 5582170, 5564635, 5268860, 4552402, 4335391, 4296250, 4224851, 4192887, 3439809, 3279933, 3095213, 2812896, 2783243, 2710489, 2543482, 2356285, 2226009, 2149127, 2142508, 2134411 };
            int target = 101000000;

            //List<int> pop = new List<int> { 3, 6, 2, 5 };
            //int target = 14;

            int len = pop.Count;
            int combos = (1 << len) - 1;
            Dictionary<int, long> memoValues = new Dictionary<int, long>(combos);
            int pow = -1;
            int lastPow = (int)Math.Pow(2, pow);
            for (int i = 1; i <= combos; i++)
            {
                if (i == 1 || i / lastPow == 2)
                {
                    pow++;
                    int valAtPosition = pop[pow];
                    memoValues.Add(i, valAtPosition);
                    lastPow = (int)Math.Pow(2, pow);
                }
                else
                {
                    int remainder = i - lastPow;
                    long val = memoValues[lastPow] + memoValues[remainder];
                    memoValues.Add(i, val);
                }

                if (memoValues[i] == target)
                {
                    Console.WriteLine(i);
                    List<int> indexes = new List<int>();
                    int currIndex = i;
                    while (true)
                    {
                        int next = GetNextBitPosition(currIndex);
                        indexes.Add(next);
                        currIndex -= (int)(Math.Pow(2, next));
                        if (currIndex == 0)
                        {
                            Console.WriteLine(string.Join(",", indexes.Select(x => pop[x])));
                            Console.WriteLine(indexes.Select(x => pop[x]).Sum());
                        }
                    }
                }
            }
        }

        static int GetNextBitPosition(int n)
        {
            int total = 0;
            int i = 0;
            while (total < n)
            {
                total += ((int)Math.Pow(2, i));
                if (total >= n)
                    return i;
                i++;
            }
            return 0;
        }
    }
}
