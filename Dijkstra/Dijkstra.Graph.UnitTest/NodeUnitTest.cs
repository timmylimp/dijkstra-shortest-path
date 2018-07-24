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

            Assert.IsFalse(node.TryValidate(out List<ValidationResult> validationResults));
            Assert.AreEqual(1, validationResults.Count);
            Assert.AreEqual("The Name field is required.", validationResults[0].ErrorMessage);
        }

        [TestMethod]
        public void Node_TryValidate_WithName_Invalid()
        {
            var node = new Node { Name = "Timmy" };

            Assert.IsTrue(node.TryValidate(out List<ValidationResult> validationResults));
        }
    }
}
