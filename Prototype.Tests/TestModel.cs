using L5.DomainModel.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype.Tests {
    public class TestModel {
        public TestModel() { }
        public void Foo() {
            var product = new Product {
                Name = "Foobar",
                Make = "Test",

            };
        }
    }
}
