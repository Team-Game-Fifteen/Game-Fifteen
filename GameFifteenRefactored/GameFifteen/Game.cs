namespace GameFifteen
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class Game
    {
        public Game()
        {
            this.Turn = 0;
            this.Board = Board.Instance;
            this.SavedStates = new Stack();
        }

        public int Turn { get; private set; }
        public Board Board { get; private set; }
        public Stack SavedStates { get; private set; }

        public void SaveState()
        {
            this.SavedStates.Push(new State(this.Turn, this.Board));
        }

        public void RestoreState()
        {
            if (this.SavedStates.Count == 0)
            {
                ConsoleWriter.PrintNoSavedStateMessage();
            }
            else
            {
                State lastState = (State)this.SavedStates.Pop();
                this.Turn = lastState.Turn;
                this.Board.ResetBoard(lastState);
            }
        }

        public void LoadTurns()
        {
            this.Board.MovePerformed += new EventHandler<MovePerformedEventArgs>(UpdateTurns);
        }

        private void UpdateTurns(object sender, MovePerformedEventArgs e)
        {
            this.Turn++;
          //  Console.WriteLine(this.Turn);
        }
    }
}
