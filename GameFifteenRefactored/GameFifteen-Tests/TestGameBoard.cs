using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using GameFifteen;

namespace GameFifteen_Tests
{
    [TestFixture]
    class TestGameBoard
    {
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

        [Test]
        public void TestInitializeMatrix()
        {
            GameBoard testBoard = new GameBoard();

            string[,] expectedOutput = 
            {
                {"1", "2", "3", "4"},
                {"5", "6", "7", "8"},
                {"9", "10", "11", "12"},
                {"13", "14", "15", " "}
            };

            string[,] actualOutput = testBoard.Matrix;
            bool equalMatrices = AreMatricesEqual(expectedOutput, actualOutput);

            Assert.IsTrue(equalMatrices);
        }

        [Test]
        public void TestShuffleMatrix()
        {
            GameBoard testBoard = new GameBoard();
            testBoard.ShuffleMatrix();

            string[,] matrixBeforeShuffle = 
            {
                {"1", "2", "3", "4"},
                {"5", "6", "7", "8"},
                {"9", "10", "11", "12"},
                {"13", "14", "15", " "}
            };

            string[,] matrixAfterShuffle = testBoard.Matrix;
            bool equalMatrices = AreMatricesEqual(matrixBeforeShuffle, matrixAfterShuffle);

            Assert.IsFalse(equalMatrices);
        }

        [Test]
        public void TestNextMove()
        {
            GameBoard testBoard = new GameBoard();
            testBoard.NextMove(15);

            string[,] expectedMatrixAfterNextMove = 
            {
                {"1", "2", "3", "4"},
                {"5", "6", "7", "8"},
                {"9", "10", "11", "12"},
                {"13", "14", " ", "15"}
            };

            string[,] actualMatrixAfterNextMove = testBoard.Matrix;
            bool equalMatrices = AreMatricesEqual(expectedMatrixAfterNextMove, actualMatrixAfterNextMove);

            Assert.IsTrue(equalMatrices);
        }
    }
}
