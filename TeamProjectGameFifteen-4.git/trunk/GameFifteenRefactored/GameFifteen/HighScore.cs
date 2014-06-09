namespace GameFifteen
{
    using System;

    class HighScore
    {
        private string name;
        private int score;

        public HighScore(string name, int score)
        {
            this.Name = name;
            this.Score = score;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                // TODO: IMPLEMENT DATA VALIDATION
                this.name = value;
            }
        }

        public int Score
        {
            get
            {
                return this.score;
            }

            set
            {
                //TODO: IMPLEMENT DATA VALIDATION
                this.score = value;
            }
        }
    }
}

//test!
