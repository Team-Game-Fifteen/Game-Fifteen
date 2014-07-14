using System;
using System.Linq;

namespace GameFifteen.ManageInput
{
    class Restore : ICommand
    {
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
