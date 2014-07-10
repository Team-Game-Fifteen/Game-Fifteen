using System;
using System.Linq;

namespace GameFifteen
{
    public class State
    {
        public State(int turn, Board board)
        {
            this.Turn = turn;
            //TODO modify Clone() implementation
            this.Board = (Board)board.Clone();
        }

        public Board Board { get; private set; }
        public int Turn { get; private set; }
    }
}
