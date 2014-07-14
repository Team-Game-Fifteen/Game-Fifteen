namespace GameFifteen_Tests
{
    using System;
    using System.Linq;
    using GameFifteen;
    using NUnit.Framework;

    [TestFixture]
    public class TestPersonalScore
    {
        [Test]
        public void TestPersonalScoreConstructor()
        {
            string testName = "Pesho";
            int testScore = 12;

            PersonalScore testEntry = new PersonalScore(testName, testScore);

            Assert.AreEqual(testName, testEntry.UserName, "They should be equal!");
            Assert.AreEqual(testScore, testEntry.UserScore, "They should be equal!");
        }

        [Test]
        public void TestPersonalScoreConstructorEmptyName()
        {
            string testName = string.Empty;
            int testscore = 12;

            PersonalScore testEntry = new PersonalScore(testName, testscore);

            Assert.AreEqual("Anonymous", testEntry.UserName, "User name should be Anonymous!"); 
        }
    }
}
