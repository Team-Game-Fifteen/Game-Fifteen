using System;
using System.Linq;

namespace GameFifteen.ManageInput
{
    public class Save : ICommand
    {
        private Game game;

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
