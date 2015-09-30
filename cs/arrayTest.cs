using NUnit.Framework;
using System.Linq;
using System.Collections.Generic; // List

[TestFixture]
public class ArrayTest
{

    [Test]
    public void CreateArray()
    {
        var array = new List<string>() {"apple", "orange"}.AsReadOnly();
        Assert.AreEqual("apple", array[0]);
        Assert.AreEqual("orange", array[1]);
    }

    [Test]
    public void CreateArrayMutable()
    {
        // https://msdn.microsoft.com/en-us/library/6sh2ey19(v=vs.110).aspx
        var array = new List<string>() {"apple", "orange"};
        Assert.AreEqual("apple", array[0]);
        Assert.AreEqual("orange", array[1]);
    }

    [Test]
    public void AddMutate()
    {
        var array = new List<int>() {1, 2};
        array.Insert(1, 10);
        array.Add(3);
        Assert.AreEqual(10, array[1]);
        Assert.AreEqual(3, array[3]);
        Assert.AreEqual(4, array.Count);
    }

    [Test]
    public void GetObject()
    {
        var array = new List<string>() {"apple", "orange"};
        Assert.AreEqual("apple", array[0]);
    }

    [Test]
    public void GetIndex()
    {
        var array = new List<string>() {"apple", "orange"};
        Assert.AreEqual(0, array.IndexOf("apple"));
    }

    [Test]
    public void Include()
    {
        var array = new List<string>() {"apple", "orange"};
        Assert.AreEqual(true, array.Contains("apple"));
    }

    [Test]
    public void RemoveMutate()
    {
        var array = new List<int>() {1, 2, 3, 4, 4};
        array.RemoveAt(0);
        array.RemoveAll(x => x == 4);
        Assert.AreEqual(2, array.Count);
    }

    [Test]
    public void Each()
    {
        var array = new List<int>() {1, 2};
        int sum = 0;
        array.ForEach((x) => sum += x);
        Assert.AreEqual(3, sum);
    }

    [Test]
    public void EachWithIndex()
    {
        var array = new List<int>() {1, 2};
        int sum = 0;
        int i = 0;
        array.ForEach((x) => {
            sum += x * i;
            i++;
        });
        Assert.AreEqual(2, sum);
    }

    [Test]
    public void Map()
    {
        var array = new List<int>() {1, 2};
        var newArray = array.Select(x => x + 1).ToArray();
        Assert.AreEqual(2, newArray[0]);
        Assert.AreEqual(3, newArray[1]);
    }

    [Test]
    public void MapWithIndex()
    {
        var array = new List<int>() {1, 2};
        var newArray = array.Select((x, i) => x + i).ToArray();
        Assert.AreEqual(1, newArray[0]);
        Assert.AreEqual(3, newArray[1]);
    }

    [Test]
    public void Inject()
    {
        var array = new List<int>() {1, 2};
        var sum = array.Aggregate(0, (s, x) => s + x);
        Assert.AreEqual(3, sum);
    }

    [Test]
    public void InjectWithIndex()
    {
        var array = new List<int>() {1, 2};
        var i = 0;
        var sum = array.Aggregate(0, (s, x) => {
            return s + x * i++;
        });
        Assert.AreEqual(2, sum);
    }

    [Test]
    public void Select()
    {
        var array = new List<int>() {1, 2};
        var newArray = array.Where(x => x > 1).ToArray();
        Assert.AreEqual(1, newArray.Count());
        Assert.AreEqual(2, newArray[0]);
    }

    [Test]
    public void SelectMutate()
    {
        var array = new List<int>() {1, 2};
        array.RemoveAll(x => !(x > 1));
        Assert.AreEqual(1, array.Count());
        Assert.AreEqual(2, array[0]);
    }

    [Test]
    public void Compact()
    {
        var array = new List<int?>() {1, null, 2};
        var newArray = array.Where(x => x != null);
        Assert.AreEqual(2, newArray.Count());
    }

    [Test]
    public void CompactMutate()
    {
        var array = new List<int?>() {1, null, 2};
        array.RemoveAll(x => x == null);
        Assert.AreEqual(2, array.Count());
    }

    [Test]
    public void Sort()
    {
        var array = new List<int>() {2, 1};
        Assert.AreEqual(1, array.OrderBy(x => x).First());
        Assert.AreEqual(2, array.OrderBy(x => x).Reverse().First());
    }

    [Test]
    public void SortMutate()
    {
        var array = new List<int>() {2, 1};
        array.Sort();
        Assert.AreEqual(1, array[0]);
        array.Sort((a, b) => b.CompareTo(a));
        Assert.AreEqual(2, array[0]);
        array.Sort((a, b) => a == b ? 0 : (a > b ? 1 : -1));
        Assert.AreEqual(1, array[0]);
    }

}
