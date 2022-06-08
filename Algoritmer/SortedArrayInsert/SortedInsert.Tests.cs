using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SortedArrayInsert
{
    [TestClass]
    public class SortedInsert_Tests
    {
        [TestMethod]
        public void TestSortedInsert()
        {
            Insert.SortedArrayInit(
                new int[] { 2, 4, 8, 10, 15, 17, -1, -1, -1, -1 }
            );

            int[] newArray = Insert.SortedInsert(11);
            CollectionAssert.AreEqual(
                new int[] { 2, 4, 8, 10, 11, 15, 17, -1, -1, -1 },
                newArray
            );

            newArray = Insert.SortedInsert(19);
            CollectionAssert.AreEqual(
                new int[] { 2, 4, 8, 10, 11, 15, 17, 19, -1, -1 },
                newArray
            );

            newArray = Insert.SortedInsert(1);
            CollectionAssert.AreEqual(
                new int[] { 1, 2, 4, 8, 10, 11, 15, 17, 19, -1 },
                newArray
            );

            newArray = Insert.SortedInsert(20);
            CollectionAssert.AreEqual(
                new int[] { 1, 2, 4, 8, 10, 11, 15, 17, 19, 20 },
                newArray
            );
        }

        [TestMethod]
        public void TestSortedInsertFull()
        {
            int[] array = new int[] { 1, 2, 4, 8, 10, 11, 15, 17, 19, 20 };
            Insert.SortedArrayInit(array);

            int[] newArray = Insert.SortedInsert(14);
            CollectionAssert.AreEqual(array, newArray);
        }
    }
}
