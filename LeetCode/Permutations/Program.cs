using System;
using System.Collections.Generic;
using System.Linq;

namespace Permutations
{
    class Program
    {
        static void Main(string[] args)
        {
            var state = new List<int>();
            var array = new[] { 1, 2, 3, 5 };
            GeneratePermutations(array, 0);
        }

        public IList<IList<int>> Permute(int[] nums)
        {
            var results = new List<IList<int>>();
            Permute(nums, 0, results);
            return results;
        }

        public void Permute(int[] nums, int k, IList<IList<int>> results)
        {
            for (int i = k; i < nums.Length; i++)
            {
                if (k == nums.Length - 1)
                {
                    results.Add((IList<int>)nums.ToList());
                }
                (nums[i], nums[k]) = (nums[k], nums[i]);
                Permute(nums, k + 1, results);
                (nums[i], nums[k]) = (nums[k], nums[i]);
            }
        }
        public static void GeneratePermutations(int[] array, int position)
        {
            for (int i = position; i < array.Length; i++)
            {
                if (position == array.Length - 1)
                {
                    Console.WriteLine(string.Join(".", array));
                }
                (array[i], array[position]) = (array[position], array[i]);
                GeneratePermutations(array, position + 1);
                (array[i], array[position]) = (array[position], array[i]);
            }
        }
    }
}
