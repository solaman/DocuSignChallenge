using Microsoft.VisualStudio.TestTools.UnitTesting;
using DocuSignChallenge.Models.AttireModels;
using Moq;

namespace DocuSignChallengeUnitTestProject.Models.AttireModels
{
    [TestClass]
    public class AttireIsReadyCommandUnitTest
    {
        AttireIsReadyCommand attireIsReadyCommand;
        Mock<IAttireHandler> attireHandlerMock;

        [TestInitialize]
        public void Initialize()
        {
            attireHandlerMock = new Mock<IAttireHandler>();
            attireIsReadyCommand = new AttireIsReadyCommand("making my way down town");
        }

        #region Execute Test
        [TestMethod]
        public void TestExecute_should_check_if_ready()
        {
            attireHandlerMock.Setup(mock => mock.IsReady())
                .Returns(true);

            Assert.IsTrue(attireIsReadyCommand.Execute(attireHandlerMock.Object));
            attireHandlerMock.Verify(mock => mock.IsReady());
        }

        [TestMethod]
        public void TestExecute_should_return_success_of_attempt()
        {
            attireHandlerMock.Setup(mock => mock.IsReady())
                .Returns(true);

            Assert.IsTrue(attireIsReadyCommand.Execute(attireHandlerMock.Object));

            attireHandlerMock.Setup(mock => mock.IsReady())
                .Returns(false);

            Assert.IsFalse(attireIsReadyCommand.Execute(attireHandlerMock.Object));
        }
        #endregion Execute Test
    }
}
