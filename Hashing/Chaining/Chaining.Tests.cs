using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Hashing.Chaining.Tests
{
    [TestClass]
    public class Chaining_Tests
    {
		[TestMethod]
		public void TestAdd()
		{
			Chaining names = new(13);
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

			names.Add("Adam");

			Assert.AreEqual(9, names.Size());
		}

		[TestMethod]
		public void TestRemove()
		{
			Chaining names = new(13);
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
			Chaining names = new(4);
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

			Assert.IsTrue(names.Contains("Nina"));
			Assert.IsTrue(names.Contains("Romeo"));
			Assert.IsTrue(names.Contains("Sarah"));

			names.Remove("Romeo");

			Assert.IsFalse(names.Contains("Romeo"));
		}

		[TestMethod]
		public void TestReHash()
		{
			Chaining names = new(6);
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
	}
}
