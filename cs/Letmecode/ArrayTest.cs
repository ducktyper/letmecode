using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Collections.Generic; // List

namespace Letmecode
{
    [TestClass]
    public class ArrayTest
    {
        [TestMethod]
        public void CreateArray()
        {
            var array = new List<string>() { "apple", "orange" }.AsReadOnly();
            Assert.AreEqual("apple", array[0]);
            Assert.AreEqual("orange", array[1]);
        }

        [TestMethod]
        public void CreateArrayMutable()
        {
            // https://msdn.microsoft.com/en-us/library/6sh2ey19(v=vs.110).aspx
            var array = new List<string>() { "apple", "orange" };
            Assert.AreEqual("apple", array[0]);
            Assert.AreEqual("orange", array[1]);
        }

        [TestMethod]
        public void AddMutate()
        {
            var array = new List<int>() { 1, 2 };
            array.Insert(1, 10);
            array.Add(3);
            Assert.AreEqual(10, array[1]);
            Assert.AreEqual(3, array[3]);
            Assert.AreEqual(4, array.Count);
        }

        [TestMethod]
        public void GetObject()
        {
            var array = new List<string>() { "apple", "orange" };
            Assert.AreEqual("apple", array[0]);
        }

        [TestMethod]
        public void GetIndex()
        {
            var array = new List<string>() { "apple", "orange" };
            Assert.AreEqual(0, array.IndexOf("apple"));
        }

        [TestMethod]
        public void Include()
        {
            var array = new List<string>() { "apple", "orange" };
            Assert.AreEqual(true, array.Contains("apple"));
        }

        [TestMethod]
        public void RemoveMutate()
        {
            var array = new List<int>() { 1, 2, 3, 4, 4 };
            array.RemoveAt(0);
            array.RemoveAll(x => x == 4);
            Assert.AreEqual(2, array.Count);
        }

        [TestMethod]
        public void Each()
        {
            var array = new List<int>() { 1, 2 };
            int sum = 0;
            array.ForEach((x) => sum += x);
            Assert.AreEqual(3, sum);
        }

        [TestMethod]
        public void EachWithIndex()
        {
            var array = new List<int>() { 1, 2 };
            int sum = 0;
            int i = 0;
            array.ForEach((x) => {
                sum += x * i;
                i++;
            });
            Assert.AreEqual(2, sum);
        }

        [TestMethod]
        public void Map()
        {
            var array = new List<int>() { 1, 2 };
            var newArray = array.Select(x => x + 1).ToArray();
            Assert.AreEqual(2, newArray[0]);
            Assert.AreEqual(3, newArray[1]);
        }

        [TestMethod]
        public void MapWithIndex()
        {
            var array = new List<int>() { 1, 2 };
            var newArray = array.Select((x, i) => x + i).ToArray();
            Assert.AreEqual(1, newArray[0]);
            Assert.AreEqual(3, newArray[1]);
        }

        [TestMethod]
        public void Inject()
        {
            var array = new List<int>() { 1, 2 };
            var sum = array.Aggregate(0, (s, x) => s + x);
            Assert.AreEqual(3, sum);
        }

        [TestMethod]
        public void InjectWithIndex()
        {
            var array = new List<int>() { 1, 2 };
            var i = 0;
            var sum = array.Aggregate(0, (s, x) => {
                return s + x * i++;
            });
            Assert.AreEqual(2, sum);
        }

        [TestMethod]
        public void Select()
        {
            var array = new List<int>() { 1, 2 };
            var newArray = array.Where(x => x > 1).ToArray();
            Assert.AreEqual(1, newArray.Count());
            Assert.AreEqual(2, newArray[0]);
        }

        [TestMethod]
        public void SelectMutate()
        {
            var array = new List<int>() { 1, 2 };
            array.RemoveAll(x => !(x > 1));
            Assert.AreEqual(1, array.Count());
            Assert.AreEqual(2, array[0]);
        }

        [TestMethod]
        public void Compact()
        {
            var array = new List<int?>() { 1, null, 2 };
            var newArray = array.Where(x => x != null);
            Assert.AreEqual(2, newArray.Count());
        }

        [TestMethod]
        public void CompactMutate()
        {
            var array = new List<int?>() { 1, null, 2 };
            array.RemoveAll(x => x == null);
            Assert.AreEqual(2, array.Count());
        }

        public class SmallToLarge : IComparer<int>
        {
            public int Compare(int a, int b)
            {
                return a == b ? 0 : (a > b ? 1 : -1);
            }
        }

        [TestMethod]
        public void Sort()
        {
            var array = new List<int>() { 2, 1 };
            Assert.AreEqual(1, array.OrderBy(x => x).First());
            Assert.AreEqual(2, array.OrderBy(x => x).Reverse().First());
            Assert.AreEqual(1, array.OrderBy(x => x, new SmallToLarge()).First());
        }

        [TestMethod]
        public void SortMutate()
        {
            var array = new List<int>() { 2, 1 };
            array.Sort();
            Assert.AreEqual(1, array[0]);
            array.Sort((a, b) => b.CompareTo(a));
            Assert.AreEqual(2, array[0]);
            array.Sort((a, b) => a == b ? 0 : (a > b ? 1 : -1));
            Assert.AreEqual(1, array[0]);
        }
    }
}
