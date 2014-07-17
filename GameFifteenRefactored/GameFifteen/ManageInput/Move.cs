namespace GameFifteen.ManageInput
{
    using System;
    using System.Linq;

    /// <summary>
    /// Enables game turn.
    /// </summary>
    public class Move : ICommand
    {
        /// <summary>
        /// Instance of the game to execute move.
        /// </summary>
        private readonly Game game;

        /// <summary>
        /// Initializes a new instance of the <see cref="Move"/> class.
        /// </summary>
        /// <param name="game">The game instance.</param>
        public Move(Game game)
        {
            this.game = game;
        }

        public void Execute(params object[] list)
        {
            int cellNumber = (int)list[0];

            this.game.Board.NextMove(cellNumber);
            if (this.game.Board.IsMatrixOrdered())
            {
                this.game.IsFinished = true;
                ConsoleWriter.PrintFinalGameResult(this.game);                
            }
        }
    }
}
