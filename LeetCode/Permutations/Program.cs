using System;
using System.Collections.Generic;

namespace Permutations
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> results = new List<string>();
            var arr = new[] { 1, 2, 3, 4 };
            GeneratePermutations(arr, 0, arr.Length - 1, results);
        }

        public static void GeneratePermutations(int[] arr, int currentIndex, int len, List<string> results)
        {
            for (int i = currentIndex; i <= len; i++)
            {
                if (currentIndex == len)
                {
                    results.Add(string.Join(",", arr));
                }

                (arr[i], arr[currentIndex]) = (arr[currentIndex], arr[i]);

                GeneratePermutations(arr, currentIndex + 1, len, results);
                (arr[i], arr[currentIndex]) = (arr[currentIndex], arr[i]);

            }
        }
    }
}
