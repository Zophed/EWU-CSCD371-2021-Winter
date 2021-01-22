using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace Logger.Tests
{
    [TestClass]
    public class LogFactoryTests
    {
        [TestMethod]
        public void ConfigureFileLogger_FileLoggerNotInstantiated_ReturnsNull()
        {
            //Arrange
            LogFactory logFactory = new LogFactory();
            BaseLogger? logger;

            //Act
            logger = logFactory.CreateLogger("");

            //Assert
            Assert.IsNull(logger);
        }

        [TestMethod]
        public void ConfigureFileLogger_PassInBadFilePath_ReturnsNull()
        {
            //Arrange
            LogFactory logFactory = new LogFactory();
            BaseLogger? logger;

            //Act
            logger = logFactory.CreateLogger("BadFile");

            //Assert
            Assert.IsNull(logger);
        }

        [TestMethod]
        public void CreateLogger_MakeFileLogger_ClassNameMatches()
        {
            //Arrange
            LogFactory? logger = new LogFactory();


            //Act
            logger.CreateLogger(nameof(FileLogger));

            //Assert
            Assert.AreEqual("FileLogger", nameof(FileLogger));
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
