using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LinkedList.Tests
{
    [TestClass]
    public class LinkedList_Tests
    {
        readonly User kristian = new(1, "Kristian");
        readonly User mads     = new(2, "Mads");
        readonly User torill   = new(3, "Torill");
        readonly User kell     = new(4, "Kell");
        readonly User henrik   = new(5, "Henrik");
        readonly User klaus    = new(6, "Klaus");

        readonly User simon    = new(7, "Simon");

        [TestMethod]
        public void TestAddFirst()
        {
            LinkedList list = new ();
            list.AddFirst(mads);
            list.AddFirst(kristian);

            Assert.AreEqual(kristian, list.GetFirst());
        }

        [TestMethod]
        public void TestAddLast()
        {
            LinkedList list = new();
            list.AddFirst(mads);
            list.AddFirst(kristian);
            list.AddLast(kell);
            list.AddFirst(torill);

            Assert.AreEqual(kell, list.GetLast());
        }

        [TestMethod]
        public void TestRemoveFirst()
        {
            LinkedList list = new ();
            list.AddFirst(kristian);
            list.AddFirst(mads);
            list.AddFirst(torill);
            
            Assert.AreEqual(torill, list.RemoveFirst());
        }

        [TestMethod]
        public void TestCountUsers()
        {
            LinkedList list = new ();
            list.AddFirst(kristian);
            list.AddFirst(mads);
            list.AddFirst(torill);

            Assert.AreEqual(3, list.CountUsers());
        }

        [TestMethod]
        public void TestRemoveUser()
        {
            LinkedList list = new ();
            list.AddFirst(kristian);
            list.AddFirst(mads);
            list.AddFirst(torill);
            list.AddFirst(henrik);
            list.AddFirst(klaus);

            list.RemoveUser(mads);

            Assert.AreEqual(4, list.CountUsers());
            
            list.RemoveUser(kristian);
            
            Assert.AreEqual(3, list.CountUsers());
        }

        [TestMethod]
        public void TestGetLast()
        {
            LinkedList list = new ();
            list.AddFirst(kristian);
            list.AddFirst(mads);
            list.AddFirst(torill);
            list.AddFirst(henrik);
            list.AddFirst(klaus);

            Assert.AreEqual(kristian.Name, list.GetLast().Name);
        }

        [TestMethod]
        public void TestContains()
        {
            LinkedList list = new();
            list.AddFirst(kristian);
            list.AddFirst(mads);
            list.AddFirst(torill);
            list.AddFirst(henrik);
            list.AddFirst(klaus);

            Assert.IsTrue(list.Contains(torill));
            Assert.IsFalse(list.Contains(simon));
            Assert.IsTrue(list.Contains(klaus));
        }
    }
}