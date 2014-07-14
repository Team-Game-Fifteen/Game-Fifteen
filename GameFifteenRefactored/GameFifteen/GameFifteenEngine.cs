namespace GameFifteen
{
    using GameFifteen.ManageInput;
    using System;
    using System.Linq;

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
            Game game = Game.Instance;

            game.LoadTurns();
            ConsoleWriter.PrintWelcomeMessage();
            ConsoleWriter.PrintMatrix(game.Board);
            GameController controller = new GameController(game);

            while (!game.IsFinished)
            {
                ConsoleWriter.PrintNextMoveMessage();
                string consoleInputLine = Console.ReadLine();
                controller.Invoke(consoleInputLine);
            }
        }
    }
}