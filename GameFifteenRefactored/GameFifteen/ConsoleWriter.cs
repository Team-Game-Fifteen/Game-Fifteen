namespace GameFifteen
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    /// <summary>
    /// This class is resposible for printing all the messages a player can get during his play.
    /// </summary>
    public static class ConsoleWriter
    {
        internal static void PrintCellDoesNotExistMessage()
        {
            Console.WriteLine("That cell does not exist in the matrix.");
        }

        internal static void PrintGoodbye()
        {
            Console.WriteLine("Good bye!");
        }

        internal static void PrintIllegalCommandMessage()
        {
            Console.WriteLine("Illegal command!");
        }

        internal static void PrintIllegalMoveMessage()
        {
            Console.WriteLine("Illegal move!");
        }

        internal static void PrintStateSaved()
        {
            Console.WriteLine("The current state is saved");
        }

        internal static void PrintNoSavedStateMessage()
        {
            Console.WriteLine("There is no state to be restored!");
        }

        internal static void PrintNextMoveMessage()
        {
            Console.Write("Enter a number to move: ");
        }

        internal static void PrintMatrix(Board board)
        {
            StringBuilder horizontalBorder = new StringBuilder("  ");
            for (int i = 0; i < Board.MatrixSizeColumns; i++)
            {
                horizontalBorder.Append("---");
            }

            horizontalBorder.Append("- ");
            Console.WriteLine(horizontalBorder);
            for (int row = 0; row < Board.MatrixSizeRows; row++)
            {
                Console.Write(" |");
                for (int column = 0; column < Board.MatrixSizeColumns; column++)
                {
                    Console.Write("{0,3}", board.Matrix[row, column]);
                }

                Console.WriteLine(" |");
            }

            Console.WriteLine(horizontalBorder);
        }

        internal static void PrintTopScores()
        {
            Console.WriteLine("Scoreboard:");
            string[] topScores = TopScores.GetTopScoresFromFile();
            if (topScores[0] == null)
            {
                Console.WriteLine("There are no scores to display yet.");
            }
            else
            {
                foreach (string score in topScores)
                {
                    if (score != null)
                    {
                        Console.WriteLine(score);
                    }
                }
            }
        }

        internal static void PrintWelcomeMessage()
        {
            Console.Write("Welcome to the game \"15\". ");
            Console.WriteLine("Please try to arrange the numbers sequentially. ");
            Console.WriteLine("Use 'top' to view the top scoreboard, " +
                              "'restart' to start a new game and 'exit'  to quit the game.");
        }

        /// <summary>
        /// This method prints on the console all the information the player needs after beating the game.
        /// Number of moves he made, the top score list and if the player was able to get on the top score list.
        /// </summary>
        internal static void PrintFinalGameResult(Game game)
        {
            string moves = game.Turn == 1 ? "1 move" : string.Format("{0} moves", game.Turn);
            Console.WriteLine("Congratulations! You won the game in {0}.", moves);
            string[] topScores = TopScores.GetTopScoresFromFile();
            if (topScores[TopScores.TopScoresAmount - 1] != null)
            {
                string lowestScore = Regex.Replace(topScores[TopScores.TopScoresAmount - 1], TopScores.TopScoresPersonPattern, @"$2");
                if (int.Parse(lowestScore) < game.Turn)
                {
                    Console.WriteLine("You couldn't get in the top {0} scoreboard.", TopScores.TopScoresAmount);
                    return;
                }
            }

            TopScores.UpgradeTopScore(game);
        }
    }
}
