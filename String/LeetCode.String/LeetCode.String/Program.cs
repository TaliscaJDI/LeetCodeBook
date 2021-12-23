using System;
using System.Collections;
using System.Collections.Generic;

namespace LeetCode.String
{
    class Program
    {
        /// <summary>
        /// 30.串联所有单词的字串
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            IList<int> resList = FindSubstring("barfoothefoobarman", new string[] { "foo", "bar" });
            //IList<int> resList = FindSubstring("barfoofoobarthefoobarman", new string[] { "foo", "bar", "the" });
            //IList<int> resList = FindSubstring("wordgoodgoodgoodbestword", new string[] { "word", "good", "best", "word" });
            foreach (var item in resList)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Hello World!");
        }

        /// 滑动窗口
        /// <summary>
        /// 给定一个字符串 s 和一些 长度相同 的单词 words 。
        /// 找出 s 中恰好可以由 words 中所有单词串联形成的子串的起始位置。
        /// 注意子串要与 words 中的单词完全匹配，中间不能有其他字符 ，
        /// 但不需要考虑 words 中单词串联的顺序。
        /// </summary>
        /// <param name="s"></param>
        /// <param name="words"></param>
        /// <returns></returns>
        public static IList<int> FindSubstring(string s, string[] words)
        {
            List<int> res = new List<int>();
            int wordNum = words.Length;
            if (wordNum == 0)
                return res;
            int wordLen = words[0].Length;
            //Dictionary1存放所有的单词
            Dictionary<string, int> allWordsDic = new Dictionary<string, int>();
            foreach (var item in words)
            {
                //获取字符串数组集合字典值，如果值为0，说明不存在当前单词，需要添加进字典集合，不为0，则值加1
                int value = allWordsDic.GetValueOrDefault(item, 0); 
                if (value == 0)
                    allWordsDic.Add(item, value + 1);
                else
                    allWordsDic[item] += 1;
            }

            //遍历所有字串
            for (int i = 0; i < s.Length - wordNum * wordLen + 1; i++)
            {
                //Dictionay2存放当前扫描的字符串含有的单词
                Dictionary<string, int> hasWordsDic = new Dictionary<string, int>();
                int num = 0;
                //判断子串是否符合
                while (num < wordNum)
                {
                    //string word = s.Substring(i + num * wordLen, i + (num + 1) * wordLen);
                    string word = s.Substring(i + num * wordLen, wordLen);
                    //判断该单词是否在 allWordsDic 中
                    if (allWordsDic.ContainsKey(word))
                    {
                        int value = hasWordsDic.GetValueOrDefault(word, 0);
                        if (value == 0)
                            hasWordsDic.Add(word, value + 1);
                        else
                            hasWordsDic[word] += 1;
                        //判断当前单词的value和 allWordsDic 中该单词的value
                        if (hasWordsDic[word] > allWordsDic[word])
                        {
                            break;
                        }
                    }
                    else
                    {
                        break;
                    }
                    num++;
                }
                //判断是不是所有的单词都符合条件
                if (num == wordNum)
                {
                    res.Add(i);
                }
            }

            return res;
        }
    }
}
