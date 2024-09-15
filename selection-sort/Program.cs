int[] selectionSort(int[] array)
{
    for (int i = 0; i < array.Length; i++)
    {
        int min = i;
        for (int j = i + 1; j < array.Length; j++)
        {
            if (array[min] > array[j]) min = j;
        }

        int temp = array[i];
        array[i] = array[min];
        array[min] = temp;
    }

    return array;
}

int[] sortedArray = selectionSort(unsortedArray);

for (int i = 0; i < sortedArray.Length; i++)
{
    Console.Write(sortedArray[i] + " ");
}
