namespace InsertionSort;

/* InsertionSort O(n²)
 * InsertionSort er en simpel algoritme, der fungerer lidt på samme måde,
 * som når man sorterer et sæt spillekort.
 * Man starter med et array (sættet), der deles i to: en sorteret bunke og en usorteret bunke.
 * Værdier (kort) fra den usorterede bunke indsættes så én efter én på deres rette plads i den sorterede bunke.
 */

/* GIF
 * https://www.csfieldguide.org.nz/static/interactives/sorting-algorithm-comparison/img/selection-sort.gif
 */

public class InsertionSort
{
    public static void Sort(int[] array)
    {
        // Loop der løber gennem den usorterede del af arrayet
        for (int i = 1; i < array.Length; i++)
        {
            int key = array[i];     // Den usorterede værdi, der nu skal sorteres
            int j = i;              // Den værdi, der bruges til at gå gennem den sorterede del af arrayet

            // while-loop der kører baglæns gennem for-loopet, fra den aktuelle værdi 'key',
            // indtil den finder 'key's rette plads i den sorterede del af arrayet
            while (j > 0)
            {
                // Hvis 'key' er større eller lig med værdien fra det sorterede array, som 'key' sammenlignes med:
                if (key >= array[j - 1])
                {
                    // Afslut while-loopet, for da 'key' er større eller lig 'array[j - 1]', så har 'key' fundet sin rette plads
                    break;
                }
                else
                {
                    // Flyt værdien på indeks 'array[j - 1]' én plads til højre i arrayet, og gå så vidre til næste værdi
                    array[j] = array[j - 1];
                    j--;
                }
            }
            // Værdien 'key' indsættes på sin plads i det sorterede array
            array[j] = key;
        }
    }
}