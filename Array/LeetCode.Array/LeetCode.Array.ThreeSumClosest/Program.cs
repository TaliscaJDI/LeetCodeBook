using System;

namespace LeetCode.Array.ThreeSumClosest
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] nums = { -1, 2, 1, -4 };
            //int[] nums = { 0, 0, 0 };

            //[1,1,1,0]
            //100
            //[1, 1, 1, 0]
            //-100
            int[] nums = { 1, 2, 4, 8, 16, 32, 64, 128};
            int target = 82;
            Console.WriteLine(ThreeSumClosest(nums, target));
            //Console.WriteLine("Hello World!");
        }

        public static int ThreeSumClosest(int[] nums, int target)
        {
            int len = nums.Length;
            System.Array.Sort(nums);
            int minValue = int.MaxValue;
            int closestValue = 0;
            for (int i = 0; i < len-1; i++)
            {
                int left = i + 1;
                int right = len - 1;
                while (left < right)
                {
                    int sum = nums[i] + nums[left] + nums[right];
                    int abs = Math.Abs(target - sum);
                    if (abs <= minValue)
                    {
                        minValue = abs;
                        closestValue = sum;
                    }
                    if (sum > target)
                        right--;
                    if (sum < target)
                        left++;
                    else // sum 等于 targen 直接返回
                        return closestValue;
                }
            }
            return closestValue;
        }
    }
}
