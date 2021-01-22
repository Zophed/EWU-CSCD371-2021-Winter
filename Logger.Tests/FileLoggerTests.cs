using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Logger.Tests
{
    [TestClass]
    public class FileLoggerTests
    {
        [TestMethod]
        public void FileLogger_AssignsFilePath()
        {
            //Arrange
            FileLogger? logger = new FileLogger("testFile");

            //Act
            string temp = "";
            if (logger != null && !string.IsNullOrEmpty(logger.FilePath))
            {
                temp = logger.FilePath;
            }

            //Assert
            Assert.AreEqual(temp, "testFile");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FileLogger_AssingNullFilePath_ReturnsExpectedArgumentNullException()
        {
            //Arrange

            //Act
            _ = new FileLogger(null!);

            //Assert

        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void Log_PassedBadFile_ReturnsFileNotFoundException()
        {
            //Arrange
            FileLogger? fileLogger = new FileLogger("");

            //Act
            fileLogger.Log(LogLevel.Error, "BadFile.txt message");

            //Assert

        }

        [TestMethod]
        public void FileLogger_GoodFilePath_LogMatchesInput()
        {
            string? filePath;
            if (File.Exists("testFile.txt"))
                filePath = "testFile.txt";
            else
                throw new FileNotFoundException();

            //Arrange
            LogFactory? logFactory = new LogFactory();
            logFactory.ConfigureFileLogger(filePath);
            FileLogger? fileLogger = (FileLogger?)logFactory.CreateLogger(nameof(FileLogger));
            string? dateTime = null;

            //Act
            if (fileLogger != null)
            {
                fileLogger.Log(LogLevel.Error, "Message: Test");
                dateTime = DateTime.Now.ToString("yyyy-MM-dd_HH:mm");
            }
            string[]? lines = File.ReadAllLines("testFile.txt");

            //Assert
            Assert.AreEqual("Date/time: " + dateTime, lines[0]);
            Assert.AreEqual(nameof(FileLogger), lines[1]);
            Assert.AreEqual(nameof(LogLevel.Error), lines[2]);
            Assert.AreEqual("Message: Test", lines[3]);
        }
    }
}
