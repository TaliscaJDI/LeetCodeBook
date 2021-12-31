using System;
using System.Collections.Generic;

namespace LeetCode.Common
{
    public static class LeetCodeCommonTools
    {
        /// <summary>
        /// 数组转换为二叉树
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static TreeNode ArrayToBTree(int?[] arr)
        {
            if (arr.Length == 0)
                return new TreeNode();

            List<TreeNode> treeNodesList = new List<TreeNode>(capacity: arr.Length);
            for (int i = 0; i < arr.Length; i++)
            {
                TreeNode node;
                if (arr[i].HasValue)
                {
                    node = new TreeNode
                    {
                        val = arr[i].Value
                    };
                }
                else
                    node = null;

                treeNodesList.Add(node);
            }

            for (int i = 0; i < treeNodesList.Count / 2 - 1; i++)
            {
                TreeNode root = treeNodesList[i];
                root.left = treeNodesList[2 * i + 1];
                root.right = treeNodesList[2 * i + 2];
            }

            //只有当总结点数为奇数的时候，最后一个父结点才会有右结点
            int lastNodeIndex = treeNodesList.Count / 2 - 1;
            TreeNode lastRootNode = treeNodesList[lastNodeIndex];
            lastRootNode.left = treeNodesList[2 * lastNodeIndex + 1];
            if (treeNodesList.Count % 2 != 0)
            {
                lastRootNode.right = treeNodesList[2 * lastNodeIndex + 2];
            }
            return treeNodesList[0];
        }
    }

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
}
