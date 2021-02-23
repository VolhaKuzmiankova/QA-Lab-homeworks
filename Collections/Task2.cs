using System;
using System.Collections.Generic;
using Collections.Utils;

namespace Collections
{
    public static class Task2
    {
        public static void FindSumBetweenMaxAndMin()
        {
            Console.WriteLine("===== Task 2 =====");

            var queue = new Queue<int>();
            var n = RandomUtil.NexRandomInt(min: 3);
            for (var i = 0; i < n; i++)
            {
                queue.Enqueue(RandomUtil.NexRandomInt());
            }

            Console.Write("Queue: ");
            foreach (var value in queue)
            {
                Console.Write(value + " ");
            }
            Console.WriteLine();

            int[] array = new int[queue.Count];
            queue.CopyTo(array, 0);
            var max = queue.Peek();
            var maxIdx = 0;
            var min = queue.Peek();
            var minIdx = 0;

            for (var i = 0; i < array.Length; i++)
            {
                if (array[i] > max)
                {
                    max = array[i];
                    maxIdx = i;
                }

                if (array[i] < min)
                {
                    min = array[i];
                    minIdx = i;
                }
            }

            var startIdx = maxIdx > minIdx ? minIdx : maxIdx;
            var endIdx = maxIdx > minIdx ? maxIdx : minIdx;

            var sum = 0;
            for (var i = startIdx; i <= endIdx; i++)
            {
                sum += array[i];
            }

            Console.WriteLine($"sum of numbers between max and min values is {sum}");
        }
    }
}