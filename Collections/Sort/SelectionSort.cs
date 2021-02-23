namespace Collections.Sort
{
    public static class SelectionSort
    {
        public static int[] Sort(int[] array, int currentIdx = 0)
        {
            if (currentIdx == array.Length)
                return array;
            var indexOfMin = GetIndexOfMinElement(array, currentIdx);
            if (indexOfMin != currentIdx)
            {
                Swap(ref array[indexOfMin], ref array[currentIdx]);
            }

            return Sort(array, currentIdx + 1);
        }

        private static int GetIndexOfMinElement(int[] array, int startIndex)
        {
            var result = startIndex;
            for (var i = startIndex; i < array.Length; ++i)
            {
                if (array[i] < array[result])
                {
                    result = i;
                }
            }

            return result;
        }

        private static void Swap(ref int a, ref int b)
        {
            var temp = a;
            a = b;
            b = temp;
        }
    }
}