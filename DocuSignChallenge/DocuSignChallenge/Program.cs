using DocuSignChallenge.Models.AttireModels;
using DocuSignChallenge.Models.AttireModels.Defaults;
using System.Collections.Generic;
using System;

namespace DocuSignChallenge
{
    class Program
    {
        static string FAIL = "fail";

        static void Main(string[] args)
        {
            IAttireHandler attireHandler = new AttireHandler();
            IList<IAttireCommand> attireCommands = null;
            string[] userInput;
            while (true)
            {
                attireHandler.ResetState();

                Console.Write("type 'exit' to exit.");
                Console.WriteLine(" Otherwise, type /(HOT|COLD) ([1-8], )*7/ to leave your house!");
                userInput = Console.ReadLine().Split(new char[]{ ' ', ','}, StringSplitOptions.RemoveEmptyEntries);
                
                if(userInput[0] == "exit")
                {
                    Console.WriteLine("Bye!");
                    return;
                } 
                else if(userInput[0] == "COLD")
                {
                    attireCommands = AttireCommandDefaults.GetColdAttireHandlerCommands();
                    AttireHandlerMustWearDefaults.AddColdAttireHandlerMustWear(attireHandler);
                    AttireRuleDefaults.AddColdAttireHandlerRules(attireHandler);
                }
                else if(userInput[0] == "HOT")
                {
                    attireCommands = AttireCommandDefaults.GetHotAttireHandlerCommands();
                    AttireHandlerMustWearDefaults.AddHotAttireHandlerMustWear(attireHandler);
                    AttireRuleDefaults.AddHotAttireHandlerRules(attireHandler);
                } else
                {
                    Console.WriteLine(FAIL);
                    continue;
                }

                short commandNumber = -1;
                IList<string> commandOutputs = new List<string>();
                for(int commandIndex = 1; commandIndex < userInput.Length; commandIndex++)
                {
                    if (!Int16.TryParse(userInput[commandIndex], out commandNumber) ||
                        commandNumber > attireCommands.Count ||
                        !attireCommands[commandNumber - 1].Execute(attireHandler))
                    {
                        commandOutputs.Add(FAIL);
                        break;
                    } else
                    {
                        commandOutputs.Add(attireCommands[commandNumber - 1].GetDescription());
                    }
                }

                if (commandOutputs[commandOutputs.Count -1] != FAIL &&
                    commandNumber != 7)
                {
                    commandOutputs.Add(FAIL);
                }

                Console.WriteLine(String.Join(", ", commandOutputs) );
            }
        }
    }
}
