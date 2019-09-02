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
