namespace GameFifteen.ManageInput
{
    using System;
    using System.Linq;

    /// <summary>
    /// Restore class for loading a game.
    /// </summary>
    public class Restore : ICommand
    {
        /// <summary>
        /// Instance of a game to restore
        /// </summary>
        private Game game;

        /// <summary>
        /// Initializes a new instance of the <see cref="Restore"/> class.
        /// </summary>
        /// <param name="game"> the game to be restored </param>
        public Restore(Game game)
        {
            this.game = game;
        }

        public void Execute(params object[] list)
        {
            this.game.RestoreState();
            ConsoleWriter.PrintMatrix(this.game.Board);
        }
    }
}
