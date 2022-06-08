namespace LinearSearch
{
    internal class Linear
    {
        // static void Main(string[] args)
        // {
            //    // Initialiser et array
            //    var array = new int[] { 5, 12, 14, 20, 26, 36, 37, 43, 44, 46, 47, 50, 51, 53, 57, 78, 80, 92, 93, 95 };

            //    // L�s input fra brugeren
            //    Console.WriteLine("Indtast et tal, for at finde det med line�r-s�gning: ");
            //    int number = Int32.Parse(Console.ReadLine());

            //    int index = Search.LinearSearch(array, number);

            //    if (number is not -1)
            //        Console.WriteLine($"Tallet {number} findes p� plads {index}.");
            //    else
            //        Console.WriteLine("Tallet findes ikke i arrayet!");
        // }

        /// <summary>
        /// Metode, der bruger line�r-s�gning til at finde et tal i et array.
        /// </summary>
        /// <param name="array">Array der s�ges i.</param>
        /// <param name="number">Tal der s�ges efter.</param>
        
        public static int LinearSearch(int[] array, int number)
        {
            // G� gennem v�rdierne i arrayet (�n efter �n)
            for (int i = 0; i < array.Length; i++)
            {
                // Hvis tallet findes i arrayet
                if (array[i] == number)
                {
                    // Retuner indeks for tallets plads i arrayet
                    Console.WriteLine($"Tallet {number} findes p� plads {i + 1}.\n");
                    return i;
                }
            }
            // Hvis tallet ikke findes i arrayet
            Console.WriteLine($"Tallet {number} findes ikke i arrayet.\n");
            return -1;
        }

    }
}