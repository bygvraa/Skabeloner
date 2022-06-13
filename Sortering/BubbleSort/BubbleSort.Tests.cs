using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BubbleSort.Tests
{
    [TestClass]
    public class BubbleSort_Tests
    {
        [TestMethod]
        public void TestBubbleSort()
        {
            int[] array = new int[] { 34, 18, 15, 45, 67, 11 };

            Console.WriteLine("Usorteret array:");
            PrintArray(array);

            BubbleSort.Sort(array);

            CollectionAssert.AreEqual(
                new int[] { 11, 15, 18, 34, 45, 67 },
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
