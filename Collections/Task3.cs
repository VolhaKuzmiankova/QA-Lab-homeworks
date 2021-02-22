using System;
using System.Collections.Generic;
using Collections.Utils;

namespace Collections
{
    public class Task3
    {

        public static void FindLastNumber()
        {
            Console.WriteLine("===== Task 3 =====");
            var n = RandomUtil.NexRandomInt(min : 3);
            var list = new LinkedList<int>();
            for (var i = 1; i <= n; i++)
            {
                list.AddLast(i);
            }
            
            Console.Write("list : ");
            foreach (var value in list)
            {
                Console.Write($"{value} ");
            }
            Console.WriteLine();

            var node = list.First;
            while (list.Count != 1)
            {
                if (node == null)
                {
                    node = list.First;
                }
                if (node.Next != null)
                {
                    Console.WriteLine($"removing {node.Next.Value}");
                    list.Remove(node.Next);
                    node = node.Next;
                }
                else
                {
                    node = list.First.Next;
                    Console.WriteLine($"removing {node.Previous.Value}");
                    list.Remove(node.Previous);
                }
            }
            
            Console.WriteLine($"Last element is {list.First.Value}");
        }
    }
}