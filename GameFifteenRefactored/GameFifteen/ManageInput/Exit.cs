namespace GameFifteen.ManageInput
{
    using System;
    using System.Linq;

    public class Exit : ICommand
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
