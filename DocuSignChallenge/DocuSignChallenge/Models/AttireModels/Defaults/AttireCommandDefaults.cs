using System.Collections.Generic;

namespace DocuSignChallenge.Models.AttireModels.Defaults
{
    /// <summary>
    /// Provides a set of default Attire Commands
    /// that can be retrieved as per function call.
    /// </summary>
    public static class AttireCommandDefaults
    {
        /// <summary>
        /// Prepares default commands used when it is "hot" outside.
        /// </summary>
        /// <returns>Attire commands for when it is "hot" outside</returns>
        public static IList<IAttireCommand> GetHotAttireHandlerCommands()
        {
            IList<IAttireCommand> commands = new List<IAttireCommand>();

            var putOnFootwearCommand = new AttireChangeCommand(
                Action.PutOn,
                new AttirePiece(AttirePieceType.Footwear, "sandals"),
                "sandals");
            commands.Add(putOnFootwearCommand);

            var putOnHeadwearCommand = new AttireChangeCommand(
                Action.PutOn,
                new AttirePiece(AttirePieceType.Headwear, "sun visor"),
                "sun visor");
            commands.Add(putOnHeadwearCommand);

            var putOnSocksCommand = new AttireChangeCommand(
                Action.PutOn,
                new AttirePiece(AttirePieceType.Socks, "socks"),
                "socks");
            commands.Add(putOnSocksCommand);

            var putOnShirtCommand = new AttireChangeCommand(
                Action.PutOn,
                new AttirePiece(AttirePieceType.Shirt, "t-shirt"),
                "t-shirt");
            commands.Add(putOnShirtCommand);

            var putOnJacketCommand = new AttireChangeCommand(
                Action.PutOn,
                new AttirePiece(AttirePieceType.Jacket, "jacket"),
                "jacket");
            commands.Add(putOnJacketCommand);

            var putOnPantsCommand = new AttireChangeCommand(
                Action.PutOn,
                new AttirePiece(AttirePieceType.Pants, "shorts"),
                "shorts");
            commands.Add(putOnPantsCommand);

            var leaveHouseCommand = new AttireIsReadyCommand("leaving house");
            commands.Add(leaveHouseCommand);

            var takeOffPajamasCommand = new AttireChangeCommand(
                Action.TakeOff,
                new AttirePiece(AttirePieceType.Shirt, "pajamas"),
                "Removing PJs");
            commands.Add(takeOffPajamasCommand);

            return commands;
        }

        /// <summary>
        /// Prepares default commands for when it is "cold" outside.
        /// </summary>
        /// <returns>Default commands for when it is "cold" outside.</returns>
        public static IList<IAttireCommand> GetColdAttireHandlerCommands()
        {
            IList<IAttireCommand> commands = new List<IAttireCommand>();

            var putOnFootwearCommand = new AttireChangeCommand(
                Action.PutOn,
                new AttirePiece(AttirePieceType.Footwear, "boots"),
                "boots");
            commands.Add(putOnFootwearCommand);

            var putOnHeadwearCommand = new AttireChangeCommand(
                Action.PutOn,
                new AttirePiece(AttirePieceType.Headwear, "hat"),
                "hat");
            commands.Add(putOnHeadwearCommand);

            var putOnSocksCommand = new AttireChangeCommand(
                Action.PutOn,
                new AttirePiece(AttirePieceType.Socks, "socks"),
                "socks");
            commands.Add(putOnSocksCommand);

            var putOnShirtCommand = new AttireChangeCommand(
                Action.PutOn,
                new AttirePiece(AttirePieceType.Shirt, "shirt"),
                "shirt");
            commands.Add(putOnShirtCommand);

            var putOnJacketCommand = new AttireChangeCommand(
                Action.PutOn,
                new AttirePiece(AttirePieceType.Jacket, "jacket"),
                "jacket");
            commands.Add(putOnJacketCommand);

            var putOnPantsCommand = new AttireChangeCommand(
                Action.PutOn,
                new AttirePiece(AttirePieceType.Pants, "pants"),
                "pants");
            commands.Add(putOnPantsCommand);

            var leaveHouseCommand = new AttireIsReadyCommand("leaving house");
            commands.Add(leaveHouseCommand);

            var takeOffPajamasCommand = new AttireChangeCommand(
                Action.TakeOff,
                new AttirePiece(AttirePieceType.Shirt, "pajamas"),
                "Removing PJs");
            commands.Add(takeOffPajamasCommand);

            return commands;
        }
    }
}
