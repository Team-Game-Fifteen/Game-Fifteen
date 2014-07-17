namespace GameFifteen
{
    using System;

    public static class Messages
    {
        public const string Welcome = "Welcome to the game \"15\". " +
            "\r\n Please try to arrange the numbers sequentially. \r\n Use: \r\n 'top' to view the top scoreboard," +
            "\r\n 'save' to save the current state,\r\n 'restore' to restore a saved state (you can save many states), " +
            "\r\n 'restart' to start a new game,\r\n 'exit' to quit the game.\r\n";

        public const string IllegalMove = "Illegal move!\r\n";
        public const string IllegalValue = "That cell does not exist in the matrix. Value must be in range [1; 15] ! \r\n ";
        public const string IllegalCommand = "Illegal command!\r\n";

        public const string SaveState = "The current state is saved";
        public const string NoStateToRestore = "There is no state to be restored!";

        public const string NextMove = "Enter a number to move: ";
        public const string TopScoreName = "Please enter your name for the top scoreboard: ";

        public const string ScoreBoard = "Scoreboard:";
        public const string NoTopScores = "There are no scores to display yet.";

        public const string TheEnd = "Goodbye!";


        public static string CongratulationMessage(string movesCount)
        {
            return String.Format(" Congratulations! You won the game in {0}.", movesCount);
        }

        public static string NoTopScoreAchieved(int score)
        {
            return String.Format(" You couldn't get in the top {0} scoreboard.", score);
        }
    }
}
