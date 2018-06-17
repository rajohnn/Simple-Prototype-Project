using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Prototype.Domain.Ext;

namespace Prototype.Tests {
    [TestClass]
    public class MeasurementParseTests {
        [TestMethod]
        public void GetMeasurement() {
            var value = "Displacement (ci)";
            var uom = value.GetMeasurementType();
            Assert.AreEqual("ci", uom);
        }
    }
}
