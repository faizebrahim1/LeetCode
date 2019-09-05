using System;
using System.Collections.Generic;
using System.Linq;

namespace LongestPalindromeSubstring
{
    class Program
    {
        static void Main(string[] args)
        {

            string word = "aaaaseidsffdsggsbasiesseilkjhgfdsasdfghjkl";
            var result = new Solution().LongestPalindrome(word);

        }
    }

    public class Solution
    {
        public string LongestPalindrome(string s)
        {
            string reversed = new String(s.Reverse().ToArray());
            int len = s.Length;
            
            if (s.Length <= 1)
                return s;

            string maxWord = s[0].ToString();

            int[][] mx = new int[len][];
            for (int row = 0; row < len; row++)
            {
                Console.WriteLine("");
                mx[row] = new int[len];
                for (int col = 0; col < len; col++)
                {
                    if (reversed[row] == s[col])
                    {
                        //first row or col has no previous
                        if (col == 0 || row == 0)
                        {
                            mx[row][col] = 1;
                        }
                        else
                        {
                            //previous + 1
                            mx[row][col] = mx[row - 1][col - 1] + 1;
                            //Console.Write($" {mx[row][col]}");
                            //check if the next in sequence is match, or are we done?
                            //either we are at edge ot the next doesnt match
                            if (((row == len - 1 || col == len - 1) || (reversed[row + 1] != s[col + 1])) && mx[row][col] > 1)
                            {
                                int start = col - (mx[row][col] - 1);
                                int compare = (len - 1) - row;
                                //look at the count here 
                                if(start == compare)
                                {
                                    string curr = s.Substring(start, mx[row][col]);
                                    if(curr.Length > maxWord.Length)
                                    {
                                        maxWord = curr;
                                    }
                                }
                            }
                        }
                    }
                    //else
                    //    Console.Write($" {mx[row][col]}");

                }
            }

            return maxWord;
        }

        public string LongestPalindromeLong(string s)
        {
            string biggest = "";
            if (s.Length == 0)
                return s;
            for (int i = 0; i < s.Length - 1; i++)
            {
                char c = s[i];
                //even
                int iEvenLeft = i;
                int iEvenRight = i + 1;

                List<char> lEven = new List<char>();
                while (iEvenLeft >= 0 && iEvenRight <= s.Length - 1)
                {

                    var cEvenLeft = s[iEvenLeft];
                    var cEvenRight = s[iEvenRight];
                    if (cEvenLeft == cEvenRight)
                    {
                        lEven.Insert(0, cEvenLeft);
                        lEven.Add(cEvenRight);
                    }
                    else
                    {
                        break;
                    }
                    iEvenLeft--;
                    iEvenRight++;
                }

                if (lEven.Count > 0)
                    if (biggest.Length < lEven.Count)
                        biggest = new String(lEven.ToArray());

                //odd
                if (i == 0)
                    continue;
                int iOddLeft = i - 1;
                int iOddRight = i + 1;

                List<char> lOdd = new List<char> { c };
                while (iOddLeft >= 0 && iOddRight <= s.Length - 1)
                {

                    var cOddLeft = s[iOddLeft];
                    var cOddRight = s[iOddRight];
                    if (cOddLeft == cOddRight)
                    {
                        lOdd.Insert(0, cOddLeft);
                        lOdd.Add(cOddRight);
                    }
                    else
                    {
                        break;
                    }
                    iOddLeft--;
                    iOddRight++;
                }

                if (lOdd.Count > 0)
                    if (biggest.Length < lOdd.Count)
                        biggest = new String(lOdd.ToArray());


            }
            if (biggest == "")
                biggest = s[0].ToString();
            return biggest;
        }
    }
}
