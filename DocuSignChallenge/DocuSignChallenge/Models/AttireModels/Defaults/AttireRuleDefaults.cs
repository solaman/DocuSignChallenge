namespace DocuSignChallenge.Models.AttireModels.Defaults
{
    /// <summary>
    /// Prepares AttireHandler with default rules. These should dictate
    /// when a piece of attire can be taken on/off.
    /// </summary>
   public static class AttireRuleDefaults
    {
        /// <summary>
        /// Prepares Attire Handler with default rules for when it is "hot" outside.
        /// </summary>
        /// <param name="attireHandler">Attire Handler to prepare.</param>
        /// <returns>The prepared Attire Handler.</returns>
        public static IAttireHandler AddHotAttireHandlerRules(IAttireHandler attireHandler)
        {
            attireHandler = AddDefaultHandlerRules(attireHandler);

            var cannotWearSocksRule = new CannotWearRule(
                Action.PutOn,
                new AttirePiece(AttirePieceType.Socks, "socks"));
            attireHandler.AddRule(cannotWearSocksRule);

            var cannotWearJacketRule = new CannotWearRule(
                Action.PutOn,
                new AttirePiece(AttirePieceType.Jacket, "jacket"));
            attireHandler.AddRule(cannotWearJacketRule);

            return attireHandler;
        }

        /// <summary>
        /// Prepares Attire Handler with default rules for when it is "cold" outside.
        /// </summary>
        /// <param name="attireHandler">Attire Handler to prepare.</param>
        /// <returns>The prepared Attire Handler.</returns>
        public static IAttireHandler AddColdAttireHandlerRules(IAttireHandler attireHandler)
        {
            attireHandler = AddDefaultHandlerRules(attireHandler);

            var socksBeforeShoesRule = new ShouldBeWearingRule(
                Action.PutOn,
                new AttirePiece(AttirePieceType.Footwear, "-"),
                AttirePieceType.Socks,
                true);
            attireHandler.AddRule(socksBeforeShoesRule);

            var shirtBeforeJacketRule = new ShouldBeWearingRule(
                Action.PutOn,
                new AttirePiece(AttirePieceType.Jacket, "-"),
                AttirePieceType.Shirt,
                true);
            attireHandler.AddRule(shirtBeforeJacketRule);

            return attireHandler;
        }

       private static IAttireHandler AddDefaultHandlerRules(IAttireHandler attireHandler)
        {
            var pantsBeforeShoesRule = new ShouldBeWearingRule(
                Action.PutOn,
                new AttirePiece(AttirePieceType.Footwear, "-"),
                AttirePieceType.Pants,
                true);
            attireHandler.AddRule(pantsBeforeShoesRule);

            var shirtBeforeHeadwearRule = new ShouldBeWearingRule(
                Action.PutOn,
                new AttirePiece(AttirePieceType.Headwear, "-"),
                AttirePieceType.Shirt,
                true);
            attireHandler.AddRule(shirtBeforeHeadwearRule);

            return attireHandler;
        }
    }
}
