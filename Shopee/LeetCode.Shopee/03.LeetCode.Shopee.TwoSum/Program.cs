using System;

namespace _03.LeetCode.Shopee.TwoSum
{
    class Program
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        /// <summary>
        /// 二分法
        /// 首先固定第一个数，然后找第二个数，第二个数等于目标值减去第一个数的差。
        /// 利用数组的 有序 性质，可以通过二分查找法寻找第二个数。
        /// 为了避免重复寻找，在寻找第二个数时，只在第一个数的右侧找。
        /// 时间复杂度, for 循环 O(n), 二分法 O(logN) , 所以整个时间复杂度是 O(nLogN)
        /// </summary>
        /// <param name="numbers"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int[] TwoSum1(int[] numbers, int target)
        {
            int first = -1, second = -1;
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                int left = i + 1, right = numbers.Length - 1, minsNum = target - numbers[i];
                //边界判断,如果差值比右侧第一个少或者比右侧最后一个数大，就跳过循环，此时时间复杂度是O(n)
                //又因为题目是存在唯一解，所以这个优化在不一定存在解的情况下使用
                //if (minsNum < numbers[left] || minsNum > numbers[right]) 
                //{
                //    continue;
                //}
                while (left <= right) //开始二分查找
                {
                    int mid = left + (right - left) / 2;
                    if (numbers[mid] == minsNum)
                    {
                        first = i + 1;
                        second = mid + 1;
                        return new int[] { first, second };
                    }
                    else if (minsNum > numbers[mid])
                    {
                        left = mid + 1;
                    }
                    else
                    {
                        right = mid - 1;
                    }
                }
            }
            return new int[] { first, second };
        }

        /// <summary>
        /// 双指针法
        /// 初始时两个指针分别指向第一个元素位置和最后一个元素的位置。每次计算两个指针指向的两个元素之和，并和目标值比较。
        /// 思路：
        /// 如果两个元素之和等于目标值，则发现了唯一解。
        /// 如果两个元素之和小于目标值，则将左侧指针右移一位。
        /// 如果两个元素之和大于目标值，则将右侧指针左移一位。移动指针之后，重复上述操作，直到找到答案。
        /// 那么会不会把可能的解过滤掉？答案是不会。
        /// 假设 numbers[i] + numbers[j] = target 是唯一解，其中 0<=i<j<=numbers.length-1 。 初始时两个指针分别指向下标0和下标number.length-1,
        /// 左指针指向的下标小于或者等于i，右指针指向的下标大于或等于j，除非初始时左指针和右指针已经位于下标i和j，否则一定是左指针先达到下标i的位置
        /// 或者右指针先到下标j的位置。如果左指针先到达下标i的位置，此时右指针还在下标j的右侧，sum>target，因此一定是右指针左移，左指针不可能到达i的右侧。
        /// 如果右指针先达到下标j的位置，此时左指针还在i的左侧，sum<target，因此一定是左指针右移，右指针不可能到达j的左侧。
        /// 由此可见，在整个移动过程中，左指针不可能移到 ii 的右侧，右指针不可能移到 jj 的左侧，因此不会把可能的解过滤掉。由于题目确保有唯一的答案，
        /// 因此使用双指针一定可以找到答案。
        /// </summary>
        /// <param name="numbers"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int[] TwoSum(int[] numbers, int target)
        {
            int left = 0, right = numbers.Length - 1;
            while (left < right)
            {
                int sum = numbers[left] + numbers[right];
                if (sum == target)
                    return new int[] { left + 1, right + 1 };
                else if (sum < target)
                    left++;
                else
                    right--;
            }
            return new int[] { -1, -1 };
        }

    }
}
