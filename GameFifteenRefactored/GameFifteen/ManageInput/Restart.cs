namespace GameFifteen.ManageInput
{
    using System;
    using System.Linq;

    /// <summary>
    /// Begins a new game.
    /// </summary>
    public class Restart : ICommand
    {
        /// <summary>
        /// The instance of the game to be restarted.
        /// </summary>
        private Game game;

        /// <summary>
        /// Initializes a new instance of the <see cref="Restart"/> class.
        /// </summary>
        /// <param name="game">Current game instance.</param>
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
