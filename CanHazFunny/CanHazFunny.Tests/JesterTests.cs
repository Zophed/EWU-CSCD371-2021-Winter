using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace CanHazFunny.Tests
{
    [TestClass]
    public class JesterTests
    {
        [TestMethod]
        public void JesterConstructor_AssignsServices_ValidJokeService()
        {
            //Assign
            IJokeService jokeService = new JokeService();
            IJokeOutput outputService = new JokeOutputService();

            //Act
            Jester jokeTest = new Jester(outputService, jokeService);

            //Assert
            Assert.IsNotNull(jokeTest.JokeService);
            Assert.IsNotNull(jokeTest.JokeOutputService);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void JesterConstructor_AssignsNullJokeService_ThrowsError()
        {
            //Assign
            _ = new Jester(new JokeOutputService(), null);
            
            //Act

            //Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void JesterConstructor_AssignsNullOutputService_ThrowsError()
        {
            //Assign
            _ = new Jester(null, new JokeService());

            //Act

            //Assert
        }

        [TestMethod]
        public void JokeServiceGetJoke_ServiceSendsForJoke_ReturnsJokeToString()
        {
            //Assign
            IJokeService jokeService = new JokeService();

            //Act
            string result = jokeService.GetJoke();

            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TellJoke_FiltersOutChuckNorris_RetryUntilNoNorris()
        {
            //Assign
            Mock<IJokeService> mock = new Mock<IJokeService>();
            mock.SetupSequence(JokeService => JokeService.GetJoke())
                .Returns("Chuck Norris joke")
                .Returns("Chuck Norris sucks")
                .Returns("Knock Knock joke");
            Jester jester = new Jester(new JokeOutputService(), mock.Object);

            //Act
            jester.TellJoke();


            //Assert
            mock.Verify(jokeService => jokeService.GetJoke(), Times.Exactly(3));
        }

        [TestMethod]
        public void PrintJoke_WritesInputJokeIntoConsole()
        {
            //Assign
            Mock<IJokeService> mockJoke = new Mock<IJokeService>();
            mockJoke.SetupSequence(jokeService => jokeService.GetJoke())
                .Returns("Knock Knock joke");

            Mock<IJokeOutput> mockOutput = new Mock<IJokeOutput>();
            mockOutput.SetupSequence(jokeOutput => jokeOutput.PrintJoke("Knock Knock joke"));
            Jester jester = new Jester(mockOutput.Object, mockJoke.Object);

            //Act
            jester.TellJoke();

            //Assert
            mockOutput.VerifyAll();
        }
    }
}
