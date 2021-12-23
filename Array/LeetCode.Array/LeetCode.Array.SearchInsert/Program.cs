using System;

namespace LeetCode.Array.SearchInsert
{
    class Program
    {
        //35.搜索插入位置
        /// <summary>
        /// 给定一个排序数组和一个目标值，在数组中找到目标值，并返回其索引。
        /// 如果目标值不存在于数组中，返回它将会被按顺序插入的位置。
        /// 请必须使用时间复杂度为 O(log n) 的算法。
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine(SearchInsert(new int[] { 1, 3, 5, 6 }, 0));
            Console.WriteLine("Hello World!");
        }

        /// <summary>
        /// 二分法
        /// </summary>
        /// <param name="nums">数组</param>
        /// <param name="target">目标值</param>
        /// <returns></returns>
        public static int SearchInsert(int[] nums, int target)
        {
            int len = nums.Length; 
            int left = 0;
            int right = len - 1;
            int ans = len;
            while (left <= right)
            {
                int mid = left + (right - left) / 2; // 获取中间值
                if (nums[mid] >= target)  //中间值比目标值大，则右指针二分为 mid - 1 位置
                {
                    right = mid - 1;
                    ans = mid;  //对需要插入(或目标值)的位置ans进行赋值
                }
                else
                {
                    left = mid + 1;  //中间比目标值小，则左指针二分为 mid + 1 位置
                }
            }
            return ans;
        }
    }
}
