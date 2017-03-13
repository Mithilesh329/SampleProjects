using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Given a string S and a string T, find the minimum window in S which will contain all the characters in T in complexity O(n).
//For example,
//S = "ADOBECODEBANC"
//T = "ABC"
//Minimum window is "BANC".
//Note:
//If there is no such window in S that covers all characters in T, return the empty string "".
//If there are multiple such windows, you are guaranteed that there will always be only one unique minimum window in S

namespace SampleProjects
{
    public class MinWindowSolution
    {
        public string MinWindow(string s, string t)
        {

            if (string.IsNullOrWhiteSpace(s) || string.IsNullOrWhiteSpace(t))
            {
                return null;
            }

            Dictionary<char, int> THash = new Dictionary<char, int>();
            Dictionary<char, int> WindowHash = new Dictionary<char, int>();

            for (int i = 0; i < t.Length; i++)
            {
                if (THash.ContainsKey(t[i]))
                {
                    THash[t[i]]++;
                }
                else
                {
                    THash[t[i]] = 1;
                }
            }

            for (int i = 0; i < s.Length; i++)
            {
                // Initialize the dictionary
                WindowHash[s[i]] = 0;
            }

            int minStart = 0, minEnd = -1, start = 0, end = s.Length - 1;
            int minLength = int.MaxValue;

            for (int i = 0; i < s.Length; i++)
            {
                WindowHash[s[i]]++;

                if (IsValid(THash, WindowHash))
                {
                    end = i;
                    while (IsValid(THash, WindowHash))
                    {
                        WindowHash[s[start]]--;
                        start++;
                    }

                    if ((end - start + 1) < minLength)
                    {
                        minLength = end - start + 1;
                        minStart = start - 1;
                        minEnd = end;
                    }
                }
            }

            return s.Substring(minStart, minEnd - minStart + 1);
        }

        bool IsValid(Dictionary<char, int> THash, Dictionary<char, int> WindowHash)
        {
            foreach (char key in THash.Keys)
            {
                if (!WindowHash.ContainsKey(key))
                {
                    return false;
                }

                if (WindowHash[key] < THash[key])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
