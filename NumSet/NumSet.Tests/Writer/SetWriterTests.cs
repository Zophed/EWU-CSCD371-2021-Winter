using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assingment4.Writer;
using System.IO;
using System;

namespace Assingment4.Tests.Writer
{
    [TestClass]
    public class SetWriterTests
    {
        [TestMethod]
        public void Constructor_CreatesNewStreamWriter()
        {
            //Assign
            string temp = Path.GetTempFileName();
            SetWriter setWriter = new SetWriter(temp);

            //Act

            //Assert
            Assert.IsNotNull(setWriter.FileWriter);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_PassesNullNumSet_ThrowsException()
        {
            _ = new SetWriter(null);
        }

        [TestMethod]
        public void WriteToFile_MessageOnFileMatches()
        {
            string filePath = "";
            //Assign
            int[] arrayTemp = new int[] { 1, 2 };
            NumSet numSet = new NumSet(arrayTemp);
            filePath = Path.GetTempFileName();
            SetWriter setWriter = new SetWriter(filePath);

            //Act
            setWriter.WriteToFile(numSet);
            setWriter.Dispose();
            //Assert
            Assert.AreEqual(File.ReadAllText(filePath), "1, 2");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WriteToFile_PassesNullArgument_ThrowsException()
        {
            string temp = Path.GetTempFileName();
            SetWriter setWriter = new SetWriter(temp);
            NumSet numSet = new NumSet();
            numSet.IntSet = null;

            setWriter.WriteToFile(numSet);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WriteToFile_FileWriterIsNull_ThrowsException()
        {
            string temp = Path.GetTempFileName();
            int[] intArray = new int[] { 1, 2 };
            SetWriter setWriter = new SetWriter(temp);
            NumSet numSet = new NumSet(intArray);
            setWriter.FileWriter = null;
            setWriter.WriteToFile(numSet);
        }
    }
}
