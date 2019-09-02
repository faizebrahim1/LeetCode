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
            GeneratePermutations(new List<int>(), array.ToList());
        }

        public static void GeneratePermutations(List<int> currentArray, List<int> original)
        {
            foreach(int n in original.Except(currentArray))
            {
                currentArray.Add(n);
                GeneratePermutations(currentArray, original);
                if (original.Count == currentArray.Count)
                    Console.WriteLine(string.Join(".", currentArray));
                currentArray.Remove(n);
            }
        }
    }
}
