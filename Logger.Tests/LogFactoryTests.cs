using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace Logger.Tests
{
    [TestClass]
    public class LogFactoryTests
    {
        private static readonly string filePath = "Logger.Tests";
        
        [TestMethod]
        public void ConfigureFileLogger_SetsFilePath()
        {
            //Arrange
            var logger = new LogFactory();
            logger.ConfigureFileLogger(filePath);

            //Act

            //Assert
            Assert.AreEqual(filePath, logger.FilePath);
        }

        [TestMethod]
        public void CreateLogger_MakeFileLogger_ClassNameMatches()
        {
            //Arrange
            LogFactory? logger = new LogFactory();

            //Act
            logger.CreateLogger("FileLogger");

            //Assert
            Assert.AreEqual("FileLogger", logger.ClassName);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void CreateLogger_ReturnsExceptionIfNull()
        {
            //Arrange
            LogFactory? logger = null;

            //Act
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            _ = logger.CreateLogger("");
#pragma warning restore CS8602 // Dereference of a possibly null reference.

            //Assert
        }
    }
}
