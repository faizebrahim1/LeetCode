using System;
using System.Collections.Generic;

namespace LongestSubsetNoRepeats
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = new Solution().LengthOfLongestSubstring("ggububgvfk");
        }
    }

    public class Solution
    {
        public int LengthOfLongestSubstring(string s)
        {
            int max = 0;
            int lastIndex = -1;
            int count = 0;
            var lookup = new Dictionary<char, int>();

            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                if (lookup.ContainsKey(c))
                {
                    var charPosition = lookup[c];
                    if (charPosition > lastIndex)
                    {
                        count = i - charPosition;
                        lastIndex = charPosition;
                    }
                    else
                    {
                        count++;
                    }
                    lookup[c] = i;
                }
                else
                {
                    lookup.Add(c, i);
                    count++;
                }
                max = Math.Max(max, count);

            }

            return max;
        }
    }
}
