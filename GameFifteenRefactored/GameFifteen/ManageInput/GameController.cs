namespace GameFifteen.ManageInput
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Interfaces;

    /// <summary>
    /// Class used for command handling.
    /// </summary>
    public class GameController
    {
        /// <summary>
        /// Stores all possible commands.
        /// </summary>
        private static Dictionary<string, ICommand> commands = new Dictionary<string, ICommand>();

        /// <summary>
        /// Initializes a new instance of the <see cref="GameController"/> class.
        /// </summary>
        /// <param name="game">The game instance.</param>
        public GameController(Game game)
        {
            commands.Add("top", new Top());
            commands.Add("exit", new Exit(game));
            commands.Add("save", new Save(game));
            commands.Add("restore", new Restore(game));
            commands.Add("restart", new Restart(game));
            commands.Add("move", new Move(game));
        }

        /// <summary>
        /// Invokes a command from the list from player input.
        /// </summary>
        /// <param name="consoleInputLine">Player input command.</param>
        public void Invoke(string consoleInputLine)
        {
            int cellNumber;
            ICommand newCommand;

            if (int.TryParse(consoleInputLine, out cellNumber))
            {
                newCommand = commands["move"];
                newCommand.Execute(cellNumber);                
            }
            else if (consoleInputLine != "move" && commands.ContainsKey(consoleInputLine))
            {
                newCommand = commands[consoleInputLine];
                newCommand.Execute();
            }
            else
            {
                ConsoleWriter.PrintMessage(Messages.IllegalCommand());
            }
        }
    }
}
