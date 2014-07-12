namespace GameFifteen
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Game
    {
        public Game()
        {
            this.Turn = 0;
            this.Board = Board.Instance;
            this.SavedStates = new List<State>();
        }

        public int Turn { get; private set; }
        public Board Board { get; private set; }
        public IList<State> SavedStates { get; private set; } //Rewrite it with stack

        public void SaveState()
        {
            this.SavedStates.Add(new State(this.Turn, this.Board));
        }

        public void RestoreState()
        {
            if (this.SavedStates.Count == 0)
            {
                ConsoleWriter.PrintNoSavedStateMessage();
            }
            else
            {
                State lastState = this.SavedStates.Last();
                this.SavedStates.Remove(lastState);
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
        }
    }
}
