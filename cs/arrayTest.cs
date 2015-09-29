using NUnit.Framework;
using System.Linq;

[TestFixture]
public class ArrayTest
{

    [Test]
    public void CreateArray()
    {
        // https://msdn.microsoft.com/en-us/library/aa288453(v=vs.71).aspx
        Assert.AreEqual("apple", new [] {"apple", "orange"}[0]);
        Assert.AreEqual("orange", new string[] {"apple", "orange"}[1]);
    }

    [Test]
    public void CreateArrayMutable()
    {
        // https://msdn.microsoft.com/en-us/library/6sh2ey19(v=vs.110).aspx
        var array = new System.Collections.Generic.List<string>() {"apple", "orange"};
        Assert.AreEqual("apple", array[0]);
        Assert.AreEqual("orange", array[1]);
    }

    [Test]
    public void AddMutate()
    {
        var array = new System.Collections.Generic.List<int>() {1, 2};
        array.Insert(1, 10);
        array.Add(3);
        Assert.AreEqual(10, array[1]);
        Assert.AreEqual(4, array.Count);
    }

    [Test]
    public void GetObject()
    {
        var array = new []{"apple", "orange"};
        Assert.AreEqual("apple", array[0]);
    }

    [Test]
    public void GetIndex()
    {
        var array = new []{"apple", "orange"};
        Assert.AreEqual(0, System.Array.IndexOf(array, "apple"));
        var arrayMutable = new System.Collections.Generic.List<string>() {"apple", "orange"};
        Assert.AreEqual(0, arrayMutable.IndexOf("apple"));
    }

    [Test]
    public void Include()
    {
        var array = new []{"apple", "orange"};
        Assert.AreEqual(true, array.Contains("apple"));
    }

    [Test]
    public void RemoveMutate()
    {
        var array = new System.Collections.Generic.List<int>() {1, 2, 3, 4, 4};
        array.RemoveAt(0);
        array.RemoveAll(x => x == 4);
        Assert.AreEqual(2, array.Count);
    }

    [Test]
    public void Each()
    {
        var array = new []{1, 2};
        int sum = 0;
        foreach (int x in array) { sum += x; }
        Assert.AreEqual(3, sum);
    }

    [Test]
    public void EachWithIndex()
    {
        var array = new []{1, 2};
        int sum = 0;
        int i = 0;
        foreach (int x in array)
        {
            sum += x * i;
            i++;
        }
        Assert.AreEqual(2, sum);
    }

}
