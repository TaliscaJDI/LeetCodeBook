using System;
using System.Collections.Generic;

namespace LeetCode.Shopee
{
    class Program
    {
        //232. 用栈实现队列
        /// <summary>
        /// 请你仅使用两个栈实现先入先出队列。队列应当支持一般队列支持的所有操作（push、pop、peek、empty）：
        /// 实现 MyQueue 类：
        /// void push(int x) 将元素 x 推到队列的末尾
        /// int pop() 从队列的开头移除并返回元素
        /// int peek() 返回队列开头的元素
        /// boolean empty() 如果队列为空，返回 true ；否则，返回 false
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public class MyQueue
    {
        Stack<int> stack1;
        Stack<int> stack2;
        private int front; //记录栈顶元素
        public MyQueue()
        {
            stack1 = new Stack<int>();
            stack2 = new Stack<int>();
        }

        public void Push(int x)
        {
            //如果 stack1 为空的时候，记录第一个入栈的元素，用于判断当 stack2 为空的时候，此时入栈的 x 即是队列第一个元素
            if (stack1.Count == 0) 
                front = x;
            stack1.Push(x);
        }

        public int Pop()
        {
            if (stack2.Count == 0)
            {
                while (stack1.Count > 0)
                {
                    stack2.Push(stack1.Pop());
                }
            }
            return stack2.Pop();
        }

        public int Peek()
        {
            //如果 stack2 不为空，stack2 的 栈顶元素就是队列第一个元素，如果 stack2 为空，则 front 为队列第一个元素
            if (stack2.Count > 0)
            {
                return stack2.Peek();
            }
            return front;
        }

        public bool Empty()
        {
            return stack1.Count == 0 && stack2.Count == 0;
        }
    }
}
