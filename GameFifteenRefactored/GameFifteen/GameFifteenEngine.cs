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
            Game game = new Game();
            game.LoadTurns();

            while (true)
            {
                game.Board.ShuffleMatrix();
                
                ConsoleWriter.PrintWelcomeMessage();
                ConsoleWriter.PrintMatrix(game.Board);
                while (true)
                {
                    ConsoleWriter.PrintNextMoveMessage();
                    string consoleInputLine = Console.ReadLine();
                    int cellNumber;
                    if (int.TryParse(consoleInputLine, out cellNumber))
                    {
                        game.Board.NextMove(cellNumber);
                        if (game.Board.IsMatrixOrdered())
                        {
                            ConsoleWriter.PrintFinalGameResult(game);
                            break;
                        }
                    }
                    else
                    {
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
                            case "save":
                                game.SaveState();
                                ConsoleWriter.PrintStateSaved();
                                break;
                            case "restore":
                                game.RestoreState();
                                ConsoleWriter.PrintMatrix(game.Board);
                                break;
                            default:
                                ConsoleWriter.PrintIllegalCommandMessage();
                                break;
                        }
                    }
                }
            }
        }
    }
}