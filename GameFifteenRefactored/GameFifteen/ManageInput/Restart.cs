using System;
using System.Linq;

namespace GameFifteen.ManageInput
{
    class Restart : ICommand
    {
        /// <summary>
        /// the instance of the game to be restarted
        /// </summary>
        private Game game;

        public Restart(Game game)
        {
            this.game = game;
        }

        public void Execute(params object[] list)
        {
            game.Restart();
            ConsoleWriter.PrintWelcomeMessage();
            ConsoleWriter.PrintMatrix(game.Board);
        }
    }
}
