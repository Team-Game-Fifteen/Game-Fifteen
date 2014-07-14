namespace GameFifteen
{
    using System;
    using System.Linq;

    /// <summary>
    /// class to define the needed information to save game state
    /// </summary>
    public class State
    {
        public State(int turn, Board board)
        {
            this.Turn = turn;
            this.Matrix = (string[,])board.Matrix.Clone();
            this.EmptyCellColumn = board.EmptyCellColumn;
            this.EmptyCellRow = board.EmptyCellRow;
        }

        public int Turn { get; private set; }

        public string[,] Matrix { get; private set; }

        public int EmptyCellRow { get; private set; }

        public int EmptyCellColumn { get; private set; }
    }
}
