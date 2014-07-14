using System;
using System.Linq;

namespace GameFifteen.ManageInput
{
    class Move : ICommand
    {
        private Game game;

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
