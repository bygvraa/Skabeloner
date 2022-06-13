using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace QuickSort.Tests
{
    [TestClass]
    public class Sortering_Tests
    {
        [TestMethod]
        public void TestQuickSort()
        {
            int[] array = new int[] { 34, 18, 15, 45, 67, 11, 1 };
            
            Console.WriteLine("Usorteret array:");
            PrintArray(array);

            QuickSort.Sort(array);

            CollectionAssert.AreEqual(
                new int[] { 1, 11, 15, 18, 34, 45, 67 }, 
                array);

            Console.WriteLine("Sorteret array:");
            PrintArray(array);
        }

        public static void PrintArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($" {array[i]}");
            }
            Console.WriteLine("\n");
        }
    }
}