namespace Collections
{
    public class SelectionSort
    {
        static int IndexMin(int[] array, int p)
        {
            var result = p;
            for (var i = p; i < array.Length; ++i)
            {
                if (array[i] < array[result])
                {
                    result = i;
                }
            }

            return result;
        }

        static void Swap(ref int a, ref int b)
        {
            var c = a;
            a = b;
            b = c;
        }

        public static int[] Sort(int[] array, int currentInd = 0)
        {
            if (currentInd == array.Length)
                return array;
            var ind = IndexMin(array, currentInd);
            if (ind != currentInd)
            {
                Swap(ref array[ind], ref array[currentInd]);
            }

            return Sort(array, currentInd + 1);
        }
    }
}