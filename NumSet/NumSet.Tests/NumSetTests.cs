using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Assingment4.Tests
{
    [TestClass]
    public class NumSetTests
    {
        [TestMethod]
        public void Constructor_PassesParamsArray_AssignsParamsArrayToHashSet()
        {
            //Assign
            int[] intArray = new int[] { 1, 3, 2 };
            HashSet<int> temp = new HashSet<int>(intArray);

            //Act
            NumSet numSet = new NumSet(intArray);

            //Assert
            Assert.IsNotNull(numSet.IntSet);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_PassedNullArgs_ThrowsException()
        {
            var numSet = new NumSet(null);
        }

        [TestMethod]
        public void ReturnArray_TakesLocalHashSet_ReturnsAnIntArray()
        {
            //Assign
            int[] intArray = new int[] { 1, 3, 2 };
            NumSet numSet = new NumSet(intArray);

            //Act
            int[] returnArray = numSet.ReturnArray();

            //Assert
            CollectionAssert.AreEqual(intArray, returnArray);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ReturnArray_HashSetHasNotBeenSetupByConstructor_ThrowsException()
        {
            //Assign
            int[] intArray = new int[] { 1, 3, 2 };
            NumSet numSet = new NumSet(intArray);
            numSet.IntSet = null;

            //Act
            numSet.ReturnArray();

            //Assert

        }

        [TestMethod]
        public void Equals_PassedTwoDifferentNumSet_ReturnsFalse()
        {
            //Assign
            int[] intArray1 = new int[] { 1, 2, 3 };
            int[] intArray2 = new int[] { 1, 2, 4 };
            NumSet numSet1 = new NumSet(intArray1);
            NumSet numSet2 = new NumSet(intArray2);

            //Act

            //Assert
            Assert.IsFalse(numSet1.Equals(numSet2));
        }

        [TestMethod]
        public void Equals_PassedTheSameNumSet_ReturnsTrue()
        {
            //Assign
            int[] intArray = new int[] { 1, 2, 3 };
            NumSet numSet = new NumSet(intArray);

            //Act

            //Assert
            Assert.IsTrue(numSet.Equals(numSet));
        }

        [TestMethod]
        public void Equals_PassedNonNumSetObject_ReturnsFalse()
        {
            //Assign
            int[] intArray = new int[] { 1, 2 };
            NumSet numSet = new NumSet(intArray);
            Object obj = new object();

            //Act

            //Assert
            Assert.IsFalse(numSet.Equals(obj));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Equals_PassedNullIntSet_ThrowsException()
        {
            //Assign
            int[] intArray1 = new int[] { 1, 2, 3 };
            int[] intArray2 = new int[] { 1, 2, 4 };
            NumSet numSet1 = new NumSet(intArray1);
            NumSet numSet2 = new NumSet(intArray2);
            numSet1.IntSet = null;

            //Act
            bool temp = numSet1.Equals(numSet2);

            //Assert

        }

        [TestMethod]
        public void EqualityAndInequality()
        {
            //Assign
            int[] intArray1 = new int[] { 1, 2, 3 };
            int[] intArray2 = new int[] { 1, 2, 4 };
            NumSet numSet1 = new NumSet(intArray1);
            NumSet numSet2 = new NumSet(intArray2);
            NumSet? numSet3 = null;
            NumSet? numSet4 = null;

            //Act

            //Assert
            Assert.IsTrue(numSet3 == numSet4);
            Assert.IsTrue(numSet1 != numSet2);
            Assert.IsFalse(null == numSet1);
            Assert.IsFalse(numSet1 == null);
        }

        [TestMethod]
        public void ToString_ReturnsStringOfHashSet()
        {
            //Assign
            int[] intArray = new int[] { 1, 2 };
            NumSet numSet = new NumSet(intArray);

            //Act
            string temp = numSet.ToString();

            //Assert
            Assert.AreEqual(temp, "1, 2");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ToString_NullHashSet_ThrowsException()
        {
            NumSet? numSet = new NumSet();
            numSet.IntSet = null;
            string v = numSet.ToString();
        }

        [TestMethod]
        public void GetHashCode_ReturnsCorrectHashCode()
        {
            //Assign
            int[] intArray = new int[] { 1, 2 };
            NumSet numSet1 = new NumSet(intArray);
            NumSet numSet2 = numSet1;

            //Act
            int hashCode1 = numSet1.GetHashCode();
            int hashCode2 = numSet2.GetHashCode();

            //Assert
            Assert.IsTrue(hashCode1 == hashCode2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetHashCode_NullSet_ThrowsException()
        {
            //Assert
            NumSet numSet = new NumSet();
            numSet.IntSet = null;

            //Act
            int temp = numSet.GetHashCode();

            //Assert

        }
    }
}
