using System;

namespace LeetCode.Array.NextPermutation
{
    class Program
    {
        //31.下一个排列，算法需要将给定数字序列重新排列成字典序中下一个更大的排列（即，组合出下一个更大的整数）
        //如果不存在下一个更大的排列，则将数字重新排列成最小的排列（即升序排列）。
        static void Main(string[] args)
        {
            //int[] nums = new int[] { 1, 2, 3, 4, 6, 5 };
            int[] nums = { 3, 2, 1 };
            NextPermutation(nums);

            foreach (var item in nums)
            {
                Console.WriteLine(item);
            }
        }

        //找出下一个更大排列       
        public static void NextPermutation(int[] nums)
        {
            int n = nums.Length;
            int i = n - 2, j = n - 1, k = n - 1;
            //1.找出第一个升序的 A[i] 和 A[j],
            //如果不存在下一个更大的排列，此时 i = -1 , j = 0 ,将原数组Reverse输出
            while (i >= 0 && nums[i] >= nums[j])
            {
                --i;
                --j;
            }
            //2.从[j,end]找出第一个a[k] > a[i] 的k
            if (i >= 0) //如果为 true , 肯定存在一个 nums[k] > nums[i]
            {
                while (nums[i] >= nums[k])
                    k--;
                //3.交换 A[i] 和 A[k] , 此时 A[j] 到 A[n-1] 为降序
                int tmp = nums[i];
                nums[i] = nums[k];
                nums[k] = tmp;
            }
            //4.将A[j] 到 A[n-1] 变为升序就是下一个相邻的Next更大整数
            //ps：如果当前数组已经时最大的排列，那么 j = 0 , 将当前数组倒序输出
            System.Array.Reverse(nums, j, n - j);
        }  
    }
}
