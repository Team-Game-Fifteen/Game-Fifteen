using System;
using System.Linq;

namespace GameFifteen.ManageInput
{
    /// <summary>
    /// restore class for loading a game
    /// </summary>
    class Restore : ICommand
    {
        /// <summary>
        /// instance of a game to restore
        /// </summary>
        private Game game;

        /// <summary>
        /// creates an instance to restore the game
        /// </summary>
        /// <param name="game"> the game to be restored </param>
        public Restore(Game game)
        {
            this.game = game;
        }

        public void Execute(params object[] list)
        {
            game.RestoreState();
            ConsoleWriter.PrintMatrix(game.Board);
        }
    }
}
