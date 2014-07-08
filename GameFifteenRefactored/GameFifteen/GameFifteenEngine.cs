namespace GameFifteen
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;

    public class GameFifteenEngine
    {
        public static void Main()
        {
            PlayGame();
        }

        public static void PlayGame()
        {
            GameBoard board = new GameBoard();

            while (true)
            {
                board.ShuffleMatrix();
                ConsoleWriter.PrintWelcomeMessage();
                ConsoleWriter.PrintMatrix(board);
                while (true)
                {
                    ConsoleWriter.PrintNextMoveMessage();
                    string consoleInputLine = Console.ReadLine();
                    int cellNumber;
                    if (int.TryParse(consoleInputLine, out cellNumber))
                    {
                        //Input is a cell number.
                        board.NextMove(cellNumber);
                        if (board.IsMatrixOrdered())
                        {
                            TheEnd(board);
                            break;
                        }
                    }
                    else
                    {
                        //Input is a command.
                        if (consoleInputLine == "restart")
                        {
                            break;
                        }

                        switch (consoleInputLine)
                        {
                            case "top":
                                ConsoleWriter.PrintTopScores();
                                break;
                            case "exit":
                                ConsoleWriter.PrintGoodbye();
                                return;
                            default:
                                ConsoleWriter.PrintIllegalCommandMessage();
                                break;
                        }
                    }
                }
            }
        }

        private static void TheEnd(GameBoard board)
        {
            string moves = board.Turn == 1 ? "1 move" : string.Format("{0} moves", board.Turn);
            Console.WriteLine("Congratulations! You won the game in {0}.", moves);
            string[] topScores = Score.GetTopScoresFromFile();
            if (topScores[Score.TopScoresAmount - 1] != null)
            {
                string lowestScore = Regex.Replace(topScores[Score.TopScoresAmount - 1], Score.TopScoresPersonPattern, @"$2");
                if (int.Parse(lowestScore) < board.Turn)
                {
                    Console.WriteLine("You couldn't get in the top {0} scoreboard.", Score.TopScoresAmount);
                    return;
                }
            }

            Score.UpgradeTopScore(board);
        }
    }
}