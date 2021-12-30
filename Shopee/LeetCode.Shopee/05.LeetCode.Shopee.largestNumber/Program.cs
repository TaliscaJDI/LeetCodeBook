using System;
using System.Text;

namespace _05.LeetCode.Shopee.largestNumber
{
    class Program
    {
        /// <summary>
        /// 179. 输出数组组成的字符串最大数
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {            
            Console.WriteLine(LargestNumber(new int[] { 3, 30, 34, 5, 9 }));
        }

        /// <summary>
        /// 题目：给定一组非负整数 nums，重新排列每个数的顺序（每个数不可拆分）使之组成一个最大的整数
        /// 注意：输出结果可能非常大，所以你需要返回一个字符串而不是整数。
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static string LargestNumber(int[] nums)
        {
            int n = nums.Length;
            string[] strNums = new string[n];
            for (int i = 0; i < n; i++)
            {
                strNums[i] = nums[i].ToString();
            }
            //CompareTo()方法比较的时候是按照ASCII码逐位比较的
            //通过比较(a+b)和(b+a)的大小，就可以判断出a,b两个字符串谁应该在前面
            //所以[3,30,34]排序后变为[34,3,30]
            //[233，23333]排序后变为[23333，233]
            Array.Sort(strNums, (a, b) =>
            {
                return (b + a).CompareTo(a + b);
            });            
            //如果排序后的第一个元素是0，那后面的元素肯定小于或等于0，则可直接返回0
            if (strNums[0].Equals("0"))
                return "0";
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < n; i++)
            {
                sb.Append(strNums[i]);
            }
            return sb.ToString();
        }
    }
}
