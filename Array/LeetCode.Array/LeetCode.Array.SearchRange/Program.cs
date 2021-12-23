using System;
using System.Collections.Generic;

namespace LeetCode.Array.SearchRange
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        /// <summary>
        /// 二分法
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int[] SearchRange(int[] nums, int target)
        {
            int leftIndex = BinarySearch(nums, target, true);
            int rightIndex = BinarySearch(nums, target, false) - 1;

            if (leftIndex <= rightIndex && rightIndex < nums.Length && nums[leftIndex] == target && nums[rightIndex] == target)
            {
                return new int[] { leftIndex, rightIndex };
            }
            return new int[] { -1, -1 };
        }

        /// <summary>
        /// 1.寻找leftindex即是查找在数组中第一个大于等于target的下标，
        /// 2.寻找rightindex即是查找数组中第一个大于target的下标，然后将下标减一
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <param name="islower">是否查找左下标</param>
        /// <returns></returns>
        public static int BinarySearch(int[] nums, int target, bool islower)
        {
            int left = 0;
            int right = nums.Length - 1;
            int ans = nums.Length;
            while (left <= right)
            {
                int mid = left + ((right - left) >> 1); //中间位置
                if (nums[mid] > target || (islower && nums[mid] >= target))
                {
                    right = mid - 1;
                    ans = mid;
                }
                else
                {
                    left = mid + 1;
                }
            }
            return ans;
        }

        /// <summary>
        /// 双指针法：第一个指针从数组头部顺序遍历，第二个指针从数组尾部倒序遍历，
        /// 当集合中两个位置都有值得时候，返回数组集合.
        /// 当数组中不存在目标值时，时间复杂度是 O(n)
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int[] SearchRange1(int[] nums, int target)
        {
            List<int> list = new List<int>(2) { -1, -1 };
            int left = 0;
            int right = nums.Length - 1;
            while (left <= right)
            {
                if (nums[left] == target && list[0] == -1)
                    list[0] = left;
                if (nums[right] == target && list[1] == -1)
                    list[1] = right;

                if (list[0] >= 0 && list[1] >= 0) //当位置1和位置2都存在值的时候，返回集合结果
                    break;
                else
                {
                    if (list[0] < 0) //list[0]没有值得时候才需要指针往后一位移动
                        left++;
                    if (list[1] < 0) //list[1]没有值得时候才需要指针往前一位移动
                        right--;
                }
            }
            return list.ToArray(); 
        }


    }
}
