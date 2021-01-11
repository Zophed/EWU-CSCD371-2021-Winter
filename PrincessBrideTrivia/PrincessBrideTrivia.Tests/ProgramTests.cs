using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;

namespace PrincessBrideTrivia.Tests
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void LoadQuestions_RetrievesQuestionsFromFile()
        {
            string filePath = Path.GetRandomFileName();
            try
            {
                // Arrange
                GenerateQuestionsFile(filePath, 2);

                // Act
                Question[] questions = Program.LoadQuestions(filePath);

                // Assert 
                Assert.AreEqual(2, questions.Length);
            }
            finally
            {
                File.Delete(filePath);
            }
        }

        [TestMethod]
        public void GetRandomIndex_ReturnsRandomArrayIndex()
        {
            string filePath = Path.GetRandomFileName();
            try
            {
                //Arrange
                GenerateQuestionsFile(filePath, 5);
                Question[] questions = Program.LoadQuestions(filePath);
                Random random = new Random();
                int[] indices = new int[5];
                int[] indicesUsed = new int[questions.Length];

                //Act
                for(int i = 0; i < indices.Length; i++)
                {
                    while (true)
                    {
                        indices[i] = Program.GetRandomIndex(random, questions);
                        if (!Program.CheckIfArrayContainsInt(indicesUsed, indices[i])) break;
                    }
                    indicesUsed[i] = indices[i];
                }

                //Assert
                HashSet<int> isUnique = new HashSet<int>(indices);
                Assert.AreEqual(indices.Length, isUnique.Count);

            }
            finally
            {
                File.Delete(filePath);
            }
        }

        /*
         * This is a second unit tests that confirms that Program.LoadQuestions() 
         *has correctly filled the 'questions' array
         */
        [TestMethod]
        public void LoadQuestions_RetrievesQuestionsFromFile_CheckContentOfOutputArray()
        {
            string filePath = Path.GetRandomFileName();
            try
            {
                //Arrange
                GenerateQuestionsFile(filePath, 5);

                //Act
                Question[] questions = Program.LoadQuestions(filePath);

                //Assert
                for(int i = 0; i < questions.Length; i++)
                    Assert.IsNotNull(questions[i]);
            }
            finally
            {
                File.Delete(filePath);
            }
        }

        [DataTestMethod]
        [DataRow("1", true)]
        [DataRow("2", false)]
        public void DisplayResult_ReturnsTrueIfCorrect(string userGuess, bool expectedResult)
        {
            // Arrange
            Question question = new Question();
            question.CorrectAnswerIndex = "1";

            // Act
            bool displayResult = Program.DisplayResult(userGuess, question);

            // Assert
            Assert.AreEqual(expectedResult, displayResult);
        }

        [TestMethod]
        public void GetFilePath_ReturnsFileThatExists()
        {
            // Arrange

            // Act
            string filePath = Program.GetFilePath();

            // Assert
            Assert.IsTrue(File.Exists(filePath));
        }

        [DataTestMethod]
        [DataRow(1, 1, "100%")]
        [DataRow(5, 10, "50%")]
        [DataRow(1, 10, "10%")]
        [DataRow(0, 10, "0%")]
        public void GetPercentCorrect_ReturnsExpectedPercentage(int numberOfCorrectGuesses, 
            int numberOfQuestions, string expectedString)
        {
            // Arrange

            // Act
            string percentage = Program.GetPercentCorrect(numberOfCorrectGuesses, numberOfQuestions);

            // Assert
            Assert.AreEqual(expectedString, percentage);
        }

        [TestMethod]
        public void DisplayQuestion_ConsoleOuputIfCorrect()
        {

        }

        private static void GenerateQuestionsFile(string filePath, int numberOfQuestions)
        {
            for (int i = 0; i < numberOfQuestions; i++)
            {
                string[] lines = new string[5];
                lines[0] = "Question " + i + " this is the question text";
                lines[1] = "Answer 1";
                lines[2] = "Answer 2";
                lines[3] = "Answer 3";
                lines[4] = "2";
                File.AppendAllLines(filePath, lines);
            }
        }
    }
}
