using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace LeetCode.Array
{
    class Program
    {
        static void Main(string[] args)
        {

            //IList<IList<int>> resList = ThreeSum(new int[] { -1, 0, 1, 2, -1, -4 });
            IList<IList<int>> resList = ThreeSum(new int[] { 0, 0, 0, 0 });

            Console.WriteLine("Hello World!");
        }

        /// <summary>
        /// 15.求三数之和为0且不重复的三元数组。(排序 + 双指针)
        /// 注意：答案中不可以包含重复的三元组
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static IList<IList<int>> ThreeSum(int[] nums)
        {
            IList<IList<int>> resList = new List<IList<int>>(); 
            if (nums.Length < 3)
                return resList;

            int len = nums.Length;
            System.Array.Sort(nums);  //排序
            bool isSkipNext = false; //是否跳过下一步
            for (int i = 0; i < len; i++)
            {
                if (nums[i] > 0)  //num[i]大于0，后面不可能有三数之和等于0
                    return resList;

                if(isSkipNext)
                {
                    if (i > 0 && i < len - 2 && nums[i] == nums[i + 1])  //当前元素判断：前后重复元素跳过，避免重复解
                    {
                        //满足前后元素重复的条件
                    }
                    else
                        isSkipNext = false; //当前元素，不满足前后元素重复，是否跳过下一步重置为false
                    continue;
                }

                //双指针法
                int curr = nums[i];
                int L = i + 1;
                int R = len - 1;
                while (L < R)
                {
                    int sum = curr + nums[L] + nums[R];
                    if (sum == 0)
                    {
                        IList<int> tmpList = new List<int>();
                        //添加元素
                        tmpList.Add(curr);
                        tmpList.Add(nums[L]);
                        tmpList.Add(nums[R]);
                        resList.Add(tmpList);
                        //排除左指针的重复元素
                        while (L < R && nums[L + 1] == nums[L]) ++L;
                        //排除右指针的重复元素
                        while (L < R && nums[R - 1] == nums[R]) --R;
                        ++L;
                        --R;
                    }
                    else if(sum < 0)  //sum小于0，说明左指针太小，左指针右移
                    {
                        L++;
                    }
                    else  //sum大于0，说明右指针太大，右指针左移
                    {
                        R--;
                    }
                }

                if (i< len-2 && nums[i] == nums[i + 1])  //前后重复元素跳过，避免重复解
                {
                    isSkipNext = true;
                }                    
            }
            return resList;
        }
    }
}
