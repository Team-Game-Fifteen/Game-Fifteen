namespace GameFifteen.ManageInput
{
    using System;
    using System.Linq;

    /// <summary>
    /// Save class for saving the game state.
    /// </summary>
    public class Save : ICommand
    {
        /// <summary>
        /// Instance of the game to be saved.
        /// </summary>
        private Game game;

        /// <summary>
        /// Initializes a new instance of the <see cref="Save"/> class.
        /// </summary>
        /// <param name="game">The game to be saved.</param>
        public Save(Game game)
        {
            this.game = game;
        }

        public void Execute(params object[] list)
        {
            this.game.SaveState();
            ConsoleWriter.PrintMessage("The current state is saved");
        }
    }
}
