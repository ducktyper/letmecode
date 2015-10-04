using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;
using System.Linq;

namespace Letmecode
{
    [TestClass]
    public class StringTest
    {

        [TestMethod]
        public void ComposeString()
        {
            Assert.AreEqual("apple orange", string.Format("{0} {1}", "apple", "orange"));
        }
        
        [TestMethod]
        public void MultilineString()
        {
            var text = @"apple
orange";
            Assert.AreEqual("apple" + System.Environment.NewLine + "orange", text);
        }

        [TestMethod]
        public void IntToString()
        {
            Assert.AreEqual("1", 1.ToString());
        }

        [TestMethod]
        public void RegexMatch()
        {
            // https://msdn.microsoft.com/en-us/library/az24scfc(v=vs.110).aspx
            Assert.AreEqual(true, new Regex("apple").IsMatch("apple orange "));
            Assert.AreEqual(true, new Regex("orange").IsMatch("apple orange "));
            Assert.AreEqual(false, new Regex("kiwi").IsMatch("apple orange "));
        }

        [TestMethod]
        public void RegexMatches()
        {
            Assert.AreEqual("apple orange",
              Regex.Match("apple orange ", "(apple).*(orange)").Groups[0].Value);
            Assert.AreEqual("apple",
              Regex.Match("apple orange ", "(apple).*(orange)").Groups[1].Value);
            Assert.AreEqual("orange",
              Regex.Match("apple orange ", "(apple).*(orange)").Groups[2].Value);
        }

        [TestMethod]
        public void RegexReplace()
        {
            Assert.AreEqual("orange apple ",
                    Regex.Replace("apple orange ", "(apple).*(orange)", "$2 $1"));
        }

        [TestMethod]
        public void Concat()
        {
            var text = "apple";
            var textBackup = text;
            text += " orange ";
            Assert.AreEqual("apple orange ", text);
            Assert.AreNotEqual(text, textBackup);
        }

        [TestMethod]
        public void ConcatMutate()
        {
            var sb = new System.Text.StringBuilder();
            sb.Append("apple");
            sb.Append(" orange ");
            Assert.AreEqual("apple orange ", sb.ToString());
        }

        [TestMethod]
        public void Length()
        {
            Assert.AreEqual(13, "apple orange ".Length);
        }

        [TestMethod]
        public void Format()
        {
            // https://msdn.microsoft.com/en-us/library/dwhawy9k(v=vs.110).aspx
            Assert.AreEqual("10.0", string.Format("{0:f1}", 10));
            // https://msdn.microsoft.com/en-us/library/8kb3ddd4(v=vs.110).aspx
            Assert.AreEqual("2000-01-01",
              new System.DateTime(2000, 1, 1).ToString("yyyy-MM-dd"));
        }

        [TestMethod]
        public void Split()
        {
            Assert.AreEqual("apple", "apple orange ".Trim().Split(null)[0]);
            Assert.AreEqual(2, "apple orange ".Trim().Split(null).Length);
            Assert.AreEqual("apple", "apple,orange ".Trim().Split(',')[0]);
        }

        [TestMethod]
        public void Strip()
        {
            Assert.AreEqual("a b", " a b ".Trim());
        }

        [TestMethod]
        public void eql()
        {
            Assert.AreEqual(true, "apple" == "apple");
        }
    }
}
