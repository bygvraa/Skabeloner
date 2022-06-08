namespace QuickSort;

public static class QuickSort
{
    private static void Swap(int[] array, int i, int j)
    {
        int tmp = array[i];
        array[i] = array[j];
        array[j] = tmp;
    }

    private static void _quickSort(int[] array, int low, int high)
    {
        if (low < high)
        {
            int pivot = Partition(array, low, high);
            _quickSort(array, low, pivot - 1);
            _quickSort(array, pivot + 1, high);
        }
    }

    private static int Partition(int[] array, int low, int high)
    {
        // Pivot er det laveste tal (altså low)
        int pivot = array[low];

        // To tællevariabler
        int i = low + 1;
        int j = high;

        // Hvis i bliver større end j, så stopper loopet
        while (i <= j)
        {
            // Hvis værdien i arrayet er lig eller mindre end pivot'en:
            if (array[i] <= pivot)
            {
                i++;
            }
            else if (array[j] > pivot)
            {
                j--;
            }
            else
            {
                Swap(array, i, j);
                i++;
                j--;
            }
        }
        Swap(array, low, j);
        return j;                   // index j er vores endelige pivot

    }

    public static void Sort(int[] array)
    {
        _quickSort(array, 0, array.Length - 1);
    }

}