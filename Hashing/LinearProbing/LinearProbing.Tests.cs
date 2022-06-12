using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Hashing.LinearProbing.Tests
{
    [TestClass]
    public class Hashing_Tests
    {
        [TestMethod]
        public void TestAdd()
        {
            LinearProbing names = new(13);
            names.Add("Harry");
            names.Add("Sue");
            names.Add("Nina");
            names.Add("Susannah");
            names.Add("Larry");
            names.Add("Eve");
            names.Add("Sarah");
            names.Add("Adam");
            names.Add("Tony");

            Assert.AreEqual(9, names.Size());
        }

        [TestMethod]
        public void TestRemove()
        {
            LinearProbing names = new(13);
            names.Add("Harry");
            names.Add("Sue");
            names.Add("Nina");
            names.Add("Susannah");
            names.Add("Larry");
            names.Remove("Larry");
            names.Remove("Nina");

            Assert.AreEqual(3, names.Size());

            names.Remove("Romeo");

            Assert.AreEqual(3, names.Size());
        }

        [TestMethod]
        public void TestContains()
        {
            LinearProbing names = new(13);
            names.Add("Harry");
            names.Add("Sue");
            names.Add("Nina");
            names.Add("Susannah");
            names.Add("Larry");

            Assert.IsTrue(names.Contains("Nina"));
            Assert.IsTrue(names.Contains("Harry"));

            names.Remove("Sue");

            Assert.IsFalse(names.Contains("Sue"));
            Assert.IsTrue(names.Contains("Susannah"));
        }

        [TestMethod]
        public void TestRehashAdd()
        {
            LinearProbing names = new(6);
            names.Add("Harry");
            names.Add("Sue");
            names.Add("Nina");
            names.Add("Susannah");
            names.Add("Larry");
            names.Add("Eve");
            names.Add("Sarah");
            names.Add("Adam");
            names.Add("Tony");
            names.Add("Katherine");
            names.Add("Juliet");
            names.Add("Romeo");

            Assert.AreEqual(12, names.Size());
        }

        [TestMethod]
        public void TestRehashContains()
        {
            LinearProbing names = new(6);
            names.Add("Harry");
            names.Add("Sue");
            names.Add("Nina");
            names.Add("Susannah");
            names.Add("Larry");
            names.Add("Eve");

            Assert.IsTrue(names.Contains("Nina"));
            Assert.IsTrue(names.Contains("Harry"));

            names.Remove("Sue");

            Assert.IsFalse(names.Contains("Sue"));
            Assert.IsTrue(names.Contains("Susannah"));
        }
    }
}