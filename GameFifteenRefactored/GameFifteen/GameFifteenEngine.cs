namespace GameFifteen
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;

    /// <summary>
    /// GameFifteenEngine is our "main" class. Here we make instances of the public classes and call the public 
    /// methods to generate the game's board, to read the user input and to check if the game is over.
    /// </summary>
    public class GameFifteenEngine
    {
        public static void Main()
        {
            PlayGame();
        }

        /// <summary>
        /// PlayGame() is the method which call's all the other essential methods of The Game Fifteen.
        /// </summary>
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

        /// <summary>
        /// This method prints on the console all the information the player needs after beating the game.
        /// Number of moves he made, the top score list and if the player was able to get on the top score list.
        /// </summary>
        /// <param name="board">It uses the information from the instance of the GameBoard class to tell how much turn
        /// it took the player to finish the game.</param>
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