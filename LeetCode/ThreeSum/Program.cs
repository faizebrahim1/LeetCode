using System;
using System.Collections.Generic;
using System.Linq;
namespace ThreeSum
{
    class Program
    {
        static void Main(string[] args)
        {
            var r = new Solution().ThreeSum(new[] { -1, 0, 1, 2, -1, -4 });
        }
    }

    public class Solution
    {
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            var result = new List<IList<int>>();
            Dictionary<(int, int, int), List<int>> hs = new Dictionary<(int, int, int), List<int>>();
            Dictionary<int, int> targetsProcessed = new Dictionary<int, int>();
            for (int i = 2; i < nums.Length; i++)
            {
                int num = nums[i];

                if (targetsProcessed.ContainsKey(num))
                {
                    if ((num == 0 && targetsProcessed[num] < 3) || targetsProcessed[num] < 2)
                        targetsProcessed[num]++;
                    else
                        continue;
                }
                else
                    targetsProcessed[num] = 1;

                int target = num * -1;

                HashSet<int> processed = new HashSet<int>();

                for (int j = 0; j < i; j++)
                {
                    int curr = nums[j];
                    int needed = target - curr;
                    if (processed.Contains(needed))
                    {
                        int[] temp = { needed, curr, num };
                        Array.Sort(temp);
                        var key = (temp[0], temp[1], temp[2]);
                        if (!hs.ContainsKey(key))
                        {
                            hs.Add(key, temp.ToList());
                        }

                    }
                    processed.Add(curr);
                }
            }

            result = hs.Select(x => (IList<int>)x.Value).ToList();
            return result;

        }



    }
}
