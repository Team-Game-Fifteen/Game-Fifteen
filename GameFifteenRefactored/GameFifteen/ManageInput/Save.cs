using System;
using System.Linq;

namespace GameFifteen.ManageInput
{
    public class Save : ICommand
    {
        /// <summary>
        /// instance of the game to be saved
        /// </summary>
        private Game game;

        /// <summary>
        /// creates an instance to save the game
        /// </summary>
        /// <param name="game"> the game to be saved </param>
        public Save(Game game)
        {
            this.game = game;
        }

        public void Execute(params object[] list)
        {
            this.game.SaveState();
            ConsoleWriter.PrintStateSaved();
        }
    }
}
