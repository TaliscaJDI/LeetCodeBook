using System;

namespace LeetCode.String.IsLongPressedName
{
    class Program
    {
        /// <summary>
        /// 925.长按键入
        /// 题目：你的朋友正在使用键盘输入他的名字 name。偶尔，在键入字符 c 时，按键可能会被长按，而字符可能被输入 1 次或多次。
        /// 你将会检查键盘输入的字符 typed。如果它对应的可能是你的朋友的名字（其中一些字符可能被长按），那么就返回 True。
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //string s1 = "alex";
            //string s2 = "aaleex";
            //string s1 = "saeedz";
            //string s2 = "ssaaedd";
            //string s1 = "leelee";
            //string s2 = "lleeelee";
            //string s1 = "laiden";
            //string s2 = "laiden";
            //string s1 = "alex";
            //string s2 = "aaleexa";
            //string s1 = "alexd";
            //string s2 = "ale";
            //string s1 = "pyplrz";
            //string s2 = "ppyypllr";
            //string s1 = "a";
            //string s2 = "b";
            string s1 = "vtkgn";
            string s2 = "vttkgnn";
            Console.WriteLine(IsLongPressedName(s1, s2));
            Console.WriteLine("Hello World!");
        }

        /// <summary>
        /// </summary>
        /// <param name="name"></param>
        /// <param name="typed"></param>
        /// <returns></returns>
        public static bool IsLongPressedName(string name, string typed)
        {         
            //字符串typed只有两个用途
            //1.作为 name 的一部分。此时会「匹配」name 中的一个字符
            //2.作为长按键入的一部分。此时它应当与前一个字符相同。
            //采用下标i,j同时跟踪name和typed的位置，从typed开始遍历，考虑以下两种情况
            //1)当 name[i] = typed[j] 的时候，说明两个字符串存在一对匹配的字符，此时将 i,j 都加1
            //2)否则 name[i] != typed[j] ，typed[j] = typed[j-1] 说明存在一次长按的键入，此时只将 j++；
            //3)如果 name[i] != typed[j] 且 typed[j] != typed[j-1] 说明 字符不匹配，直接返回 false
            //4)最后，如果 i = name.Length ， 说明每个 name 都 被匹配了。
            int i = 0, j = 0;        
            while (j < typed.Length)
            {
                if (i < name.Length && name[i] == typed[j]) 
                {
                    i++;
                    j++;
                }
                else if (j > 0 && typed[j] == typed[j - 1])
                {
                    j++;
                }
                else
                    return false;
            }
            return i == name.Length;
        }

    }
}
