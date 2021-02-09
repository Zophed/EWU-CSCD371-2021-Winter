using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace GenericsHomework.Tests
{
    [TestClass]
    public class NodeTests
    {
        private static (Node<string>, Node<int>) TestNodes()
        {
            return (new Node<string>("The Dread Pirate Roberts"), new Node<int>(42));
        }

        [TestMethod]
        public void Constructor_SetsCorrectValue()
        {
            //Assign
            var (stringNode, intNode) = TestNodes();

            //Act

            //Assert
            Assert.AreEqual<int>(42, intNode.Value);
            Assert.AreEqual<string>("The Dread Pirate Roberts", stringNode.Value);
        }

        [TestMethod]
        public void ToString_ReturnsCorrectString()
        {
            //Assign
            var (stringNode, intNode) = TestNodes();

            //Act

            //Assert
            Assert.AreEqual<string>("42", intNode.ToString());
            Assert.AreEqual<string>("The Dread Pirate Roberts", stringNode.ToString());
        }

        [TestMethod]
        public void NextProperty_ReturnsCorrectNode()
        {
            //Assign
            Node<string> firstNode = new Node<string>("Princess Buttercup");
            Node<string> secondNode = new Node<string>("Princess Buttercup");

            //Act

            //Assert
            Assert.AreNotEqual<Node<string>>(firstNode, secondNode);
        }

        [TestMethod]
        public void InsertMethodGivenNewNode_AssignsNextAndLoopsBackToNode()
        {
            //Assign
            Node<int> headNode = new Node<int>(42);

            //Act
            headNode.Insert(43);

            //Assert
            Assert.AreEqual<string>("42", headNode.ToString());
            Assert.AreEqual<string>("43", headNode.Next.ToString());
            Assert.AreEqual<string>("42", headNode.Next.Next.ToString());
        }

        [TestMethod]
        public void ClearMethodRan_AllNodesExceptCurrentRemoved()
        {
            //Assign
            var (stringNode, intNode) = TestNodes();

            //Act
            stringNode.Clear();

            //Assert
            Assert.IsTrue(stringNode.ToString() == stringNode.Next.ToString());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ToString_PassedNullNode_ThrowsException()
        {
            //Assign
            Node<string> nullNode = new(null!);

            //Act
            //nullNode.ToString();

            //Assert
            
        }
    }
}
