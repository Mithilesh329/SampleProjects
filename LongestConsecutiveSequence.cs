using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Given an unsorted array of integers, find the length of the longest consecutive elements sequence.
//For example,
//Given [100, 4, 200, 1, 3, 2],
//The longest consecutive elements sequence is [1, 2, 3, 4]. Return its length: 4.
//Your algorithm should run in O(n) complexity

namespace SampleProjects
{
  public class LongestConsecutiveSequence 
  {
      public int LongestConsecutive(int[] nums) 
      {
          if(nums == null)
          {
              return 0;
          }

          if(nums.Length <= 1)
          {
              return nums.Length;
          }

          Array.Sort(nums, (x,y) => x.CompareTo(y));

          int[] lc = new int[nums.Length];
          lc[0] = 1;
          int max = 1;
          for(int i=1; i<nums.Length; i++)
          {
              if(nums[i] == nums[i-1]+1)
              {
                  lc[i] = lc[i-1]+1;
                  if(max < lc[i])
                  {
                      max = lc[i];
                  }
              }
              else if(nums[i] == nums[i-1])
              {
                  lc[i] = lc[i-1];
              }
              else
              {
                  lc[i] = 1;
              }
          }

          return max;
      }
  }
}
