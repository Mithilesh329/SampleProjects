using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Given a set of distinct integers, nums, return all possible subsets.
//Note:
//Elements in a subset must be in non-descending order.
//The solution set must not contain duplicate subsets.
//For example,
//If nums = [1, 2, 3], a solution is:

//[
//  [3],
//  [1],
//  [2],
//  [1,2,3],
//  [1,3],
//  [2,3],
//  [1,2],
//  []
//]

namespace SampleProjects
{
    public class SubsetsSolution
    {
        public IList<IList<int>> Subsets(int[] nums)
        {
            IList<IList<int>> result = new List<IList<int>>();
            long constantOne = 1;
            long bitWiseNum = 1;
            long maxNumber = bitWiseNum << nums.Length;

            while (bitWiseNum < maxNumber)
            {
                long temp = bitWiseNum;
                List<int> set = new List<int>();

                int i = 0;
                while (temp != 0)
                {
                    if ((temp & constantOne) == constantOne)
                    {
                        set.Add(nums[i]);
                    }

                    temp >>= 1;
                    i++;
                }

                set.Sort();
                result.Add(set);
                bitWiseNum++;
            }

            // Add for empty list
            result.Add(new List<int>());

            return result;
        }
    }
}
