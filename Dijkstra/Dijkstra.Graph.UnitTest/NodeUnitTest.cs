using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Dijkstra.Graph.Utils;

namespace Dijkstra.Graph.UnitTest
{
    [TestClass]
    public class NodeUnitTest
    {
        [TestMethod]
        public void Node_TryValidate_NoName_Invalid()
        {
            var node = new Node { Name = "" };
            List<ValidationResult> validationResults;

            Assert.IsFalse(node.TryValidate(out validationResults));
            Assert.AreEqual(1, validationResults.Count);
            Assert.AreEqual("The Name field is required.", validationResults[0].ErrorMessage);
        }

        [TestMethod]
        public void Node_TryValidate_WithName_Invalid()
        {
            var node = new Node { Name = "Timmy" };
            List<ValidationResult> validationResults;

            Assert.IsTrue(node.TryValidate(out validationResults));
        }
    }
}
