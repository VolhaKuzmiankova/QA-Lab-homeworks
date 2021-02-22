namespace Collections
{
    public class PancakeSort
    {
        static int IndexMax(int[] array, int n)
        {
            int maxIndex = 0;
            for (var i = 1; i <= n; ++i)
            {
                if (array[i] > array[maxIndex])
                {
                    maxIndex = i;
                }
            }

            return maxIndex;
        }

        static void Reverse(int[] array, int end)
        {
            for (int start = 0; start < end; start++, end--)
            {
                var interim = array[start];
                array[start] = array[end];
                array[end] = interim;
            }
        }

        public static int[] Sort(int[] array)
        {
            for (var i = array.Length - 1; i >= 0; i--)
            {
                var indexMax = IndexMax(array, i);
                if (indexMax != i)
                {
                    Reverse(array, indexMax);
                    Reverse(array, i);
                }
            }

            return array;
        }
    }
}