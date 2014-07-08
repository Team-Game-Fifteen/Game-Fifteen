namespace GameFifteen
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class Score
    {
        public const int TopScoresAmount = 5;
        public const string TopScoresFileName = "Top.txt";
        public const string TopScoresPersonPattern = @"^\d+\. (.+) --> (\d+) moves?$";

        public static void UpgradeTopScore(GameBoard board)
        {
            string[] topScores = GetTopScoresFromFile();
            Console.Write("Please enter your name for the top scoreboard: ");
            string name = Console.ReadLine();
            if (name == string.Empty)
            {
                name = "Anonymous";
            }

            topScores[TopScoresAmount] = string.Format("0. {0} --> {1} move", name, board.Turn);
            Array.Sort(topScores);

            PersonalScore[] topScoresPairs = UpgradeTopScorePairs(topScores);

            IOrderedEnumerable<PersonalScore> sortedScores =
            topScoresPairs.OrderBy(x => x.UserScore).ThenBy(x => x.UserName);

            UpgradeTopScoreInFile(sortedScores);
        }

        public static string[] GetTopScoresFromFile()
        {
            try
            {
                string[] topScores = new string[TopScoresAmount + 1];
                StreamReader topReader = new StreamReader(TopScoresFileName);
                using (topReader)
                {
                    int line = 0;
                    while (!topReader.EndOfStream && line < TopScoresAmount)
                    {
                        topScores[line] = topReader.ReadLine();
                        line++;
                    }
                }

                return topScores;
            }
            catch (FileNotFoundException)
            {
                StreamWriter topWriter = new StreamWriter(TopScoresFileName);
                using (topWriter)
                {
                    topWriter.Write(string.Empty);
                }

                return new string[TopScoresAmount];
            }
        }

        private static void UpgradeTopScoreInFile(IOrderedEnumerable<PersonalScore> sortedScores)
        {
            StreamWriter topWriter = new StreamWriter(TopScoresFileName);
            using (topWriter)
            {
                int position = 1;
                foreach (PersonalScore pair in sortedScores)
                {
                    string name = pair.UserName;
                    int score = pair.UserScore;
                    string toWrite = string.Format(
                        "{0}. {1} --> {2} move", position, name, score);
                    if (score > 1)
                    {
                        toWrite += "s";
                    }

                    topWriter.WriteLine(toWrite);
                    position++;
                }
            }
        }

        private static PersonalScore[] UpgradeTopScorePairs(string[] topScores)
        {
            int startIndex = 0;
            while (topScores[startIndex] == null)
            {
                startIndex++;
            }

            int arraySize = Math.Min(TopScoresAmount - startIndex + 1, TopScoresAmount);
            PersonalScore[] topScoresPairs = new PersonalScore[arraySize];
            for (int topScoresPairsIndex = 0; topScoresPairsIndex < arraySize; topScoresPairsIndex++)
            {
                int topScoresIndex = topScoresPairsIndex + startIndex;
                string name = Regex.Replace(topScores[topScoresIndex], TopScoresPersonPattern, @"$1");
                string score = Regex.Replace(topScores[topScoresIndex], TopScoresPersonPattern, @"$2");
                int scoreInt = int.Parse(score);
                topScoresPairs[topScoresPairsIndex] = new PersonalScore(name, scoreInt);
            }

            return topScoresPairs;
        }
    }
}
