namespace BubbleSort;

public class BubbleSort
{
    private static void Swap(int[] array, int i, int j)
    {
        int temp = array[i];
        array[i] = array[j];
        array[j] = temp;
    }

    public static void Sort(int[] array)
    {
        // Det ydre loop vælger et element 'i' fra 'array'
        for (int i = 0; i < array.Length; i++)
        {
            // Det indre loop bruges til at sammenligne 'i' med resten af elementerne 'j' i arrayet
            for (int j = i + 1; j < array.Length; j++)
            {
                // Hvis 'i' er større end 'j'
                if (array[i] > array[j])
                {
                    Swap(array, i, j);
                }
            }
        }

        for (int i = 0; i < array.Length; i++)
        {
            Console.Write(array[i] + " ");
        }
    }
}
