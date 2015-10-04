using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Letmecode
{
    [TestClass]
    public class NumberTest
    {
        [TestMethod]
        public void Plus()
        {
            Assert.AreEqual(5, 3 + 2);
        }

        [TestMethod]
        public void Minus()
        {
            Assert.AreEqual(1, 3 - 2);
        }

        [TestMethod]
        public void Divide()
        {
            Assert.AreEqual(1, 3 / 2);
        }

        [TestMethod]
        public void Multiply()
        {
            Assert.AreEqual(6, 3 * 2);
        }

        [TestMethod]
        public void Remainder()
        {
            Assert.AreEqual(1, 3 % 2);
        }

        [TestMethod]
        public void Power()
        {
            Assert.AreEqual(9, System.Math.Pow(3, 2));
        }

        [TestMethod]
        public void StringToNumber()
        {
            Assert.AreEqual(1, System.Convert.ToDouble("1"));
            double actual;
            Assert.AreEqual(false, System.Double.TryParse("string", out actual));
            Assert.AreEqual(0, actual);
        }

        [TestMethod]
        public void Abs()
        {
            Assert.AreEqual(10, System.Math.Abs(-10));
        }

        [TestMethod]
        public void Floor()
        {
            Assert.AreEqual(1, System.Math.Floor(1.3));
        }

        [TestMethod]
        public void Round()
        {
            Assert.AreEqual(2, System.Math.Round(1.5));
        }

        [TestMethod]
        public void IEEE754Float()
        {
            Assert.AreEqual(110.00000000000001, 100 * 1.1);
            Assert.AreEqual(0.30000000000000004, 0.1 + 0.2);
        }

        [TestMethod]
        public void AccurateFloatCalculation()
        {
            Assert.AreEqual(110m, 100 * (decimal)1.1);
            Assert.AreEqual(0.3m, 0.1m + 0.2m);
        }

        [TestMethod]
        public void Cos()
        {
            // https://msdn.microsoft.com/en-us/library/system.math(v=vs.110).aspx
            Assert.AreEqual(-1, System.Math.Cos(System.Math.PI));
        }
    }
}
