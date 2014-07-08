namespace GameFifteen
{
    using System;

    public struct PersonalScore
    {
        private string userName;
        private int userScore;

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
