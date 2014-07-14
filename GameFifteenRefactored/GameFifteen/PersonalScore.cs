namespace GameFifteen
{
    using System;

    /// <summary>
    /// Defines how the score of each player is described
    /// </summary>
    public struct PersonalScore
    {
        /// <summary>
        /// the name of the player
        /// </summary>
        private string userName;

        /// <summary>
        /// the score of the player
        /// </summary>
        private int userScore;

        /// <summary>
        /// creates an instance of the player's score
        /// </summary>
        /// <param name="name"> name of the player </param>
        /// <param name="score"> player score </param>
        public PersonalScore(string name, int score)
            : this()
        {
            this.UserName = name;
            this.UserScore = score;
        }

        public string UserName
        {
            get
            {
                return this.userName;
            }

            set
            {
                if (value == string.Empty)
                {
                    value = "Anonymous";
                }

                this.userName = value;
            }
        }

        public int UserScore
        {
            get
            {
                return this.userScore;
            }

            set
            {
                this.userScore = value;
            }
        }
    }
}
