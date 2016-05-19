namespace DocuSignChallenge.Models.AttireModels
{
    /// <summary>
    /// Rules which are to be attached to the
    /// Attire State Handler. These rules are then checked
    /// when the State Handler wishes to change states.
    /// </summary>
    public interface IAttireRule
    {
        /// <summary>
        /// Get Action which should trigger this rule.
        /// </summary>
        /// <returns>Action that should trigger this rule.</returns>
        Action GetTriggerAction();

        /// <summary>
        /// Get AttirePiece which should trigger this rule.
        /// </summary>
        /// <returns>AttirePiece that should trigger this rule.</returns>
        AttirePiece GetTriggerAttirePiece();

        /// <summary>
        /// Decides if the rule is satisfied based on the state of the Attire.
        /// </summary>
        /// <param name="attire">Attire to check.</param>
        /// <returns>True if attire satisfies the rule, false otherwise.</returns>
        bool IsSatisfied(IAttire attire);
    }

    public abstract class AttireRule : IAttireRule
    {
        private Action triggerAction;
        private AttirePiece triggerAttirePiece;

        public AttireRule(Action triggerAction, AttirePiece triggerAttirePiece)
        {
            this.triggerAction = triggerAction;
            this.triggerAttirePiece = triggerAttirePiece;
        }



        public Action GetTriggerAction()
        {
            return this.triggerAction;
        }

        public AttirePiece GetTriggerAttirePiece()
        {
            return this.triggerAttirePiece;
        }

        public abstract bool IsSatisfied(IAttire attire);
    }

    /// <summary>
    /// Rule to be used when a piece of attire should not be worn.
    /// </summary>
    public class CannotWearRule : AttireRule
    {
        

        public CannotWearRule(Action triggerAction, AttirePiece triggerAttirePiece) : base(triggerAction, triggerAttirePiece)
        {
        }

        public override bool IsSatisfied(IAttire attire)
        {
            return false;
        }
    }

    /// <summary>
    /// Rule To be used to verify
    /// that a particular Attire Piece Type is either on or off.
    /// when trying to change states.
    /// </summary>
    public class ShouldBeWearingRule : AttireRule
    {
        private AttirePieceType attirePieceType;
        private bool shouldBeWearing;

        public ShouldBeWearingRule(Action triggerAction, AttirePiece triggerAttirePiece,
            AttirePieceType attirePieceType, bool shouldBeWearing): base(triggerAction, triggerAttirePiece)
        {
            this.attirePieceType = attirePieceType;
            this.shouldBeWearing = shouldBeWearing;
        }

        public override bool IsSatisfied(IAttire attire)
        {
            return shouldBeWearing ? attire.IsWearing(attirePieceType) : !attire.IsWearing(attirePieceType);
        }
    }
}
