namespace GameFifteen_Tests
{
    using System;
    using System.IO;
    using System.Linq;
    using GameFifteen;
    using NUnit.Framework;

    [TestFixture]
    public class TestScore
    {
        [Test]
        public void TestGetTopScoresFromFile()
        {
            TopScores.GetTopScoresFromFile();
            string filePath = @"Top.txt";

            bool fileExist = File.Exists(filePath);
            Assert.IsTrue(fileExist);
        }
    }
}
