using System.Collections.Generic;

namespace DocuSignChallenge.Models.AttireModels
{
    public interface IAttire
    {
        /// <summary>
        /// Attempts to put on the given attire piece
        /// </summary>
        /// <param name="attirePiece">attire piece to put on</param>
        /// <returns>False if the attire piece has a type not matching any of the attire, or
        /// their is already an article of clothing at that given type. True otherwise.</returns>
        bool PutOn(AttirePiece attirePiece);

        /// <summary>
        /// Attempts to remove a given attire piece.
        /// </summary>
        /// <param name="attirePiece">attire piece to remove.</param>
        /// <returns>True if the attire piece is successfully removed. False otherwise</returns>
        bool TakeOff(AttirePiece attirePiece);

        /// <summary>
        /// Checks if the given attire piece is being worn.
        /// </summary>
        /// <param name="attirePiece">Attire piece to check.</param>
        /// <returns>True if the attire piece is being worn. False otherwise</returns>
        bool IsWearing(AttirePiece attirePiece);

        /// <summary>
        /// Checks if an attire piece of the given type is being worn.
        /// </summary>
        /// <param name="attirePieceType">Attire piece to check.</param>
        /// <returns>True if an attire piece of the given type is being worn. False otherwise.</returns>
        bool IsWearing(AttirePieceType attirePieceType);

        /// <summary>
        /// Removes all articles of clothing from the attire.
        /// </summary>
        void GetNaked();
    }

    /// <summary>
    /// We assume that the composition of an attire object will be changed infrequently.
    /// As such, we find it fitting to have a single object with each of these
    /// Attributes explicitely mentioned.
    /// </summary>
    public class Attire : IAttire
    {
        private Dictionary<AttirePieceType, AttirePiece> attire;

        public Attire()
        {
            attire = new Dictionary<AttirePieceType, AttirePiece>();
            attire[AttirePieceType.Footwear] = null;
            attire[AttirePieceType.Headwear] = null;
            attire[AttirePieceType.Jacket] = null;
            attire[AttirePieceType.Pants] = null;
            attire[AttirePieceType.Shirt] = null;
            attire[AttirePieceType.Socks] = null;
        }

        public bool PutOn(AttirePiece attirePiece)
        {
            if(!attire.ContainsKey(attirePiece.type)
                || attire[attirePiece.type] != null)
            {
                return false;
            } else
            {
                attire[attirePiece.type] = attirePiece;
                return true;
            }
        }

        public bool TakeOff(AttirePiece attirePiece)
        {
            if(!attire.ContainsKey(attirePiece.type) ||
                !attirePiece.Equals(attire[attirePiece.type]) ){
                return false;
            } else
            {
                attire[attirePiece.type] = null;
                return true;
            }
        }

        public bool IsWearing(AttirePiece attirePiece)
        {
            return attire.ContainsKey(attirePiece.type) &&
                attire[attirePiece.type] != null && attire[attirePiece.type].Equals(attirePiece);
        }

        public bool IsWearing(AttirePieceType attirePieceType)
        {
            return attire.ContainsKey(attirePieceType) &&
                attire[attirePieceType] != null;
        }

        public void GetNaked()
        {
            attire[AttirePieceType.Footwear] = null;
            attire[AttirePieceType.Headwear] = null;
            attire[AttirePieceType.Jacket] = null;
            attire[AttirePieceType.Pants] = null;
            attire[AttirePieceType.Shirt] = null;
            attire[AttirePieceType.Socks] = null;
        }
    }

    /// <summary>
    ///  We expect Multiple AttirePieces to exist in the future, as such, we
    /// have a generic AttirePiece class where the name of the piece can be specified.
    /// </summary>
    public class AttirePiece
    {
        public AttirePieceType type;

        public string name;

        public AttirePiece(AttirePieceType type, string name)
        {
            this.type = type;
            this.name = name;
        }

        public bool Equals(AttirePiece compareTo)
        {
            return compareTo != null &&
                this.type == compareTo.type &&
                this.name == compareTo.name;
        }
    }
}