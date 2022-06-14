namespace QuickSort;

/* QuickSort O(n²)
 * Performer i praksis bedre end MergeSort, men worst case er faktisk O(n²).
   Det er dog sjældent, at man får worst case med en QuickSort.

 * QuickSort-algoritmen følger idéen om "Divide and Conquer", hvor:
    Divide:   Gør problemet mindre, ved at skære problemet i mindre stykker
    Conquer:  Løs de mindre stykker af problemet
    Combine:  Sæt de løste stykker af problemet sammen igen, for at få én samlet løsning

 * QuickSort-algoritmen starter med at vælge et element (kaldet en 'pivot'),
   der deler arrayet op i to dele, og pivot'en fungerer derved som et samlepunkt mellem de to dele af arrayet.
 * Idéen er så, at der på den venstre side af 'pivot' samles alle elementer, der har en lavere værdi end pivot'en,
   og på den højre side samles alle værdierne, der har en højere værdie end pivot'en.
 */

/* GIF
 * https://www.csfieldguide.org.nz/static/interactives/sorting-algorithm-comparison/img/quick-sort.gif
 */

public static class QuickSort
{
    private static void Swap(int[] array, int i, int j)
    {
        int temp = array[i];
        array[i] = array[j];
        array[j] = temp;
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
        // Vælger pivot til at være det laveste tal (altså low)
        int pivot = array[low];

        // To tællevariabler
        int i = low + 1;
        int j = high;

        // Hvis 'i' bliver større end 'j', så stopper loopet
        while (i <= j)
        {
            // Hvis værdien i arrayet er lig eller mindre end pivot'en:
            if (array[i] <= pivot)
            {
                // Gå til næste element på listen
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
        return j;                   // index 'j' er vores endelige pivot

    }

    public static void Sort(int[] array)
    {
        _quickSort(array, 0, array.Length - 1);
    }

}