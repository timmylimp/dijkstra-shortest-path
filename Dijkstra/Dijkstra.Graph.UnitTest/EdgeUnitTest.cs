using Dijkstra.Graph.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dijkstra.Graph.UnitTest
{
    [TestClass]
    public class EdgeUnitTest
    {
        [TestMethod]
        public void Node_TryValidate_NoSource_Invalid()
        {
            var edge = new Edge { Destination = new Node(), Weight = 1 };

            Assert.IsFalse(edge.TryValidate(out List<ValidationResult> validationResults));
            Assert.AreEqual(1, validationResults.Count);
            Assert.AreEqual("The Source field is required.", validationResults[0].ErrorMessage);
        }

        [TestMethod]
        public void Node_TryValidate_NoDestination_Invalid()
        {
            var edge = new Edge { Source = new Node(), Weight = 1 };

            Assert.IsFalse(edge.TryValidate(out List<ValidationResult> validationResults));
            Assert.AreEqual(1, validationResults.Count);
            Assert.AreEqual("The Destination field is required.", validationResults[0].ErrorMessage);
        }

        [TestMethod]
        public void Node_TryValidate_WeightLessThan0_Invalid()
        {
            var edge = new Edge { Source = new Node(), Destination = new Node(), Weight = -1 };

            Assert.IsFalse(edge.TryValidate(out List<ValidationResult> validationResults));
            Assert.AreEqual(1, validationResults.Count);
            Assert.AreEqual("The field Weight must be greater or equal 0.", validationResults[0].ErrorMessage);
        }

        [TestMethod]
        public void Node_TryValidate_FullDataWeightIs0_Valid()
        {
            var edge = new Edge { Source = new Node(), Destination = new Node(), Weight = 0 };

            Assert.IsTrue(edge.TryValidate(out List<ValidationResult> validationResults));
        }

        [TestMethod]
        public void Node_TryValidate_FullDataWeightIs10_Valid()
        {
            var edge = new Edge { Source = new Node(), Destination = new Node(), Weight = 10 };

            Assert.IsTrue(edge.TryValidate(out List<ValidationResult> validationResults));
        }

        [TestMethod]
        public void Node_TryValidate_FullDataWeightIsMaxInt_Valid()
        {
            var edge = new Edge { Source = new Node(), Destination = new Node(), Weight = int.MaxValue };

            Assert.IsTrue(edge.TryValidate(out List<ValidationResult> validationResults));
        }
    }
}
