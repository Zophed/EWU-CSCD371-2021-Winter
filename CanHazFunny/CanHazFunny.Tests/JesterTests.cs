using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace CanHazFunny.Tests
{
    [TestClass]
    public class JesterTests
    {
        [TestMethod]
        public void JesterConstructor_AssignsServices()
        {
            //Assign
            //Mock<JokeService> mockJoke = new Mock<JokeService>();
            //mockJoke.Setup(jokeService => jokeService.GetJoke())
            //        .Returns("Big joke, lots of laughs. Stand-up career in near future");

            //Mock<JokeOutputService> mockOutput = new Mock<JokeOutputService>();
            //mockOutput.Setup(outputService => outputService.PrintJoke("joke"));
            JokeService jokeService = new JokeService();
            JokeOutputService outputService = new JokeOutputService();

            //Act
            Jester jokeTest = new Jester(outputService, jokeService);

            //Assert
            Assert.IsNotNull(jokeTest.JokeService);
            Assert.IsNotNull(jokeTest.OutputService);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void JesterConstructor_AssignsNullService_ThrowsError()
        {
            //Assign
            JokeService jokeService = null;
            JokeOutputService outputService = null;

            //Act
            _ = new Jester(outputService, jokeService);

            //Assert
        }

        [TestMethod]
        public void GetJoke_ServiceSendsForJoke_ReturnsJokeToString()
        {
            //Assign
            JokeService jokeService = new JokeService();
            JokeOutputService outputService = new JokeOutputService();
            Jester jester = new Jester(outputService, jokeService);

            //Act
            string result = jester.GetJoke();

            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TellJoke_FiltersOutChuckNorris()
        {
            //Assign
            JokeService jokeService = new JokeService();
            JokeOutputService outputService = new JokeOutputService();
            Jester jester = new Jester(outputService, jokeService);

            //Act
            jester.TellJoke();

            //Assert
            //mockJoke.Verify(mock => mock.GetJoke(), Times.Once());
        }

    //[TestMethod]
    //public void PrintJoke_WritesInputJokeIntoConsole()
    //{
    //    //Assign
    //    JokeService jokeService = new JokeService();
    //    JokeOutputService outputService = new JokeOutputService();
    //    Jester jester = new Jester(outputService, jokeService);

    //    //Act


    //    //Assert
    //}
}
}
