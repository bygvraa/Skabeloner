using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SelectionSort.Tests
{
    [TestClass]
    public class Sortering_Tests
    {
        [TestMethod]
        public void TestSelectionSort()
        {
            int[] array = new int[] { 34, 18, 15, 45, 67, 11 };
            
            SelectionSort.Sort(array);

            CollectionAssert.AreEqual(
                new int[] { 11, 15, 18, 34, 45, 67 }, 
                array);
        }
    }
}