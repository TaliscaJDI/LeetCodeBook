using LeetCode.Common;
using System;
using System.Collections.Generic;

namespace _04.LeetCode.Shopee.LevelOrder
{
    class Program
    {
        static void Main(string[] args)
        {
            TreeNode root = LeetCodeCommonTools.ArrayToBTree(new int?[] { 3, 9, 20, null, null, 15, 7 });
            IList<IList<int>> res = LevelOrder(root);
            Console.WriteLine("Hello World!");
        }

        public static IList<IList<int>> LevelOrder(TreeNode root)
        {
            IList<IList<int>> resList = new List<IList<int>>();
            Queue<TreeNode> queue = new Queue<TreeNode>();
            if (root != null)
                queue.Enqueue(root);
            while (queue.Count > 0)
            {
                int n = queue.Count; //记录每层的个数
                IList<int> tempList = new List<int>();
                for (int i = 0; i < n; i++)
                {
                    TreeNode node = queue.Dequeue();
                    tempList.Add(node.val);
                    if (node.left != null)
                        queue.Enqueue(node.left);
                    if (node.right != null)
                        queue.Enqueue(node.right);
                }
                resList.Add(tempList);
            }
            return resList;
        }
    }
    
}
