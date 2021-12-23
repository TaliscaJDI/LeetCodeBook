using System;

namespace LeetCode.Array.RemoveDuplicates
{
    class Program
    {
        //26. 删除有序数组中的重复项
        static void Main(string[] args)
        {
            //int[] nums = new int[] { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 };

            //int[] nums = new int[] { 0, 1, 2, 3, 4, 5 };

            int[] nums = new int[] { };

            Console.WriteLine(RemoveDuplicates(nums));
        }
       
        public static int RemoveDuplicates(int[] nums)
        {
            //本质是将不重复的元素往数组前面移动, 因为数组已经是有序的,
            //所以存在的重复元素是相邻的, 只要顺序遍历一次即可。
            //因为i也会移动，所以当数组元素不重复的时候， i 会移动到和 j 相同的位置，，此时 num[i] 和 nums[j] 相等， 让 j++;
            //双指针法, 当nums[j]和nums[i]不相等时, nums[j]移动到nums[i+1], 然后i往前移动一位
            if (nums.Length == 0)
                return 0;
            int i = 0;
            int j = 1;
            while (j < nums.Length)
            {
                if (nums[i] == nums[j])
                {
                    j++;
                }
                else
                {
                    nums[i+1] = nums[j];
                    i++;
                }
            }
            return i + 1;
        }
    }
}
