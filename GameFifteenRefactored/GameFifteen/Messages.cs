namespace GameFifteen
{
    using System;

    /// <summary>
    /// Static Class to hold all string constants
    /// </summary>
    public static class Messages
    {
        public const string NextMove = " Enter a number to move: ";
        public const string TopScoreName = " Please enter your name for the top scoreboard: ";
        
        public static string Welcome()
        {
            return string.Format(
                " Welcome to the game \"15\". {0}" +
                " Please try to arrange the numbers sequentially. {0} Use: {0} 'top' to view the top scoreboard, {0}" +
                " 'save' to save the current state, {0} 'restore' to restore a saved state (you can save many states), {0}" +
                " 'restart' to start a new game,{0} 'exit' to quit the game.{0}", Environment.NewLine);
        }

        public static string IllegalMove()
        { 
            return string.Format(" Illegal move!{0}", Environment.NewLine); 
        }

        public static string IllegalValue() 
        { 
            return string.Format(" That cell does not exist in the matrix. Value must be in range [1; 15]!{0}", Environment.NewLine); 
        }

        public static string IllegalCommand() 
        {
            return string.Format(" Illegal command!{0}", Environment.NewLine);
        }

        public static string SaveState() 
        { 
            return string.Format(" The current state is saved {0}", Environment.NewLine); 
        }

        public static string NoStateToRestore() 
        { 
            return string.Format(" There is no state to be restored! {0}", Environment.NewLine); 
        }

        public static string ScoreBoard() 
        { 
            return string.Format(" Scoreboard: {0}", Environment.NewLine); 
        }

        public static string NoTopScores()
        {
            return string.Format("There are no scores to display yet. {0}", Environment.NewLine);
        }

        public static string CongratulationMessage(string movesCount)
        {
            return string.Format(" Congratulations! You won the game in {0}.", movesCount);
        }

        public static string NoTopScoreAchieved(int score)
        {
            return string.Format(" You couldn't get in the top {0} scoreboard.", score);
        }

        public static string TheEnd()
        {
            return string.Format(" Goodbye!{0}", Environment.NewLine);
        }
    }
}
