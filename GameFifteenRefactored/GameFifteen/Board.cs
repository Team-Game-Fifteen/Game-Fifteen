namespace GameFifteen
{
    using System;
    using System.Linq;

    public sealed class Board 
    {
        public const int MATRIX_SIZE_ROWS = 4;
        public const int MATRIX_SIZE_COLUMNS = 4;
        public const int MATRIX_SIZE = MATRIX_SIZE_ROWS * MATRIX_SIZE_COLUMNS;

        private const string EmptyCellValue = " ";
        private readonly int[] directionRow = { -1, 0, 1, 0 };
        private readonly int[] directionColumn = { 0, 1, 0, -1 };

        public event EventHandler<MovePerformedEventArgs> MovePerformed;

        private readonly Random random = new Random();
               
        public Board()
        {
            this.InitializeMatrix();
        }

        public string[,] Matrix { get; private set; } 

        public int EmptyCellRow { get; private set; }
        public int EmptyCellColumn { get; private set; }

        public bool CheckIfCellIsValid(int direction)
        {
            int nextCellRow = this.EmptyCellRow + this.directionRow[direction];
            bool isRowValid = nextCellRow >= 0 && nextCellRow < MATRIX_SIZE_ROWS;

            int nextCellColumn = this.EmptyCellColumn + this.directionColumn[direction];
            bool isColumnValid = nextCellColumn >= 0 && nextCellColumn < MATRIX_SIZE_COLUMNS;

            bool isCellValid = isRowValid && isColumnValid;

            return isCellValid;
        }

        public void NextMove(int cellNumber)
        {
            if (cellNumber <= 0 || cellNumber >= MATRIX_SIZE)
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
            this.OnMovePerformed();
            ConsoleWriter.PrintMatrix(this);
        }

        public bool IsMatrixOrdered()
        {
            bool isEmptyCellInPlace = (this.EmptyCellRow == MATRIX_SIZE_ROWS - 1) && (this.EmptyCellColumn == MATRIX_SIZE_COLUMNS - 1);
            if (!isEmptyCellInPlace)
            {
                return false;
            }

            int cellValue = 1;
            int matrixSize = MATRIX_SIZE_ROWS * MATRIX_SIZE_COLUMNS;
            for (int row = 0; row < MATRIX_SIZE_ROWS; row++)
            {
                for (int column = 0; column < MATRIX_SIZE_COLUMNS && cellValue < matrixSize; column++)
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

        public void ResetBoard(State state)
        {
            this.Matrix = state.Matrix;  // state.Matrix is a cloning of the original matrix
            this.EmptyCellColumn = state.EmptyCellColumn;
            this.EmptyCellRow = state.EmptyCellRow;
        }

        private void InitializeMatrix()
        {
            this.Matrix = new string[MATRIX_SIZE_ROWS, MATRIX_SIZE_COLUMNS];
            int cellValue = 1;

            for (int row = 0; row < MATRIX_SIZE_ROWS; row++)
            {
                for (int column = 0; column < MATRIX_SIZE_COLUMNS; column++)
                {
                    this.Matrix[row, column] = cellValue.ToString();
                    cellValue++;
                }
            }

            this.EmptyCellRow = MATRIX_SIZE_ROWS - 1;
            this.EmptyCellColumn = MATRIX_SIZE_COLUMNS - 1;
            this.Matrix[this.EmptyCellRow, this.EmptyCellColumn] = EmptyCellValue;
            this.ShuffleMatrix();  
        }
        
        private void ShuffleMatrix()
        {
            int matrixSize = MATRIX_SIZE_ROWS * MATRIX_SIZE_COLUMNS;
            int shuffles = this.random.Next(matrixSize, matrixSize * 100);
            for (int i = 0; i < shuffles; i++)
            {
                int direction = this.random.Next(this.directionRow.Length);
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

        private void MoveCell(int direction)
        {
            int nextCellRow = this.EmptyCellRow + this.directionRow[direction];
            int nextCellColumn = this.EmptyCellColumn + this.directionColumn[direction];
            this.Matrix[this.EmptyCellRow, this.EmptyCellColumn] = this.Matrix[nextCellRow, nextCellColumn];
            this.Matrix[nextCellRow, nextCellColumn] = EmptyCellValue;
            this.EmptyCellRow = nextCellRow;
            this.EmptyCellColumn = nextCellColumn;
        }

        private void OnMovePerformed()
        {
            if (this.MovePerformed != null)
            {
                this.MovePerformed(this, new MovePerformedEventArgs());
            }
        }

        private int CellNumberToDirection(int cellNumber)
        {
            int direction = -1;
            for (int dir = 0; dir < this.directionRow.Length; dir++)
            {
                bool isDirValid = this.CheckIfCellIsValid(dir);

                if (isDirValid)
                {
                    int nextCellRow = this.EmptyCellRow + this.directionRow[dir];
                    int nextCellColumn = this.EmptyCellColumn + this.directionColumn[dir];

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
