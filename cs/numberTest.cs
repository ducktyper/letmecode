using NUnit.Framework;

[TestFixture]
public class NumberTest
{

    [Test]
    public void Plus()
    {
        Assert.AreEqual(5, 3 + 2);
    }

    [Test]
    public void Minus()
    {
        Assert.AreEqual(1, 3 - 2);
    }

    [Test]
    public void Divide()
    {
        Assert.AreEqual(1, 3 / 2);
    }

    [Test]
    public void Multiply()
    {
        Assert.AreEqual(6, 3 * 2);
    }

    [Test]
    public void Remainder()
    {
        Assert.AreEqual(1, 3 % 2);
    }

    [Test]
    public void Power()
    {
        Assert.AreEqual(9, System.Math.Pow(3, 2));
    }

    [Test]
    public void StringToNumber()
    {
        Assert.AreEqual(1, System.Convert.ToDouble("1"));
        double actual;
        Assert.AreEqual(false, System.Double.TryParse("string", out actual));
        Assert.AreEqual(0, actual);
    }

    [Test]
    public void Abs()
    {
        Assert.AreEqual(10, System.Math.Abs(-10));
    }

    [Test]
    public void Floor()
    {
        Assert.AreEqual(1, System.Math.Floor(1.3));
    }

    [Test]
    public void Round()
    {
        Assert.AreEqual(2, System.Math.Round(1.5));
    }

    [Test]
    public void IEEE754Float()
    {
        Assert.AreEqual(110.00000000000001, 100 * 1.1);
        Assert.AreEqual(0.30000000000000004, 0.1 + 0.2);
    }

    [Test]
    public void AccurateFloatCalculation()
    {
        Assert.AreEqual(110, 100 * (decimal)1.1);
        Assert.AreEqual(0.3, 0.1m + 0.2m);
    }

    [Test]
    public void Cos()
    {
        // https://msdn.microsoft.com/en-us/library/system.math(v=vs.110).aspx
        Assert.AreEqual(-1, System.Math.Cos(System.Math.PI));
    }

}
