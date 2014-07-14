using System;
using System.Linq;

namespace GameFifteen.ManageInput
{
    /// <summary>
    /// move class to enable game turn
    /// </summary>
    class Move : ICommand
    {
        /// <summary>
        /// instance of the game to execute move
        /// </summary>
        private Game game;

        /// <summary>
        /// creates an instance to execute moves
        /// </summary>
        /// <param name="game"> the game instance </param>
        public Move(Game game)
        {
            this.game = game;
        }

        public void Execute(params object[] list)
        {
            int cellNumber = (int)list[0];

            game.Board.NextMove(cellNumber);
            if (game.Board.IsMatrixOrdered())
            {
                game.IsFinished = true;
                ConsoleWriter.PrintFinalGameResult(game);                
            }
        }
    }
}
