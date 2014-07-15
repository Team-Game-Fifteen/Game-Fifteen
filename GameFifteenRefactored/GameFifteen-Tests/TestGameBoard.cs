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
        public void TestInitializeMatrix() //Initialize method changed.
        {
            Board testBoard = new Board();

            string[,] expectedOutput = 
            {
                { "1", "2", "3", "4" },
                { "5", "6", "7", "8" },
                { "9", "10", "11", "12" },
                { "13", "14", "15", " " }
            };

            string[,] actualOutput = testBoard.Matrix;
            bool equalMatrices = this.AreMatricesEqual(expectedOutput, actualOutput);

            Assert.IsTrue(equalMatrices);
        }

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

        [Test]
        public void TestNextMove() //Initialize method changed.
        {
            Board testBoard = new Board();
            testBoard.NextMove(15);

            string[,] expectedMatrixAfterNextMove = 
            {
                { "1", "2", "3", "4" },
                { "5", "6", "7", "8" },
                { "9", "10", "11", "12" },
                { "13", "14", " ", "15" }
            };

            string[,] actualMatrixAfterNextMove = testBoard.Matrix;
            bool equalMatrices = this.AreMatricesEqual(expectedMatrixAfterNextMove, actualMatrixAfterNextMove);

            Assert.IsTrue(equalMatrices);
        }

        [Test]
        public void TestIsMatrixOrdered() //Initialize method changed.
        {
            Board testBoard = new Board();

            bool isMatrixOrdered = testBoard.IsMatrixOrdered();
            Assert.IsTrue(isMatrixOrdered);
        }

        [Test]
        public void TestCheckIfCellIsValid() //Initialize method changed.
        {
            Board testBoard = new Board();

            int direction = 3;
            bool cellIsValid = testBoard.CheckIfCellIsValid(direction);

            Assert.IsTrue(cellIsValid);
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
