namespace Merge_sort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] unsorted = new int[1000];
            int[] sorted;

            Random random = new Random();

            Console.WriteLine("Original array elements:");
            for (int i = 0; i < unsorted.Length; i++)
            {
                unsorted[i] = random.Next(0, 1000);
                Console.Write(unsorted[i] + " ");
            }
            Console.WriteLine();

            var watch = System.Diagnostics.Stopwatch.StartNew();
            sorted = MergeSort(unsorted);
            watch.Stop();

            Console.WriteLine("Sorted array elements:");
            foreach (int x in sorted)
            {
                Console.Write(x + " ");
            }
            Console.Write("\n");
            Console.WriteLine("Waktu sort: " + watch.Elapsed.TotalMilliseconds + "ms");
        }

        private static int[] MergeSort(int[] unsorted)
        {
            if (unsorted.Length <= 1)
                return unsorted;

            int middle = unsorted.Length / 2;

            int[] left = new int[middle];
            int[] right = new int[unsorted.Length - middle];

            for (int i = 0; i < middle; i++)
            {
                left[i] = unsorted[i];
            }
            for (int i = middle; i < unsorted.Length; i++)
            {
                right[i - middle] = unsorted[i];
            }

            left = MergeSort(left);
            right = MergeSort(right);

            return Merge(left, right);
        }

        private static int[] Merge(int[] left, int[] right)
        {
            int[] result = new int[left.Length + right.Length];
            int i = 0, j = 0, k = 0;

            while (i < left.Length && j < right.Length)
            {
                if (left[i] <= right[j])
                {
                    result[k] = left[i];
                    i++;
                }
                else
                {
                    result[k] = right[j];
                    j++;
                }
                k++;
            }

            while (i < left.Length)
            {
                result[k] = left[i];
                i++;
                k++;
            }

            while (j < right.Length)
            {
                result[k] = right[j];
                j++;
                k++;
            }

            return result;
        }
    }
}
