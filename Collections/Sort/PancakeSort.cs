namespace Collections.Sort
{
    public static class PancakeSort
    {
        public static int[] GetSortedArray(int[] array)
        {
            for (var i = array.Length - 1; i >= 0; i--)
            {
                var indexMax = GetIndexOfMaxElement(array, i);
                if (indexMax != i)
                {
                    Reverse(array, indexMax);
                    Reverse(array, i);
                }
            }

            return array;
        }

        private static int GetIndexOfMaxElement(int[] array, int lastElementIndex)
        {
            var maxIndex = 0;
            for (var i = 1; i <= lastElementIndex; ++i)
            {
                if (array[i] > array[maxIndex])
                {
                    maxIndex = i;
                }
            }

            return maxIndex;
        }

        private static void Reverse(int[] array, int end)
        {
            for (var start = 0; start < end; start++, end--)
            {
                var temp = array[start];
                array[start] = array[end];
                array[end] = temp;
            }
        }
    }
}