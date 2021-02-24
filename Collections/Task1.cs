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

            var stack1 = InitStack();
            var stack2 = InitStack();

            Console.Write("Stack 1: ");
            PrintStack(stack1);

            Console.Write("Stack 2: ");
            PrintStack(stack2);

            var stack3 = FindCommonElements(stack1, stack2);

            Console.Write("Stack 3: ");
            PrintStack(stack3);
        }

        private static Stack<int> InitStack()
        {
            var stack = new Stack<int>();
            for (int i = 0; i <= 4; i++)
            {
                stack.Push(RandomUtil.NexRandomInt());
            }

            return stack;
        }

        private static void PrintStack(Stack<int> stack)
        {
            foreach (var value in stack)
            {
                Console.Write(value + " ");
            }

            Console.WriteLine();
        }

        private static Stack<int> FindCommonElements(Stack<int> stack1, Stack<int> stack2)
        {
            var stack3 = new Stack<int>();
            while (stack1.Count != 0)
            {
                var value = stack1.Pop();
                if (stack2.Contains(value))
                {
                    stack3.Push(value);
                }
            }

            return stack3;
        }
    }
}