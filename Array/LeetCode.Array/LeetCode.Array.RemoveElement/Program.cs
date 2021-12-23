using System;

namespace LeetCode.Array.RemoveElement
{
    class Program
    {
        //27.移除元素
        //给你一个数组 nums 和一个值 val，你需要 原地 移除所有数值等于 val 的元素，并返回移除后数组的新长度。
        static void Main(string[] args)
        {

            Console.WriteLine(RemoveElement(new int[] { 3, 2, 2, 3 }, 2));
        }

        public static int RemoveElement(int[] nums, int val)
        {
            int idx = 0;
            foreach (int x in nums)
            {
                if (x != val) nums[idx++] = x;
            }
            return idx;            
        }

        /// <summary>
        /// 双指针解法，将数组分为两部分；前半段是有效部分，存储不等于val的元素
        /// 后半段是无效部分，存储等于val的元素
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        public static int RemoveElement2(int[] nums, int val)
        {
            if (nums.Length == 0)
                return 0;
            int j = nums.Length - 1;
            for (int i = 0; i <= j; i++)
            {
                if (nums[i] == val) //如果nums[i] 等于目标值
                {
                    //nums[i]与nums[j]元素末尾互换
                    int tmp = nums[i];
                    nums[i] = nums[j];
                    nums[j] = tmp;
                    i--; //i回退一位
                    j--; //j减少一位
                }
            }
            return j + 1;
        }
    }
}
