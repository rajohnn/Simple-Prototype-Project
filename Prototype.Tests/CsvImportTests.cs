using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Prototype.Tests.Model;
using Newtonsoft.Json;
using System.IO;

namespace Prototype.Tests {
    [TestClass]
    public class CsvImportTests {
        [TestMethod]
        public void TestImport() {
            var products = GetDixieProducts();
            
            products.ForEach(p => {

            });
        }

        private List<DixieProduct> GetDixieProducts() {            
            var path = Directory.GetCurrentDirectory();
            string file = Path.Combine(path, "data/dixierv-tv2514-072618.json");
            var json = File.ReadAllText(file);

            return JsonConvert.DeserializeObject<List<DixieProduct>>(json);
        }
    }
}
