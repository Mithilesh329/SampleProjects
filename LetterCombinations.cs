using System;
using System.Collections.Generic;
using System.Linq;

//Given a digit string, return all possible letter combinations that the number could represent.
//Input:Digit string "23"
//Output: ["ad", "ae", "af", "bd", "be", "bf", "cd", "ce", "cf"].

public namespace SampleProjects
{
    public class LetterCombinationsSolution 
    {
        public IList<string> LetterCombinations(string digits) 
        {
            if(string.IsNullOrWhiteSpace(digits))
            {
                return new List<string>();
            }

            Dictionary<char,string>  map = new Dictionary<char, string>();
            map.Add('2', "abc");
            map.Add('3', "def");
            map.Add('4', "ghi");
            map.Add('5', "jkl");
            map.Add('6', "mno");
            map.Add('7', "pqrs");
            map.Add('8', "tuv");
            map.Add('9', "wxyz");

            Queue<string> queue = new Queue<string>();
            queue.Enqueue("");

            foreach(char c in digits)
            {
                if(!map.ContainsKey(c))
                {
                    continue;
                }

                string chars = map[c];
                int count = queue.Count;
                for(int i=0;i<count; i++)
                {
                    string temp = queue.Dequeue();
                    foreach(char ch in chars)
                    {
                        queue.Enqueue(temp+ch);
                    }
                }
            }

            return queue.ToList();

        }
    }
}
