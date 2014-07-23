namespace GameFifteen.ManageInput
{
    using System;
    using System.Linq;
    using Interfaces;

    /// <summary>
    /// Class used to exit the game.
    /// </summary>
    public class Exit : ICommand
    {
        private readonly Game game;

        public Exit(Game game)
        {
            this.game = game;
        }

        public void Execute(params object[] list)
        {
            this.game.IsFinished = true;
            ConsoleWriter.PrintMessage(Messages.TheEnd());
        }
    }
}
