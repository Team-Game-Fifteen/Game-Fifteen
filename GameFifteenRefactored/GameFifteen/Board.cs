namespace GameFifteen
{
    using System;
    using System.Linq;

    public sealed class Board 
    {
        public const int MATRIX_SIZE_ROWS = 4;

        public const int MATRIX_SIZE_COLUMNS = 4;

        public const int MATRIX_SIZE = MATRIX_SIZE_ROWS * MATRIX_SIZE_COLUMNS;

        private const string EMPTY_CELL_VALUE = " ";

        private readonly int[] directionRow = { -1, 0, 1, 0 };
        private readonly int[] directionColumn = { 0, 1, 0, -1 };
               
        private readonly Random random = new Random();

        /// <summary>
        /// Initializes a new instance of the <see cref="Board"/> class.
        /// </summary>
        public Board()
        {
            this.InitializeMatrix();
        }

        public event EventHandler<MovePerformedEventArgs> MovePerformed;

        public string[,] Matrix { get; private set; } 

        public int EmptyCellRow { get; private set; }

        public int EmptyCellColumn { get; private set; }

        /// <summary>
        /// Checks if a cell can be moved.
        /// </summary>
        /// <param name="direction">A number with value between 0 and 3, which is index of a move.</param>
        /// <returns>True if valid.</returns>
        public bool CheckIfCellIsValid(int direction)
        {
            int nextCellRow = this.EmptyCellRow + this.directionRow[direction];
            bool isRowValid = nextCellRow >= 0 && nextCellRow < MATRIX_SIZE_ROWS;

            int nextCellColumn = this.EmptyCellColumn + this.directionColumn[direction];
            bool isColumnValid = nextCellColumn >= 0 && nextCellColumn < MATRIX_SIZE_COLUMNS;

            bool isCellValid = isRowValid && isColumnValid;

            return isCellValid;
        }

        /// <summary>
        /// Checks if cell and directions are valid and if they are calls
        /// MoveCell() and OnMovePerformed().
        /// </summary>
        /// <param name="cellNumber">The number of the cell given by the player.</param>
        public void NextMove(int cellNumber)
        {
            if (cellNumber <= 0 || cellNumber >= MATRIX_SIZE)
            {
                ConsoleWriter.PrintMessage("That cell does not exist in the matrix.");
                return;
            }

            int direction = this.CellNumberToDirection(cellNumber);
            if (direction == -1)
            {
                ConsoleWriter.PrintMessage("Illegal move!");
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

        public void ShuffleMatrix()
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
            this.Matrix[this.EmptyCellRow, this.EmptyCellColumn] = EMPTY_CELL_VALUE;
            this.ShuffleMatrix();
        }

        private void MoveCell(int direction)
        {
            int nextCellRow = this.EmptyCellRow + this.directionRow[direction];
            int nextCellColumn = this.EmptyCellColumn + this.directionColumn[direction];
            this.Matrix[this.EmptyCellRow, this.EmptyCellColumn] = this.Matrix[nextCellRow, nextCellColumn];
            this.Matrix[nextCellRow, nextCellColumn] = EMPTY_CELL_VALUE;
            this.EmptyCellRow = nextCellRow;
            this.EmptyCellColumn = nextCellColumn;
        }

        /// <summary>
        /// This is used to count the turns made by the plaer.
        /// </summary>
        private void OnMovePerformed()
        {
            if (this.MovePerformed != null)
            {
                this.MovePerformed(this, new MovePerformedEventArgs());
            }
        }

        /// <summary>
        /// Finds in which direction the cell is allowed to move. 
        /// </summary>
        /// <param name="cellNumber">The number of the cell given by the player.</param>
        /// <returns>Number from 0 to 3, which is index representing direction.</returns>
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
