namespace GameFifteen
{
    using System;
    using System.Linq;

    public sealed class Board
    {
        public const int MatrixSizeRows = 4;
        public const int MatrixSizeColumns = 4;
        public const int MatrixSize = MatrixSizeRows * MatrixSizeColumns;

        private const string EmptyCellValue = " ";
        private readonly int[] DirectionRow = { -1, 0, 1, 0 };
        private readonly int[] DirectionColumn = { 0, 1, 0, -1 };
        private int emptyCellRow;
        private int emptyCellColumn;

        private Random random = new Random();

        private static readonly Board board = new Board();
              
        public static Board Instance
        {
            get
            {
                return board;
            }
        }

        private Board()
        {
            this.InitializeMatrix();
            
        }

        public string[,] Matrix { get; private set; }
        public int EmptyCellRow { get; private set; }
        public int EmptyCellColumn { get; private set; }

        public bool CheckIfCellIsValid(int direction)
        {
            int nextCellRow = this.emptyCellRow + this.DirectionRow[direction];
            bool isRowValid = nextCellRow >= 0 && nextCellRow < MatrixSizeRows;
            int nextCellColumn = this.emptyCellColumn + this.DirectionColumn[direction];
            bool isColumnValid = nextCellColumn >= 0 && nextCellColumn < MatrixSizeColumns;
            bool isCellValid = isRowValid && isColumnValid;

            return isCellValid;
        }

        public void ShuffleMatrix()
        {
            int matrixSize = MatrixSizeRows * MatrixSizeColumns;
            int shuffles = this.random.Next(matrixSize, matrixSize * 100);
            for (int i = 0; i < shuffles; i++)
            {
                int direction = this.random.Next(this.DirectionRow.Length);
                if (this.CheckIfCellIsValid(direction))
                {
                    this.MoveCell(direction);                    
                }
            }

            if (this.IsMatrixOrdered())
            {
                this.ShuffleMatrix();
            }
        }

        public void NextMove(int cellNumber)
        {
            if (cellNumber <= 0 || cellNumber >= MatrixSize)
            {
                ConsoleWriter.PrintCellDoesNotExistMessage();
                return;
            }

            int direction = this.CellNumberToDirection(cellNumber);
            if (direction == -1)
            {
                ConsoleWriter.PrintIllegalMoveMessage();
                return;
            }

            this.MoveCell(direction);
            ConsoleWriter.PrintMatrix(this);
        }

        public bool IsMatrixOrdered()
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
                    if (this.Matrix[row, column] != cellValue.ToString())
                    {
                        return false;
                    }

                    cellValue++;
                }
            }

            return true;
        }

        private void InitializeMatrix()
        {
            this.Matrix = new string[MatrixSizeRows, MatrixSizeColumns];
            int cellValue = 1;

            for (int row = 0; row < MatrixSizeRows; row++)
            {
                for (int column = 0; column < MatrixSizeColumns; column++)
                {
                    this.Matrix[row, column] = cellValue.ToString();
                    cellValue++;
                }
            }

            this.emptyCellRow = MatrixSizeRows - 1;
            this.emptyCellColumn = MatrixSizeColumns - 1;
            this.Matrix[this.emptyCellRow, this.emptyCellColumn] = EmptyCellValue;
        }
        
        private void MoveCell(int direction)
        {
            int nextCellRow = this.emptyCellRow + this.DirectionRow[direction];
            int nextCellColumn = this.emptyCellColumn + this.DirectionColumn[direction];
            this.Matrix[this.emptyCellRow, this.emptyCellColumn] = this.Matrix[nextCellRow, nextCellColumn];
            this.Matrix[nextCellRow, nextCellColumn] = EmptyCellValue;
            this.emptyCellRow = nextCellRow;
            this.emptyCellColumn = nextCellColumn;
            // TODO on each move increase game.Turn through event
        }

        private int CellNumberToDirection(int cellNumber)
        {
            int direction = -1;
            for (int dir = 0; dir < this.DirectionRow.Length; dir++)
            {
                bool isDirValid = this.CheckIfCellIsValid(dir);

                if (isDirValid)
                {
                    int nextCellRow = this.emptyCellRow + this.DirectionRow[dir];
                    int nextCellColumn = this.emptyCellColumn + this.DirectionColumn[dir];

                    if (this.Matrix[nextCellRow, nextCellColumn] == cellNumber.ToString())
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
