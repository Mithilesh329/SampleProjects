using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodePrep.LeetCode
{
//72. Edit Distance My Submissions QuestionEditorial Solution
//Total Accepted: 61432 Total Submissions: 210819 Difficulty: Hard
//Given two words word1 and word2, find the minimum number of steps required to convert word1 to word2. (each operation is counted as 1 step.)

//You have the following 3 operations permitted on a word:

//a) Insert a character
//b) Delete a character
//c) Replace a character
//Hide Tags Dynamic Programming String
//Hide Similar Problems(M) One Edit Distance

    public class EditDistanceSolution
    {
        public static void Test()
        {
            EditDistanceSolution sln = new EditDistanceSolution();
            int val = sln.MinDistance("cat", "rat");
            val = sln.MinDistance("dog", "cat");
            val = sln.MinDistance("cat", "catwomen");
        }

        public int MinDistance(string word1, string word2)
        {
            int[,] map = new int[word1.Length + 1, word2.Length + 1];

            for (int i = 0; i < word1.Length + 1; i++)
            {
                map[i, 0] = i;
            }

            for (int j = 0; j < word2.Length + 1; j++)
            {
                map[0, j] = j;
            }

            for (int i = 1; i < word1.Length + 1; i++)
            {
                for (int j = 1; j < word2.Length+1; j++)
                {
                    if (word1[i - 1] == word2[j - 1])
                    {
                        map[i, j] = map[i - 1, j - 1];
                    }
                    else
                    {
                        int min = Math.Min(map[i - 1, j - 1], Math.Min(map[i - 1, j], map[i, j - 1]));
                        map[i, j] = min + 1;
                    }
                }
            }

            return map[word1.Length, word2.Length];
        }
    }
}
