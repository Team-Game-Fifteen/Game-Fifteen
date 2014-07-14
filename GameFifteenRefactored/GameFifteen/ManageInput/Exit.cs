namespace GameFifteen.ManageInput
{
    using System;
    using System.Linq;

    class Exit : ICommand
    {
        private Game game;

        public Exit(Game game)
        {
            this.game = game;
        }

        /// <summary>
        /// Executes exiting the game
        /// </summary>
        /// <param name="list"></param>
        public void Execute(params object[] list)
        {
            this.game.IsFinished = true;
            ConsoleWriter.PrintGoodbye();
        }
    }
}
