namespace GameFifteen
{
    using System;

    /// <summary>
    /// Defines how the score of each player is described.
    /// </summary>
    public struct PersonalScore
    {
        /// <summary>
        /// The name of the player.
        /// </summary>
        private string userName;

        /// <summary>
        /// The score of the player.
        /// </summary>
        private int userScore;

        /// <summary>
        /// Initializes a new instance of the <see cref="PersonalScore"/> struct.
        /// </summary>
        /// <param name="name">Name of the player.</param>
        /// <param name="score">Player score.</param>
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
