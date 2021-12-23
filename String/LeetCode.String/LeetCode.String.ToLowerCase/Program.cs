using System;
using System.Text;

namespace LeetCode.String.ToLowerCase
{
    class Program
    {
        //709.转换成小写字母
        static void Main(string[] args)
        {
            Console.WriteLine(ToLowerCase("Hello"));
            Console.WriteLine("Hello World!");
        }

        //给你一个字符串s ，将该字符串中的大写字母转换成相同的小写字母，
        //返回新的字符串
        public static string ToLowerCase(string s)
        {
            int n = s.Length;
            StringBuilder res = new StringBuilder();
            for (int i = 0; i < n; ++i)
            {
                char c = s[i];
                if (c >= 'A' && c <= 'Z')
                    res.Append((char)(c + 32));
                else
                    res.Append(c);
            }
            return res.ToString();
        }
    }
}