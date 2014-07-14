namespace GameFifteen.ManageInput
{
    using System;
    using System.Linq;

    /// <summary>
    /// restart class for beginning a new game
    /// </summary>
    class Restart : ICommand
    {
        /// <summary>
        /// the instance of the game to be restarted
        /// </summary>
        private Game game;

        /// <summary>
        /// Initializes a new instance of the <see cref="Restart"/> class.
        /// </summary>
        /// <param name="game"> current game instance </param>
        public Restart(Game game)
        {
            this.game = game;
        }

        public void Execute(params object[] list)
        {
            this.game.Restart();
            ConsoleWriter.PrintWelcomeMessage();
            ConsoleWriter.PrintMatrix(this.game.Board);
        }
    }
}
