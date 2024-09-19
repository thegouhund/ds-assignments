void selectionSort(int[] array)
{
    for (int i = 0; i < array.Length; i++)
    {
        int min = i;
        for (int j = i + 1; j < array.Length; j++)
        {
            if (array[min] > array[j]) min = j;
        }

        // printArray(array);

        if (array[i] != array[min])
        {
            // Console.WriteLine($"\nSwapping {array[i]} with {array[min]}");
            int temp = array[i];
            array[i] = array[min];
            array[min] = temp;
        }
    }
}

void shuffle(int[] array)
{
    Random rand = new();
    int n = array.Length;
    while (n > 1)
    {
        int k = rand.Next(n--);
        int temp = array[n];
        array[n] = array[k];
        array[k] = temp;
    }
}

void partialShuffle(int[] array, int swapAmount)
{
    Random rand = new Random();

    for (int i = 0; i < swapAmount; i++)
    {
        int index1 = rand.Next(array.Length);
        int index2 = rand.Next(array.Length);

        int temp = array[index1];
        array[index1] = array[index2];
        array[index2] = temp;
    }
}

void printArray(int[] array)
{
    for (int i = 0; i < array.Length; i++)
    {
        Console.Write(array[i] + " ");
    }
}

void reverse(int[] array)
{
    for (int i = 0; i < array.Length; i++)
    {
        int min = i;
        for (int j = i + 1; j < array.Length; j++)
        {
            if (array[min] < array[j]) min = j;
        }

        if (array[i] != array[min])
        {
            int temp = array[i];
            array[i] = array[min];
            array[min] = temp;
        }
    }
}


int maxSize = 1000;

int[] array = new int[maxSize];
Random rand = new();
for (int i = 1; i <= maxSize; i++)
{
    array[i - 1] = i;
}

// Test Cases

// 1. Fully shuffled array
shuffle(array);
Console.WriteLine("Fully shuffled: ");
printArray(array);
selectionSort(array);
Console.WriteLine("\n\nSorted array: ");
printArray(array);

// 2. Reversed array
reverse(array);
Console.WriteLine("\n\nReverse sorted: ");
printArray(array);
selectionSort(array);
Console.WriteLine("\n\nSorted array: ");
printArray(array);

// 3. Paritally shuffled array
partialShuffle(array, 5);
Console.WriteLine("\n\nPartially shuffled: ");
printArray(array);
selectionSort(array);
Console.WriteLine("\n\nSorted array: ");
printArray(array);
