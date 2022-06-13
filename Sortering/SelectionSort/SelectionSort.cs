namespace SelectionSort;

/* SelectionSort O(n²)
 * Kendt da den er simpel, og ikke helt så ringe som BubbleSort.
 * 1. Find det mindste element i array.
 * 2. Swap det mindste element med det på index 0.
 * 3. Sortér nu fra index 1 og frem efter samme princip.
 */

/* GIF
 * https://i.imgur.com/hsPYlFq.gif
 */

public class SelectionSort
{
    private static void Swap(int[] array, int i, int j)
    {
        int temp = array[i];
        array[i] = array[j];
        array[j] = temp;
    }

    public static void Sort(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            int min = i;

            // Find the mindste tal
            for (int j = i + 1; j < array.Length; j++)
            {
                if (array[j] < array[min])
                {
                    min = j;
                }
            }
            Swap(array, i, min);
        }
    }
}