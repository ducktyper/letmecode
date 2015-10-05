using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic; // Dictionary
using System.Collections.ObjectModel; // ReadOnlyDictionary
using System.Linq;

namespace Letmecode
{
    [TestClass]
    public class HashTest
    {
        [TestMethod]
        public void CreateHash()
        {
            var hash = new ReadOnlyDictionary<string, string>(
                new Dictionary<string, string>() { { "name", "apple"},  { "price", "3" } }
            );
            Assert.AreEqual("apple", hash["name"]);
            Assert.AreEqual("3", hash["price"]);
        }

        [TestMethod]
        public void CreateHashMutable()
        {
            var hash = new Dictionary<string, string>() {
                { "name", "apple" }, { "price", "3" }
            };
            Assert.AreEqual("apple", hash["name"]);
            Assert.AreEqual("3", hash["price"]);
        }

        [TestMethod]
        public void AddMutable()
        {
            var hash = new Dictionary<string, string>() { { "name", "apple" } };
            hash["price"] = "3";
            Assert.AreEqual("3", hash["price"]);
        }

        [TestMethod]
        public void GetObject()
        {
            var hash = new Dictionary<string, string>() {
                { "name", "apple" }, { "price", "3" }
            };
            Assert.AreEqual("apple", hash["name"]);
        }

        [TestMethod]
        public void IncludeKey()
        {
            var hash = new Dictionary<string, string>() { { "name", "apple" } };
            Assert.AreEqual(true, hash.ContainsKey("name"));
            Assert.AreEqual(false, hash.ContainsKey("unknown"));
        }

        [TestMethod]
        public void RemoveMutate()
        {
            var hash = new Dictionary<string, string>() {
                { "name", "apple" }, { "price", "3" }
            };
            hash.Remove("name");
            Assert.AreEqual(false, hash.ContainsKey("name"));
        }

        [TestMethod]
        public void Each()
        {
            var hash = new Dictionary<string, string>() {
                { "name", "apple" }, { "price", "3" }
            };

            var textBuilder = new System.Text.StringBuilder();
            foreach(var pair in hash)
            {
                textBuilder.Append(pair.Key + "_" + pair.Value + " ");
            }
            Assert.AreEqual("name_apple price_3 ", textBuilder.ToString());
        }

        [TestMethod]
        public void Inject()
        {
            var hash = new Dictionary<string, string>() {
                { "name", "apple" }, { "price", "3" }
            };

            string text = hash.Aggregate("", (str, pair) => {
                return str + pair.Key + "_" + pair.Value + " ";
            });
            Assert.AreEqual("name_apple price_3 ", text);
        }

        [TestMethod]
        public void Select()
        {
            var hash = new Dictionary<string, string>() {
                { "name", "apple" }, { "price", "3" }
            };
            var hash_new = hash.Where(pair => pair.Key == "name").
                ToDictionary(x => x.Key, x => x.Value);
            Assert.AreEqual(false, hash_new.ContainsKey("price"));
        }

        [TestMethod]
        public void SelectMutate()
        {
            var hash = new Dictionary<string, string>() {
                { "name", "apple" }, { "price", "3" }
            };
            var keysToRemove = hash.Keys.Where(x => !(x == "name")).ToArray();
            foreach (var key in keysToRemove) { hash.Remove(key); }
            Assert.AreEqual(true, hash.ContainsKey("name"));
            Assert.AreEqual(false, hash.ContainsKey("price"));
        }
    }
}

