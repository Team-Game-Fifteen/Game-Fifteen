using System;
using System.Collections.Generic;
using System.Linq;

namespace GameFifteen.ManageInput
{
    public class GameController
    {
        /// <summary>
        /// stores all possible commands
        /// </summary>
        public Dictionary<string, ICommand> commands = new Dictionary<string, ICommand>();

        /// <summary>
        /// creates a class to store all possible user commands
        /// </summary>
        /// <param name="game"></param>
        public GameController(Game game)
        {
            this.commands.Add("top", new Top());
            this.commands.Add("exit", new Exit(game));
            this.commands.Add("save", new Save(game));
            this.commands.Add("restore", new Restore(game));
            this.commands.Add("restart", new Restart(game));
            this.commands.Add("move", new Move(game));
        }

        /// <summary>
        /// invokes a command from the list from player input
        /// </summary>
        /// <param name="consoleInputLine"> player input command </param>
        public void Invoke(string consoleInputLine)
        {
            int cellNumber;
            ICommand newCommand;

            if (int.TryParse(consoleInputLine, out cellNumber))
            {
                newCommand = commands["move"];
                newCommand.Execute(cellNumber);                
            }
            else if (this.commands.ContainsKey(consoleInputLine))
            {
                newCommand = commands[consoleInputLine];
                newCommand.Execute();
            }
            else
            {
                ConsoleWriter.PrintIllegalCommandMessage();
            }
        }
    }
}
