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
                // TODO: IMPLEMENT DATA VALIDATION
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
                //TODO: IMPLEMENT DATA VALIDATION
                this.userScore = value;
            }
        }
    }
}
