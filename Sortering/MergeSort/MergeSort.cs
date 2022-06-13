namespace MergeSort;

/* MergeSort O(n * log n)
 * Rigtig god, men kompleks.
 */

/* GIF
 * https://i.imgur.com/eA9faEm.gif
 */

public static class MergeSort
{
    public static void Sort(int[] array)
    {
        _mergeSort(array, 0, array.Length - 1);
    }

    private static void _mergeSort(int[] array, int l, int h)
    {
        if (l < h)
        {
            int m = (l + h) / 2;
            _mergeSort(array, l, m);
            _mergeSort(array, m + 1, h);
            Merge(array, l, m, h);
        }
    }

    private static int[] Merge(int[] array, int low, int middle, int high)
    {
        // Finder størrelsen på de to subarrays
        int n1 = middle - low + 1;
        int n2 = high - middle;

        // Laver de to subarrays
        int[] s1 = new int[n1];
        int[] s2 = new int[n2];


        // Uddelegere data fra 'array' til de to subarrays
        for (int j = 0; j < n1; j++)
            s1[j] = array[low + j];

        for (int j = 0; j < n2; j++)
            s2[j] = array[middle + 1 + j];


        // Start-index på de to subarrays
        int e1 = 0;
        int e2 = 0;

        // Start-index på det samlede 'array'
        int i = low;

        while (e1 < n1 && e2 < n2)
        {
            // Hvis værdien i s2 er højere eller lig med værdien i s1
            if (s1[e1] <= s2[e2])
            {
                // Sæt værdi 'e1' fra subarray 's1'
                // ind i det samlede 'array'
                array[i] = s1[e1];
                e1++;
            }
            else
            {
                // Sæt værdi 'e2' fra subarray 's2'
                // ind i det samlede 'array'
                array[i] = s2[e2];
                e2++;
            }
            i++;
        }

        // Kopiér eventuelle resterende elementer fra 's1'
        while (e1 < n1)
        {
            array[i] = s1[e1];
            e1++;
            i++;
        }

        // Kopiér eventuelle resterende elementer fra 's2'
        while (e2 < n2)
        {
            array[i] = s2[e2];
            e2++;
            i++;
        }

        // Returnér det sorterede array
        return array;
    }

}