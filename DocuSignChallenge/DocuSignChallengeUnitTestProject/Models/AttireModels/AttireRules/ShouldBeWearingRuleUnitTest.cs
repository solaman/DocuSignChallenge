using Microsoft.VisualStudio.TestTools.UnitTesting;
using DocuSignChallenge.Models.AttireModels;
using Moq;

namespace DocuSignChallengeUnitTestProject.Models.AttireModels
{
    [TestClass]
    public class ShouldBeWearingRuleUnitTest
    {
        ShouldBeWearingRule shouldBeWearingRule;
        Mock<IAttire> attireMock;
        AttirePiece attirePiece;

        [TestInitialize]
        public void Initialize()
        {
            attireMock = new Mock<IAttire>();
            attirePiece = new AttirePiece(AttirePieceType.Socks, "");
        }

        #region IsSatisfied Tests
        [TestMethod]
        public void TestIsSatisfied_should_return_correctly_when_attire_piece_should_be_present()
        {
            shouldBeWearingRule = new ShouldBeWearingRule(
                Action.PutOn,
                attirePiece,
                AttirePieceType.Footwear,
                true);

            attireMock.Setup(e => e.IsWearing(It.IsAny<AttirePieceType>()))
                .Returns(false);
            Assert.IsFalse(shouldBeWearingRule.IsSatisfied(attireMock.Object));

            attireMock.Setup(e => e.IsWearing(It.IsAny<AttirePieceType>()))
                .Returns(true);
            Assert.IsTrue(shouldBeWearingRule.IsSatisfied(attireMock.Object));
        }

        public void TestIsSatisfied_should_return_correctly_when_attire_piece_should_not_be_present()
        {
            shouldBeWearingRule = new ShouldBeWearingRule(
                Action.PutOn,
                attirePiece,
                AttirePieceType.Footwear,
                false);

            attireMock.Setup(e => e.IsWearing(It.IsAny<AttirePieceType>()))
                .Returns(true);
            Assert.IsFalse(shouldBeWearingRule.IsSatisfied(attireMock.Object));

            attireMock.Setup(e => e.IsWearing(It.IsAny<AttirePieceType>()))
                .Returns(false);
            Assert.IsTrue(shouldBeWearingRule.IsSatisfied(attireMock.Object));
        }

        #endregion IsSatisfied Tests
    }
}

