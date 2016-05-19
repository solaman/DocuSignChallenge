using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocuSignChallenge.Models.AttireModels
{
    public interface IAttireCommand
    {
        bool Execute(IAttireHandler attireHandler);
        string GetDescription();
    }

    public class AttireChangeCommand : IAttireCommand
    {
        public Action action;
        public AttirePiece attirePiece;
        public string description;

        public AttireChangeCommand(Action action, AttirePiece attirePiece, string description)
        {
            this.action = action;
            this.attirePiece = attirePiece;
            this.description = description;
        }

        public bool Execute(IAttireHandler attireHandler)
        {
            return attireHandler.ChangeState(action, attirePiece);
        }

        public string GetDescription()
        {
            return this.description;
        }
    }

    public class AttireIsReadyCommand : IAttireCommand
    {
        public string description;

        public AttireIsReadyCommand(string description)
        {
            this.description = description;
        }

        public bool Execute(IAttireHandler attireHandler)
        {
            return attireHandler.IsReady();
        }

        public string GetDescription()
        {
            return this.description;
        }
    }
}
