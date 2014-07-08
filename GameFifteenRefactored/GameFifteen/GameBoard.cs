
namespace GameFifteen
{
    using System;
    using System.Linq;

    public class GameBoard
    {
        // TODO implement Singleton pattern.
        
        public const int MatrixSizeRows = 4;
        public const int MatrixSizeColumns = 4;

        private const string EmptyCellValue = " ";
        private int emptyCellRow;
        private int emptyCellColumn;
        private readonly int[] DirectionRow = { -1, 0, 1, 0 };
        private readonly int[] DirectionColumn = { 0, 1, 0, -1 };
        private Random random = new Random();
        private int turn;

        private string[,] matrix;

        public GameBoard()
        {
            this.InitializeMatrix();
            this.Turn = 0;
        }

        public string[,] Matrix { get; private set; }
        public int Turn { get; private set; }

        public bool CheckIfCellIsValid(int direction)
        {
            int nextCellRow = emptyCellRow + DirectionRow[direction];
            bool isRowValid = (nextCellRow >= 0 && nextCellRow < MatrixSizeRows);
            int nextCellColumn = emptyCellColumn + DirectionColumn[direction];
            bool isColumnValid = (nextCellColumn >= 0 && nextCellColumn < MatrixSizeColumns);
            bool isCellValid = isRowValid && isColumnValid;

            return isCellValid;
        }

        public void ShuffleMatrix()
        {
            int matrixSize = MatrixSizeRows * MatrixSizeColumns;
            int shuffles = random.Next(matrixSize, matrixSize * 100);
            for (int i = 0; i < shuffles; i++)
            {
                int direction = random.Next(DirectionRow.Length);
                if (CheckIfCellIsValid(direction))
                {
                    MoveCell(direction);
                }
            }

            if (CheckIfInGoodOrder())
            {
                ShuffleMatrix();
            }
        }

        public void NextMove(int cellNumber)
        {
            int matrixSize = MatrixSizeRows * MatrixSizeColumns;
            if (cellNumber <= 0 || cellNumber >= matrixSize)
            {
                ConsoleWriter.PrintCellDoesNotExistMessage();
                return;
            }

            int direction = CellNumberToDirection(cellNumber);
            if (direction == -1)
            {
                ConsoleWriter.PrintIllegalMoveMessage();
                return;
            }

            MoveCell(direction);
            ConsoleWriter.PrintMatrix(this);
        }

        private void InitializeMatrix()
        {
            this.Matrix = new string[MatrixSizeRows, MatrixSizeColumns];
            int cellValue = 1;

            for (int row = 0; row < MatrixSizeRows; row++)
            {
                for (int column = 0; column < MatrixSizeColumns; column++)
                {
                    Matrix[row, column] = cellValue.ToString();
                    cellValue++;
                }
            }

            emptyCellRow = MatrixSizeRows - 1;
            emptyCellColumn = MatrixSizeColumns - 1;
            Matrix[emptyCellRow, emptyCellColumn] = EmptyCellValue;
        }

        public bool CheckIfInGoodOrder()
        {
            bool isEmptyCellInPlace = (this.emptyCellRow == MatrixSizeRows - 1) && (this.emptyCellColumn == MatrixSizeColumns - 1);
            if (!isEmptyCellInPlace)
            {
                return false;
            }

            int cellValue = 1;
            int matrixSize = MatrixSizeRows * MatrixSizeColumns;
            for (int row = 0; row < MatrixSizeRows; row++)
            {
                for (int column = 0; column < MatrixSizeColumns && cellValue < matrixSize; column++)
                {
                    if (Matrix[row, column] != cellValue.ToString())
                    {
                        return false;
                    }

                    cellValue++;
                }
            }

            return true;
        }

        private void MoveCell(int direction)
        {
            int nextCellRow = emptyCellRow + DirectionRow[direction];
            int nextCellColumn = emptyCellColumn + DirectionColumn[direction];
            Matrix[emptyCellRow, emptyCellColumn] = Matrix[nextCellRow, nextCellColumn];
            Matrix[nextCellRow, nextCellColumn] = EmptyCellValue;
            emptyCellRow = nextCellRow;
            emptyCellColumn = nextCellColumn;
            turn++;
        }

        private int CellNumberToDirection(int cellNumber)
        {
            int direction = -1;
            for (int dir = 0; dir < DirectionRow.Length; dir++)
            {
                bool isDirValid = CheckIfCellIsValid(dir);

                if (isDirValid)
                {
                    int nextCellRow = emptyCellRow + DirectionRow[dir];
                    int nextCellColumn = emptyCellColumn + DirectionColumn[dir];

                    if (Matrix[nextCellRow, nextCellColumn] == cellNumber.ToString())
                    {
                        direction = dir;
                        break;
                    }
                }
            }

            return direction;
        }


    }
}
