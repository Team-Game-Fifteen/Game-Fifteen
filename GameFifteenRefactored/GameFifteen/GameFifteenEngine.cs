namespace GameFifteen
{
    using System;
    using System.Linq;
    using GameFifteen.ManageInput;

    /// <summary>
    /// Game's engine.
    /// </summary>
    public class GameFifteenEngine
    {
        /// <summary>
        /// Starts the game.
        /// </summary>
        public static void Main()
        {
            PlayGame();
        }

        /// <summary>
        /// Calls all the other essential methods of The Game Fifteen.
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
                ConsoleWriter.PrintMessage("Enter a number to move: ");
                string consoleInputLine = Console.ReadLine();
                controller.Invoke(consoleInputLine);
            }
        }
    }
}