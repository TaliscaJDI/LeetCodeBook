using System;

namespace _02.LeetCode.Shopee.Search
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Search(new int[] { -1, 0, 3, 5, 9, 12 }, 2));
            Console.WriteLine("Hello World!");
        }

        /// <summary>
        /// 通用的二分查找法
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int Search(int[] nums, int target)
        {
            int i = 0, j = nums.Length - 1;
            while (i <= j)
            {
                int mid = i + (j - i) / 2;
                if (nums[mid] == target)
                    return mid;
                else if (nums[mid] < target)
                    i = mid + 1;
                else
                    j = mid - 1;
            }
            return -1;
        }
    }
}
