using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Given a string S, you are allowed to convert it to a palindrome by adding characters in front of it.Find and return the shortest palindrome you can find by performing this transformation.
//For example:
//Given "aacecaaa", return "aaacecaaa".
//Given "abcd", return "dcbabcd"

namespace SampleProjects
{
    public class ShortestPalindromeSolution
    {
        public string ShortestPalindrome(string s)
        {
            if (s.Length <= 1)
                return s;
            char[] c_str = s.ToArray();

            // the next array stores the failure function of each position.
            int[] next = new int[c_str.Length];

            next[0] = -1;
            int i = -1, j = 0;
            while (j < c_str.Length - 1)
            {
                if (i == -1 || c_str[i] == c_str[j])
                {
                    i++;
                    j++;
                    next[j] = i;
                    if (c_str[j] == c_str[i])
                    {
                        next[j] = next[i];
                    }
                }
                else
                {
                    i = next[i];
                }
            }

            // match the string with its reverse.
            i = c_str.Length - 1; j = 0;
            while (i >= 0 && j < c_str.Length)
            {
                if (j == -1 || c_str[i] == c_str[j])
                {
                    i--;
                    j++;
                }
                else
                {
                    j = next[j];
                }
            }

            StringBuilder sb = new StringBuilder();
            for (i = c_str.Length - 1; i >= j; i--) sb.Append(c_str[i]);
            foreach (char c in c_str) sb.Append(c);
            return sb.ToString();
        }
    }
}
