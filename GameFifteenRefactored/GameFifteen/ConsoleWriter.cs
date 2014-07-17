namespace GameFifteen
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Prints all the messages a player can get during his play.
    /// </summary>
    public static class ConsoleWriter
    {
        internal static void PrintMessage(string message)
        {
            Console.Write(message);
        }

        internal static void PrintMatrix(Board board)
        {
            StringBuilder horizontalBorder = new StringBuilder("  ");
            for (int i = 0; i < Board.MATRIX_SIZE_COLUMNS; i++)
            {
                horizontalBorder.Append("---");
            }

            horizontalBorder.Append("- ");
            Console.WriteLine(horizontalBorder);
            for (int row = 0; row < Board.MATRIX_SIZE_ROWS; row++)
            {
                Console.Write(" |");
                for (int column = 0; column < Board.MATRIX_SIZE_COLUMNS; column++)
                {
                    Console.Write("{0,3}", board.Matrix[row, column]);
                }

                Console.WriteLine(" |");
            }

            Console.WriteLine(horizontalBorder);
        }

        internal static void PrintTopScores()
        {
            Console.Write(Messages.ScoreBoard());
            string[] topScores = TopScores.GetTopScoresFromFile();
            if (topScores[0] == null)
            {
                Console.WriteLine(Messages.NoTopScores());
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

        /// <summary>
        /// Prints on the console all the information the player needs after beating the game.
        /// Number of moves he made, the top score list and if the player was able to get on the top score list.
        /// </summary>
        /// <param name="game"> game instance </param>
        internal static void PrintFinalGameResult(Game game)
        {
            string moves = game.Turn == 1 ? "1 move" : string.Format("{0} moves", game.Turn);
            Console.WriteLine(Messages.CongratulationMessage(moves));
            string[] topScores = TopScores.GetTopScoresFromFile();
            if (topScores[TopScores.TOP_SCORES_AMOUNT - 1] != null)
            {
                string lowestScore = Regex.Replace(topScores[TopScores.TOP_SCORES_AMOUNT - 1], TopScores.TOP_SCORES_PERSON_PATTERN, @"$2");
                if (int.Parse(lowestScore) < game.Turn)
                {
                    Console.WriteLine(Messages.NoTopScoreAchieved(TopScores.TOP_SCORES_AMOUNT));
                    return;
                }
            }

            TopScores.UpgradeTopScore(game);
        }
    }
}