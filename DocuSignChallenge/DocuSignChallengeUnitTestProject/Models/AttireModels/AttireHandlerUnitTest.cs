using Microsoft.VisualStudio.TestTools.UnitTesting;
using DocuSignChallenge.Models.AttireModels;
using Moq;

namespace DocuSignChallengeUnitTestProject.Models.AttireModels
{
    [TestClass]
    public class AttireHandlerUnitTest
    {
        AttireHandler attireHandler;

        [TestMethod]
        public void TestAddRule_correctly_affects_how_the_state_can_change()
        {
            attireHandler = new AttireHandler();
            AttirePiece pajamas = new AttirePiece(AttirePieceType.Shirt, "pajamas");
            Assert.IsTrue(attireHandler.ChangeState(Action.TakeOff, pajamas) );

            attireHandler = new AttireHandler();
            Mock<IAttireRule> mockRule = new Mock<IAttireRule>();
            mockRule.Setup(e => e.GetTriggerAction())
                .Returns(Action.TakeOff);
            mockRule.Setup(e => e.GetTriggerAttirePiece())
                .Returns(pajamas);
            mockRule.Setup(e => e.IsSatisfied(It.IsAny<Attire>()))
                .Returns(false);

            attireHandler.AddRule(mockRule.Object);

            Assert.IsFalse(attireHandler.ChangeState(Action.TakeOff, pajamas));
        }

        [TestMethod]
        public void TestMustWear_correctly_affects_when_the_attire_is_ready()
        {
            attireHandler = new AttireHandler();
            Assert.IsTrue(attireHandler.IsReady());

            attireHandler.AddMustWear(AttirePieceType.Footwear);
            Assert.IsFalse(attireHandler.IsReady());
        }
    }
}
