namespace GameFifteen.ManageInput
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class GameController
    {
        /// <summary>
        /// stores all possible commands
        /// </summary>
        public static Dictionary<string, ICommand> Commands = new Dictionary<string, ICommand>();

        /// <summary>
        /// Initializes a new instance of the <see cref="GameController"/> class.
        /// </summary>
        /// <param name="game"> the game instance </param>
        public GameController(Game game)
        {
            Commands.Add("top", new Top());
            Commands.Add("exit", new Exit(game));
            Commands.Add("save", new Save(game));
            Commands.Add("restore", new Restore(game));
            Commands.Add("restart", new Restart(game));
            Commands.Add("move", new Move(game));
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
                newCommand = Commands["move"];
                newCommand.Execute(cellNumber);                
            }
            else if (Commands.ContainsKey(consoleInputLine))
            {
                newCommand = Commands[consoleInputLine];
                newCommand.Execute();
            }
            else
            {
                ConsoleWriter.PrintIllegalCommandMessage();
            }
        }
    }
}
