namespace GameFifteen
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class Game
    {
        public Game()
        {
            this.Turn = 0;
            this.Board = new Board();
        }

        public int Turn { get; private set; }
        public Board Board { get; private set; }


        /// <summary>
        /// This method prints on the console all the information the player needs after beating the game.
        /// Number of moves he made, the top score list and if the player was able to get on the top score list.
        /// </summary>
        /// <param name="board">It uses the information from the instance of the GameBoard class to tell how much turn
        /// it took the player to finish the game.</param>
        public void TheEnd()
        {
            string moves = this.Turn == 1 ? "1 move" : string.Format("{0} moves", this.Turn);
            Console.WriteLine("Congratulations! You won the game in {0}.", moves);
            string[] topScores = TopScores.GetTopScoresFromFile();
            if (topScores[TopScores.TopScoresAmount - 1] != null)
            {
                string lowestScore = Regex.Replace(topScores[TopScores.TopScoresAmount - 1], TopScores.TopScoresPersonPattern, @"$2");
                if (int.Parse(lowestScore) < this.Turn)
                {
                    Console.WriteLine("You couldn't get in the top {0} scoreboard.", TopScores.TopScoresAmount);
                    return;
                }
            }

            TopScores.UpgradeTopScore(this);
        }

    }
}
