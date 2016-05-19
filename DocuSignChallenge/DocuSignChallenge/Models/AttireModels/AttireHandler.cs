using System.Collections.Generic;

namespace DocuSignChallenge.Models.AttireModels
{
    /// <summary>
    /// Used to manage Attire State changes.
    /// </summary>
    public interface IAttireHandler
    {
        /// <summary>
        /// Add a rule dictating how the Attire State can change.
        /// </summary>
        /// <param name="rule">Rule to be added.</param>
        void AddRule(IAttireRule rule);

        /// <summary>
        /// Attempt to Change the state using the given action on the given attirePiece.
        /// </summary>
        /// <param name="action">Action to perform.</param>
        /// <param name="attirePiece">AttirePiece to perform action on.</param>
        /// <returns>Whether or not Attire State was successfully changed.</returns>
        bool ChangeState(Action action, AttirePiece attirePiece);

        /// <summary>
        /// Add Attire Piece types that need to be warn for
        /// the Attire to be considered "ready"
        /// </summary>
        /// <param name="attirePieceType">Attire piece that must be worn.</param>
        void AddMustWear(AttirePieceType attirePieceType);

        /// <summary>
        /// Returns true if the attire is "ready" as per attirePiece types specified through "AddMustWear"
        /// </summary>
        /// <returns>Returns true if the attire is "ready". False otherwise</returns>
        bool IsReady();

        /// <summary>
        /// Resets Attire State to default. This includes clearing all rules and mustWear.
        /// </summary>
        void ResetState();
    }

    public class AttireHandler : IAttireHandler
    {
        
        private Attire attire;
        private IDictionary<string, IList<IAttireRule>> stateChangeRules;
        private IDictionary<AttirePieceType, bool> mustWear;

        private AttirePiece pajamas = new AttirePiece(AttirePieceType.Shirt, "pajamas");

        public AttireHandler()
        {
            attire = new Attire();
            attire.PutOn(this.pajamas);

            stateChangeRules = new Dictionary<string, IList<IAttireRule>>();
            mustWear = new Dictionary<AttirePieceType, bool>();
        }

        public void AddMustWear(AttirePieceType attirePieceType)
        {
            mustWear.Add(attirePieceType, true);
        }

        public bool IsReady()
        {
            foreach(var mustWearPair in mustWear)
            {
                if(attire.IsWearing(mustWearPair.Key) != mustWearPair.Value)
                {
                    return false;
                }
            }

            return true;
        }

        public void AddRule(IAttireRule rule)
        {
            var key = GetStateRuleKeyString(rule);
            if (!stateChangeRules.ContainsKey(key))
            {
                stateChangeRules[key] = new List<IAttireRule>();
            }

            stateChangeRules[key].Add(rule);
        }

        /// <summary>
        /// By Default, pajamas must be taken off first. Otherwise, attempt to perform action
        /// with given attirepiece.
        /// </summary>
        /// <param name="action">Action to perform.</param>
        /// <param name="attirePiece">Attire Piece to perform action on.</param>
        /// <returns>True if Action was successfully performed. False Otherwise.</returns>
        public bool ChangeState(Action action, AttirePiece attirePiece)
        {
            //Pajamas must be removed first.
            if(attire.IsWearing(pajamas) && action != Action.TakeOff &&
                !attirePiece.Equals(pajamas))
            {
                return false;
            }

            //Check if rules are satisfied.
            var key = GetStateRuleKeyString(action, attirePiece);
            if (stateChangeRules.ContainsKey(key))
            {
                foreach(IAttireRule rule in stateChangeRules[key])
                {
                    if (!rule.IsSatisfied(attire))
                    {
                        return false;
                    }
                }
            }

            //Attempt to take off/put on attire piece.
            if (action == Action.PutOn)
            {
                return attire.PutOn(attirePiece);
            }
            else if (action == Action.TakeOff)
            {
                return attire.TakeOff(attirePiece);
            }
            else
            {
                return false;
            }
        }

        public void ResetState()
        {
            attire.GetNaked();
            attire.PutOn(this.pajamas);

            stateChangeRules = new Dictionary<string, IList<IAttireRule>>();
            mustWear = new Dictionary<AttirePieceType, bool>();
        }

        private string GetStateRuleKeyString(IAttireRule rule)
        {
            return GetStateRuleKeyString(rule.GetTriggerAction(), rule.GetTriggerAttirePiece());
        }

        private string GetStateRuleKeyString(Action action, AttirePiece attirePiece)
        {
            return action + attirePiece.type.ToString();
        }
    }
}