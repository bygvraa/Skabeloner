namespace SortedArrayInsert
{
    internal class Insert
    {
        private static int[] SortedArray { get; set; } =
            new int[] { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1 };

        public static void SortedArrayInit(int[] sortedArray)
        {
            Insert.SortedArray = sortedArray;
        }

        /// <summary>
        /// Indsætter et tal i et sorteret array. En kopi af arrayet returneres.
        /// Array er fortsat sorteret efter det nye tal er indsat.
        /// </summary>
        /// <param name="number">Tal der indsættes.</param>
        /// <returns>En kopi af det sorterede array med det nye tal i.</returns>
        public static int[] SortedInsert(int number)
        {
            int length = SortedArray.Length;
            int position = 0;

            Console.WriteLine("--------------------------------");
            Console.WriteLine("Array før indsættelse:");
            for (int i = 0; i < length; i++)
                Console.Write(" {0}", SortedArray[i]);
            Console.WriteLine("\n");

            /* 1. Tjekker om arrayet har en tom plads */
            if (SortedArray[length - 1] is not -1)
            {
                Console.WriteLine("Arrayet er allerede fyldt.");
                return SortedArray;
            }
            else
            {
                /* 2. Find pladsen 'position', som 'number' skal indsættes på */
                for (int i = 0; i < length; i++)
                {
                    // Hvis 'number' allerede findes i arrayet
                    if (SortedArray[i] == number)
                    {
                        return SortedArray;
                    }

                    // Hvis 'number' er mindre end værdien i arrayet
                    else if (SortedArray[i] > number ||
                             SortedArray[i] == -1)
                    {
                        position = i;
                        break;
                    }
                }

                /* 3. Flyt værdierne i arrayet én til højre fra pladsen 'position' */
                for (int i = length; i >= position; i--)
                {
                    if (i == length)
                    {
                        // Hvis 'i' er det sidste element i arrayet, spring videre til næste
                        continue;
                    }
                    else if (i == 0)
                    {
                        // Hvis 'i' er det første element i arrayet, så stoppes for-loopet
                        break;
                    }
                    else
                    {
                        SortedArray[i] = SortedArray[i - 1];
                    }
                }

                /* 4. Indsæt værdien på den rette plads */
                Console.WriteLine($"Tallet {number} er indsat på plads {position + 1}.\n");
                SortedArray[position] = number;

                Console.WriteLine("Array efter indsættelse:");
                for (int i = 0; i < length; i++)
                    Console.Write(" {0}", SortedArray[i]);
                Console.WriteLine("\n");

                /* 5. Retuner det nye array */
                return SortedArray;
            }
        }
    }
}