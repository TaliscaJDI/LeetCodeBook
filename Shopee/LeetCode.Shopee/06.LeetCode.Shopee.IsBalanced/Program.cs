using LeetCode.Common;
using System;
using System.Collections.Generic;

namespace _06.LeetCode.Shopee.IsBalanced
{
    class Program
    {
        /// <summary>
        /// 110.判断是否为平衡二叉树
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            TreeNode root = LeetCodeCommonTools.ArrayToBTree(new int?[] { 3, 9, 20, null, null, 15, 7 });          
            Console.WriteLine(IsBalanced(root));

            Console.WriteLine("Hello World!");
        }

        /// <summary>
        /// 给定一个二叉树，判断它是否是高度平衡的二叉树。
        /// 本题中，一棵高度平衡二叉树定义为：一个二叉树每个节点 的左右两个子树的高度差的绝对值不超过 1 
        /// 自顶向下的递归法
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static bool IsBalanced(TreeNode root)
        {            
            if (root == null)
                return true;
            else //首先判断根节点左右子树高度，是否不超过1，再分别递归遍历左右子节点，并判断其左子树和右子树是否平衡。所以下面用的是逻辑 &&
                return Math.Abs(Height(root.left) - Height(root.right)) <= 1 && IsBalanced(root.left) && IsBalanced(root.right);
        }

        /// <summary>
        /// 递归计算二叉树节点高度
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public static int Height(TreeNode node)
        {
            if (node == null) //临界点
                return 0;
            else
                return Math.Max(Height(node.left), Height(node.right)) + 1;
        } 
    }  
}
