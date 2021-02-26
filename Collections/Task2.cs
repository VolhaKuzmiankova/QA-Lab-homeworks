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

            var countOfElements = RandomUtil.NexRandomInt(min: 3);
            var queue = InitQueue(countOfElements);

            PrintQueue(queue);

            var array = ConvertQueueToArray(queue);

            var maxIdx = FindMaxElementIndex(array);
            var minIdx = FindMinElementIndex(array);

            var startIdx = maxIdx > minIdx ? minIdx : maxIdx;
            var endIdx = maxIdx > minIdx ? maxIdx : minIdx;

            var sum = GetSumOfElementsBetweenIndices(array, startIdx, endIdx);

            Console.WriteLine(
                $"sum of numbers between max ({array[maxIdx]}) and min ({array[minIdx]}) values is {sum}");
        }

        private static Queue<int> InitQueue(int countOfElements)
        {
            var queue = new Queue<int>();
            for (var i = 0; i < countOfElements; i++)
            {
                queue.Enqueue(RandomUtil.NexRandomInt());
            }

            return queue;
        }

        private static void PrintQueue(Queue<int> queue)
        {
            Console.Write("Queue: ");
            foreach (var value in queue)
            {
                Console.Write(value + " ");
            }

            Console.WriteLine();
        }

        private static int[] ConvertQueueToArray(Queue<int> queue)
        {
            int[] array = new int[queue.Count];
            queue.CopyTo(array, 0);
            return array;
        }

        private static int FindMinElementIndex(int[] array)
        {
            var result = 0;

            for (var i = 0; i < array.Length; i++)
            {
                if (array[i] < array[result])
                {
                    result = i;
                }
            }

            return result;
        }

        private static int FindMaxElementIndex(int[] array)
        {
            var result = 0;

            for (var i = 0; i < array.Length; i++)
            {
                if (array[i] > array[result])
                {
                    result = i;
                }
            }

            return result;
        }

        private static int GetSumOfElementsBetweenIndices(int[] array, int startIdx, int endIdx)
        {
            var sum = 0;
            for (var i = startIdx; i <= endIdx; i++)
            {
                sum += array[i];
            }

            return sum;
        }
    }
}