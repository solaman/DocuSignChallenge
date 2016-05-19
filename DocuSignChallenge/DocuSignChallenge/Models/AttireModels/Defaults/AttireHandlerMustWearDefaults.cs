using System;
using System.Collections.Generic;
using System.Linq;


namespace DocuSignChallenge.Models.AttireModels.Defaults
{
    /// <summary>
    /// Prepares Attire Handler with default "must wear" Attire Pieces,
    /// which are used to decide with the attire "is ready" to go outside.
    /// </summary>
   public static class AttireHandlerMustWearDefaults
    {
        /// <summary>
        /// Prepares Attire Handler with default "must wear" when it is "hot" outside.
        /// </summary>
        /// <param name="attireHandler">Attire Handler to prepare.</param>
        /// <returns>attire that is prepared.</returns>
       public static IAttireHandler AddHotAttireHandlerMustWear(IAttireHandler attireHandler)
        {
            attireHandler.AddMustWear(AttirePieceType.Footwear);
            attireHandler.AddMustWear(AttirePieceType.Headwear);
            attireHandler.AddMustWear(AttirePieceType.Pants);
            attireHandler.AddMustWear(AttirePieceType.Shirt);

            return attireHandler;
        }

        /// <summary>
        /// Prepares Attire Handler with default "must wears" for when it is "cold" outside.
        /// </summary>
        /// <param name="attireHandler">Attire Handler to prepare.</param>
        /// <returns>prepared Attire Handler.</returns>
      public  static IAttireHandler AddColdAttireHandlerMustWear(IAttireHandler attireHandler)
        {
            AddHotAttireHandlerMustWear(attireHandler);
            attireHandler.AddMustWear(AttirePieceType.Socks);
            attireHandler.AddMustWear(AttirePieceType.Jacket);

            return attireHandler;
        }
    }
}
