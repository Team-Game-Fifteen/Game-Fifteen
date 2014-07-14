using System;
using System.Linq;

namespace GameFifteen.ManageInput
{
    class Restore : ICommand
    {
        /// <summary>
        /// instance of a game to restore
        /// </summary>
        private Game game;

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
