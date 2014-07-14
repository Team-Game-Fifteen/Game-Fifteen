using System;
using System.Linq;

namespace GameFifteen.ManageInput
{
    class Restart : ICommand
    {
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
