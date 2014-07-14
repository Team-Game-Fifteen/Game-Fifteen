using System;
using System.Linq;

namespace GameFifteen.ManageInput
{
    class Exit : ICommand
    {
        private Game game;

        public Exit(Game game)
        {
            this.game = game;
        }

        public void Execute(params object[] list)
        {
            this.game.IsFinished = true;
            ConsoleWriter.PrintGoodbye();
        }
    }
}
