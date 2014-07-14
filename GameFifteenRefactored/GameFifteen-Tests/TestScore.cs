using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using GameFifteen;

namespace GameFifteen_Tests
{
    [TestFixture]
    class TestScore
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
