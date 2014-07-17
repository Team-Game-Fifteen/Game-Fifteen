namespace GameFifteen
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Upgrades and returns player's score.
    /// </summary>
    public class TopScores
    {
        public const int TOP_SCORES_AMOUNT = 5;
        public const string TOP_SCORES_FILENAME = "Top.txt";
        public const string TOP_SCORES_PERSON_PATTERN = @"^\d+\. (.+) --> (\d+) moves?$";

        public static void UpgradeTopScore(Game game)
        {
            string[] topScores = GetTopScoresFromFile();
            ConsoleWriter.PrintMessage(Messages.TopScoreName);
            string name = Console.ReadLine();

            topScores[TOP_SCORES_AMOUNT] = string.Format("0. {0} --> {1} move", name, game.Turn);
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
                string[] topScores = new string[TOP_SCORES_AMOUNT + 1];
                StreamReader topReader = new StreamReader(TOP_SCORES_FILENAME);
                using (topReader)
                {
                    int line = 0;
                    while (!topReader.EndOfStream && line < TOP_SCORES_AMOUNT)
                    {
                        topScores[line] = topReader.ReadLine();
                        line++;
                    }
                }

                return topScores;
            }
            catch (FileNotFoundException)
            {
                StreamWriter topWriter = new StreamWriter(TOP_SCORES_FILENAME);
                using (topWriter)
                {
                    topWriter.Write(string.Empty);
                }

                return new string[TOP_SCORES_AMOUNT];
            }
        }

        private static void UpgradeTopScoreInFile(IOrderedEnumerable<PersonalScore> sortedScores)
        {
            StreamWriter topWriter = new StreamWriter(TOP_SCORES_FILENAME);
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

            int arraySize = Math.Min(TOP_SCORES_AMOUNT - startIndex + 1, TOP_SCORES_AMOUNT);
            PersonalScore[] topScoresPairs = new PersonalScore[arraySize];
            for (int topScoresPairsIndex = 0; topScoresPairsIndex < arraySize; topScoresPairsIndex++)
            {
                int topScoresIndex = topScoresPairsIndex + startIndex;
                string name = Regex.Replace(topScores[topScoresIndex], TOP_SCORES_PERSON_PATTERN, @"$1");
                string score = Regex.Replace(topScores[topScoresIndex], TOP_SCORES_PERSON_PATTERN, @"$2");
                int scoreInt = int.Parse(score);
                topScoresPairs[topScoresPairsIndex] = new PersonalScore(name, scoreInt);
            }

            return topScoresPairs;
        }
    }
}
