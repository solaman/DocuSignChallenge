using Microsoft.VisualStudio.TestTools.UnitTesting;
using DocuSignChallenge.Models.AttireModels;
using Moq;

namespace DocuSignChallengeUnitTestProject.Models.AttireModels
{
    [TestClass]
    public class AttireChangeCommandUnitTest
    {
        AttireChangeCommand attireChangeCommand;
        Mock<IAttireHandler> attireHandlerMock;
        AttirePiece attirePiece;

        [TestInitialize]
        public void Initialize()
        {
            attireHandlerMock = new Mock<IAttireHandler>();
            attirePiece = new AttirePiece(AttirePieceType.Shirt, "v-neck");
            attireChangeCommand = new AttireChangeCommand(
                Action.PutOn,
                attirePiece,
                "Putting on the v-neck");
        }

        #region Execute Test
        [TestMethod]
        public void TestExecute_should_attempt_to_put_on_attire_piece()
        {
            attireHandlerMock.Setup(mock => mock.ChangeState(It.IsAny<Action>(), It.IsAny<AttirePiece>()))
                .Returns(true);

            Assert.IsTrue(attireChangeCommand.Execute(attireHandlerMock.Object));
            attireHandlerMock.Verify(mock => mock.ChangeState(Action.PutOn, attirePiece));
        }

        [TestMethod]
        public void TestExecute_should_return_success_of_attempt()
        {
            attireHandlerMock.Setup(mock => mock.ChangeState(It.IsAny<Action>(), It.IsAny<AttirePiece>()))
                .Returns(true);

            Assert.IsTrue(attireChangeCommand.Execute(attireHandlerMock.Object));

            attireHandlerMock.Setup(mock => mock.ChangeState(It.IsAny<Action>(), It.IsAny<AttirePiece>()))
                .Returns(false);

            Assert.IsFalse(attireChangeCommand.Execute(attireHandlerMock.Object));
        }
        #endregion Execute Test
    }
}
