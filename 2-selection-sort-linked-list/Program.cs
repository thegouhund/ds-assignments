
namespace Week2
{
    public class Program
    {
        static void Main(string[] args)
        {
            LinkedList list = new();
            list.queue(2);
            list.queue(1);
            list.queue(8);
            list.queue(3);
            list.queue(4);
            list.queue(6);
            list.queue(8);
            list.queue(20);
            list.queue(21);
            list.queue(9);
            list.queue(18);
            list.printAll();
            list.sort();
            list.printAll();

            // Random rnd = new Random();
            // for (int i = 0; i <= 100; i++)
            // {
            //     int num = rnd.Next(1, 100);
            //     list.queue(num);
            // }
            // list.printAll();
            // Console.WriteLine("--------");
            // list.sort();
            // list.printAll();
        }
    }
}

// int[] selectionSort(int[] array)
// {
//     for (int i = 0; i < array.Length; i++)
//     {
//         int min = i;
//         for (int j = i + 1; j < array.Length; j++)
//         {
//             if (array[min] > array[j]) min = j;
//         }

//         int temp = array[i];
//         array[i] = array[min];
//         array[min] = temp;
//     }

//     return array;
// }

// int[] unsortedArray = { 9, 2, 6, 0, 1, 3, 7, 8, 4 };
// int[] sortedArray = selectionSort(unsortedArray);

// for (int i = 0; i < sortedArray.Length; i++)
// {
//     Console.Write(sortedArray[i] + " ");
// }
