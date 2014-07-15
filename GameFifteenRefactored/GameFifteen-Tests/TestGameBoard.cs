namespace GameFifteen_Tests
{
    using System;
    using System.Linq;
    using GameFifteen;
    using NUnit.Framework;

    [TestFixture]
    public class TestGameBoard
    {
        [Test]
        public void TestShuffleMatrix()
        {
            Board testBoard = new Board();
            testBoard.ShuffleMatrix();

            string[,] matrixBeforeShuffle = 
            {
                { "1", "2", "3", "4" },
                { "5", "6", "7", "8" },
                { "9", "10", "11", "12" },
                { "13", "14", "15", " " }
            };

            string[,] matrixAfterShuffle = testBoard.Matrix;
            bool equalMatrices = this.AreMatricesEqual(matrixBeforeShuffle, matrixAfterShuffle);

            Assert.IsFalse(equalMatrices);
        }       

        private bool AreMatricesEqual(string[,] testMatrix, string[,] testedMatrix)
        {
            if (testMatrix.GetLength(0) != testedMatrix.GetLength(0))
            {
                return false;
            }

            if (testMatrix.GetLength(1) != testedMatrix.GetLength(1))
            {
                return false;
            }

            for (int row = 0; row < testMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < testMatrix.GetLength(1); col++)
                {
                    if (testMatrix[row, col] != testedMatrix[row, col])
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
