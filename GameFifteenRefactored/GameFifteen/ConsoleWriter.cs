namespace GameFifteen
{
    using System;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// This class is resposible for printing all the messages a player can get during his play.
    /// </summary>
    public static class ConsoleWriter
    {
        public static void PrintCellDoesNotExistMessage()
        {
            Console.WriteLine("That cell does not exist in the matrix.");
        }

        public static void PrintGoodbye()
        {
            Console.WriteLine("Good bye!");
        }

        public static void PrintIllegalCommandMessage()
        {
            Console.WriteLine("Illegal command!");
        }

        public static void PrintIllegalMoveMessage()
        {
            Console.WriteLine("Illegal move!");
        }

        public static void PrintNextMoveMessage()
        {
            Console.Write("Enter a number to move: ");
        }

        public static void PrintMatrix(Board board)
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

        public static void PrintTopScores()
        {
            Console.WriteLine("Scoreboard:");
            string[] topScores = Score.GetTopScoresFromFile();
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

        public static void PrintWelcomeMessage()
        {
            Console.Write("Welcome to the game \"15\". ");
            Console.WriteLine("Please try to arrange the numbers sequentially. ");
            Console.WriteLine("Use 'top' to view the top scoreboard, " +
                              "'restart' to start a new game and 'exit'  to quit the game.");
        }
    }
}
