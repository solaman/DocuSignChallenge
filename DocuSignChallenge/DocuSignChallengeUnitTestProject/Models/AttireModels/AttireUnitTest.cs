using Microsoft.VisualStudio.TestTools.UnitTesting;
using DocuSignChallenge.Models.AttireModels;

namespace DocuSignChallengeUnitTestProject.Models.AttireModels
{
    [TestClass]
    public class AttireUnitTest
    {
        Attire attire;
        AttirePiece tankTop, tubeTop;

        [TestInitialize]
        public void Initialize()
        {
            attire = new Attire();
            tankTop = new AttirePiece(AttirePieceType.Shirt, "tank-top");
            tubeTop = new AttirePiece(AttirePieceType.Shirt, "tube-top");
        }

        #region PutOn Tests
        [TestMethod]
        public void TestPutOn_should_return_true_only_when_no_matching_attire_piece_type_previously_on()
        { 
            Assert.IsTrue(attire.PutOn(tankTop));
            Assert.IsFalse(attire.PutOn(tubeTop));
            Assert.IsFalse(attire.PutOn(tankTop));
        }
        #endregion PutOn Tests

        #region TakeOff Tests
        [TestMethod]
        public void TestTakeOff_should_return_true_only_when_attire_piece_is_successfully_taken_off()
        {
            Assert.IsFalse(attire.TakeOff(tubeTop));
            attire.PutOn(tubeTop);
            Assert.IsTrue(attire.TakeOff(tubeTop));

            attire.PutOn(tankTop);
            Assert.IsFalse(attire.TakeOff(tubeTop));
        }
        #endregion TakeOff Tests

        #region IsWearing Tests
        [TestMethod]
        public void TestIsWearing_should_return_true_only_if_wearing()
        {
            Assert.IsFalse(attire.IsWearing(tubeTop));
            Assert.IsFalse(attire.IsWearing(tubeTop.type));

            attire.PutOn(tubeTop);
            Assert.IsTrue(attire.IsWearing(tubeTop));
            Assert.IsTrue(attire.IsWearing(tubeTop.type));
        }

        [TestMethod]
        public void TestIsWearing_should_check_appropriate_level()
        {
            Assert.IsFalse(attire.IsWearing(tankTop));
            Assert.IsFalse(attire.IsWearing(tankTop.type));

            attire.PutOn(tubeTop);
            Assert.IsFalse(attire.IsWearing(tankTop));
            Assert.IsTrue(attire.IsWearing(tankTop.type));
        }
        #endregion IsWearing Tests

        #region GetNaked Test
        [TestMethod]
        public void TestGetNaked_removes_all_clothes()
        {
            attire.PutOn(tubeTop);
            AttirePiece boots = new AttirePiece(AttirePieceType.Footwear, "boots");
            attire.PutOn(boots);

            Assert.IsTrue(attire.IsWearing(tubeTop));
            Assert.IsTrue(attire.IsWearing(boots));
            attire.GetNaked();

            Assert.IsFalse(attire.IsWearing(tubeTop));
            Assert.IsFalse(attire.IsWearing(boots));
        }
        #endregion GetNaked Test
    }
}
