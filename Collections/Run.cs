using System;
using System.Collections.Generic;
using Collections.Sort;
using Collections.Utils;

namespace Collections
{
    public static class Run
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Start task 1");
            Task1.MergeStacks();
            Console.WriteLine("Finish task 1\n");

            Console.WriteLine("Start task 2");
            Task2.FindSumBetweenMaxAndMin();
            Console.WriteLine("Finish task 2\n");

            Console.WriteLine("Start task 3");
            Task3.FindLastNumber();
            Console.WriteLine("Finish task 3\n");

            var arrayLength = RandomUtil.NexRandomInt(min: 3, max: 20);
            var array = new int[arrayLength];

            InitArray(array);
            Console.WriteLine("Start task 4");
            Console.WriteLine("Start pancake sorting");
            Console.WriteLine("Исходный массив: {0}", string.Join(", ", array));
            Console.WriteLine("Отсортированный массив: {0}\n", string.Join(", ", PancakeSort.GetSortedArray(array)));

            InitArray(array);
            Console.WriteLine("Start selection sort");
            Console.WriteLine("Исходный массив: {0}", string.Join(", ", array));
            Console.WriteLine("Отсортированный массив: {0}", string.Join(", ", SelectionSort.GetSortedArray(array)));
            Console.WriteLine("Finish task 4");
        }

        private static void InitArray(int[] array)
        {
            for (var i = 0; i < array.Length; i++)
            {
                array[i] = RandomUtil.NexRandomInt(-10, 20);
            }
        }
    }
}