using System;
using System.Collections.Generic;

public class TwoSumSolution
{    
    public static void Main()
    {
        // Example
        int[] nums1 = { 2, 7, 11, 15 };
        int target1 = 9;
        int[] result1 = TwoSum(nums1, target1);
        Console.WriteLine("Output: [" + string.Join(",", result1) + "]"); 

        int[] nums2 = { 3, 2, 4 };
        int target2 = 6;
        int[] result2 = TwoSum(nums2, target2);
        Console.WriteLine("Output: [" + string.Join(",", result2) + "]"); 

        int[] nums3 = { 3, 3 };
        int target3 = 6;
        int[] result3 = TwoSum(nums3, target3);
        Console.WriteLine("Output: [" + string.Join(",", result3) + "]");
    }

    public static int[] TwoSum(int[] nums, int target)
    {
        // Local variables
        Dictionary<int, int> numIndices = new Dictionary<int, int>();
                
        for (int i = 0; i < nums.Length; i++)
        {
            int complement = target - nums[i];

            // Check if the complement exists
            if (numIndices.ContainsKey(complement))
            {                
                return new int[] { numIndices[complement], i };
            }

            // Add the current number and its index to the dictionary
            if (!numIndices.ContainsKey(nums[i]))
            {
                numIndices[nums[i]] = i;
            }
        }

        // throw an exception
        throw new ArgumentException("No two sum solution");
    }

}
