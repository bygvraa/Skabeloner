using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LinkedList.Tests
{
    [TestClass]
    public class SortedLinkedList_Tests
    {
        readonly User kristian = new(1, "Kristian");
        readonly User mads     = new(2, "Mads");
        readonly User torill   = new(3, "Torill");
        readonly User kell     = new(4, "Kell");
        readonly User henrik   = new(5, "Henrik");
        readonly User klaus    = new(6, "Klaus");

        readonly User simon    = new(7, "Simon");

        [TestMethod]
        public void TestAdd()
        {
            SortedLinkedList list = new();
            list.Add(mads);
            list.Add(torill);
            list.Add(kristian);
            list.Add(klaus);
            list.Add(henrik);

            SortedLinkedList.PrintList(list);

            Assert.AreEqual(kristian, list.GetFirst());
        }

        [TestMethod]
        public void TestRemove()
        {
            SortedLinkedList list = new();
            list.Add(kristian);
            list.Add(mads);
            list.Add(torill);
            list.Add(henrik);
            list.Add(klaus);

            list.Remove(mads);

            Assert.AreEqual(4, list.Count());

            list.Remove(kristian);

            Assert.AreEqual(3, list.Count());
        }

        [TestMethod]
        public void TestGetLast()
        {
            SortedLinkedList list = new();
            list.Add(kristian);
            list.Add(mads);
            list.Add(torill);
            list.Add(henrik);
            list.Add(klaus);

            Assert.AreEqual(klaus.Id, list.GetLast().Id);
        }

        [TestMethod]
        public void TestCount()
        {
            SortedLinkedList list = new();
            list.Add(kristian);
            list.Add(mads);
            list.Add(torill);

            Assert.AreEqual(3, list.Count());
        }

    }
}
