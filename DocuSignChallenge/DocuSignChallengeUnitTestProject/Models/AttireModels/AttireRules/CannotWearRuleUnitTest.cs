using Microsoft.VisualStudio.TestTools.UnitTesting;
using DocuSignChallenge.Models.AttireModels;
using Moq;

namespace DocuSignChallengeUnitTestProject.Models.AttireModels
{
    [TestClass]
    public class CannotWearRuleUnitTest
    {
        CannotWearRule cannotWearRule;
        Mock<Attire> attireMock;
        AttirePiece attirePiece;

        [TestInitialize]
        public void Initialize()
        {
            attireMock = new Mock<Attire>();
            attirePiece = new AttirePiece(AttirePieceType.Socks, "");
            cannotWearRule = new CannotWearRule(Action.PutOn, attirePiece);
        }

        #region IsSatisfied region
        [TestMethod]
        public void TestIsSatisfied_should_never_be_satisfied()
        {
            Assert.IsFalse(cannotWearRule.IsSatisfied(attireMock.Object));
        }
        #endregion IsSatisfied region
    }
}
