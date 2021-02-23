using System;
using System.Collections.Generic;
using Collections.Utils;

namespace Collections
{
    public static class Task1
    {

        public static void MergeStacks()
        {
            Console.WriteLine("===== Task 1 =====");
            
            var stack1 = new Stack<int>();
            var stack2 = new Stack<int>();

            stack1.Push(RandomUtil.NexRandomInt());
            stack1.Push(RandomUtil.NexRandomInt());
            stack1.Push(RandomUtil.NexRandomInt());
            stack1.Push(RandomUtil.NexRandomInt());
            stack1.Push(RandomUtil.NexRandomInt());

            stack2.Push(RandomUtil.NexRandomInt());
            stack2.Push(RandomUtil.NexRandomInt());
            stack2.Push(RandomUtil.NexRandomInt());
            stack2.Push(RandomUtil.NexRandomInt());
            stack2.Push(RandomUtil.NexRandomInt());

            Console.Write("Stack 1: ");
            print(stack1);

            Console.Write("Stack 2: "); 
            print(stack2);

            var stack3 = new Stack<int>();
            while (stack1.Count != 0)
            {
                var value = stack1.Pop();
                if (stack2.Contains(value))
                {
                    stack3.Push(value);
                }
            }

            Console.Write("Stack 3: ");
            print(stack3);
        }

        private static void print(Stack<int> stack)
        {
            foreach (var value in stack)
            {
                Console.Write(value + " ");
            }
            Console.WriteLine();
        }
    }
}