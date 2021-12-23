using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace LeetCode.String.MostCommonWord
{
    class Program
    {
        static void Main(string[] args)
        {
            //string[] arr = { "aaa", "bbb", "ccc" };
            //string[] exceptArr = { "aaa" };
            //string[] newArr = arr.Except(exceptArr).ToArray();

            //string str = "Bob hit a ball, the hit BALL flew far after it was hit.";
            //string[] banarr = { "hit" };

            //string str = "a, a, a, a, b,b,b,c, c";
            //string[] banarr = { "a" };

            string str = "Bob";
            string[] banarr = { };

            Console.WriteLine(MostCommonWord3(str, banarr));

            Console.WriteLine("Hello World!");
        }

        /// <summary>
        /// 1.直接解法，首先对整段字符串替换标点符号为空格并且转换为小写，
        /// 然后根据空格字符进行split分词。对于每一个单词都会放入到哈希表中进行计数，
        /// 如果当前单词不在禁用列表中，就更新一次数据
        /// </summary>
        /// <param name="paragraph"></param>
        /// <param name="banned"></param>
        /// <returns></returns>
        public static string MostCommonWord(string paragraph, string[] banned)
        {
            if (string.IsNullOrEmpty(paragraph) || string.IsNullOrWhiteSpace(paragraph))
                return string.Empty;
            paragraph = paragraph.Replace("!", " ");
            paragraph = paragraph.Replace("?", " ");
            paragraph = paragraph.Replace("'", " ");
            paragraph = paragraph.Replace(",", " ");
            paragraph = paragraph.Replace(";", " ");
            paragraph = paragraph.Replace(".", " ");
            paragraph = paragraph.ToLower();
            string[] strArr = paragraph.Split(' ',StringSplitOptions.RemoveEmptyEntries);
            Dictionary<string, int> dic = new Dictionary<string, int>();
            foreach (var item in strArr)
            {
                if (!banned.Contains(item))
                {
                    if (!dic.ContainsKey(item))
                    {
                        dic.Add(item, 1);
                    }
                    else
                    {
                        dic[item] += 1;
                    }
                }               
            }
            int maxcount = 0;
            string resStr = string.Empty;
            foreach (var itemkey in dic.Keys)
            {
                if (dic[itemkey] > maxcount)
                {
                    maxcount = dic[itemkey];
                    resStr = itemkey;
                }
            }
            return resStr;
        }

        /// <summary>
        /// 2.逐个字符匹配法，如果遇到非字母的符号，就把之前遇到的字母作为一个单词
        /// </summary>
        /// <param name="paragraph"></param>
        /// <param name="banned"></param>
        /// <returns></returns>
        public static string MostCommonWord2(string paragraph, string[] banned)
        {
            if (string.IsNullOrEmpty(paragraph) || string.IsNullOrWhiteSpace(paragraph))
                return string.Empty;

            Dictionary<string, int> dic = new Dictionary<string, int>();
            StringBuilder sb = new StringBuilder();
            string word = string.Empty;
            for (int i = 0; i < paragraph.Length; i++)
            {
                char ch = paragraph[i];
                if (ch >= 'a' && ch <= 'z')
                    sb.Append(ch);
                else if (ch >= 'A' && ch <= 'Z')
                    sb.Append((char)(ch + 32)); //大写转小写
                else
                    word = sb.ToString();
                if (!string.IsNullOrEmpty(word))
                {
                    if(!banned.Contains(word))
                    {
                        if (!dic.ContainsKey(word))
                            dic.Add(word, 1);
                        else
                            dic[word] += 1;
                    }
                    sb.Clear();
                    word = string.Empty;
                }
            }

            //判断最后一个单词，sb是否已经清空
            if (sb.Length > 0)
            {
                string lastStr = sb.ToString();
                if (!banned.Contains(lastStr))
                {
                    if (!dic.ContainsKey(lastStr))
                        dic.Add(lastStr, 1);
                    else
                        dic[lastStr] += 1;
                }
            }

            int maxcount = 0;
            string resStr = string.Empty;
            foreach (var itemkey in dic.Keys)
            {
                if (dic[itemkey] > maxcount)
                {
                    maxcount = dic[itemkey];
                    resStr = itemkey;
                }
            }
            return resStr;
        }

        /// <summary>
        /// 正则匹配法
        /// </summary>
        /// <param name="paragraph"></param>
        /// <param name="banned"></param>
        /// <returns></returns>
        public static string MostCommonWord3(string paragraph, string[] banned)
        {
            string matchStr = paragraph.ToLower();
            var res = Regex.Matches(matchStr, @"\b[a-z]*\b");
            Dictionary<string, int> dic = new Dictionary<string, int>();
            foreach (var item in res)
            {
                string tmpStr = item.ToString();
                if (!string.IsNullOrEmpty(tmpStr))
                {
                    if(!banned.Contains(tmpStr))
                    {
                        if (!dic.ContainsKey(tmpStr))
                            dic.Add(tmpStr, 1);
                        else
                            dic[tmpStr] += 1;
                    }
                }
            }

            int maxcount = 0;
            string resStr = string.Empty;
            foreach (var itemkey in dic.Keys)
            {
                if (dic[itemkey] > maxcount)
                {
                    maxcount = dic[itemkey];
                    resStr = itemkey;
                }
            }
            return resStr;
        }
    }
}
