namespace BinarySearch
{
    internal class Binary
    {
        /// <summary>
        /// Finder tallet i arrayet med en bin�r s�gning.
        /// </summary>
        /// <param name="array">Array der s�ges i.</param>
        /// <param name="number">Tal der s�ges efter.</param>
        /// <param name="min">Minimumsv�rdi p� m�ngden, der s�ges i.</param>
        /// <param name="max">Maksimumsv�rdi p� m�ngden, der s�ges i.</param>
        /// <param name="mid">Middelv�rdien p� m�ngden, der s�ges i.</param>
        /// <returns></returns>

        public static int BinarySearch(int[] array, int number)
        {
            int min = 0;
            int max = array.Length - 1;

            // Mens 'min' er lig eller mindre end 'max'
            while (min <= max)
            {
                int mid = (min + max) / 2;

                // Hvis tallet findes i arrayet
                if (number == array[mid])
                {
                    // Retuner indeks for tallets plads i arrayet
                    Console.WriteLine($"Tallet {number} findes p� plads {mid + 1}.\n");
                    return mid;
                }
                // Hvis 'number' er mindre end 'mid'
                else if (number < array[mid])
                {
                    max = mid - 1;
                }
                // Hvis 'number' er st�rre end 'mid'
                else if (number > array[mid])
                {
                    min = mid + 1;
                }
            }
            // Hvis tallet ikke findes i arrayet
            Console.WriteLine($"Tallet {number} findes ikke i arrayet.\n");
            return -1;
        }
    }
}