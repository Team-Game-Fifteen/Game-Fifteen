namespace GameFifteen.ManageInput
{
    using System;
    using System.Linq;

    /// <summary>
    /// restart class for begining a new game
    /// </summary>
    class Restart : ICommand
    {
        /// <summary>
        /// the instance of the game to be restarted
        /// </summary>
        private Game game;

        /// <summary>
        /// creates an instance to restart the game
        /// </summary>
        /// <param name="game"> current game instance </param>
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
