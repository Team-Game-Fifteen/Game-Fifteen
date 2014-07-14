namespace GameFifteen
{
    using System;
    using System.Collections;
    using System.Linq;

    /// <summary>
    /// game class for instantiating current game
    /// </summary>
    public class Game
    {
        private static readonly Game GameInstance = new Game();

        /// <summary>
        /// Prevents a default instance of the <see cref="Game"/> class from being created.
        /// </summary>
        private Game()
        {
            this.Turn = 0;
            this.Board = new Board();
            this.SavedStates = new Stack();
        }

        public static Game Instance
        {
            get
            {
                return GameInstance;
            }
        }

        public int Turn { get; private set; }

        public Board Board { get; private set; }

        public Stack SavedStates { get; private set; }

        public bool IsFinished { get; set; }

        public void Restart()
        {
            this.Turn = 0;
            this.Board = new Board();
            this.SavedStates = new Stack();
        }

        public void SaveState()
        {
            this.SavedStates.Push(new State(this.Turn, this.Board));
        }

        public void RestoreState()
        {
            if (this.SavedStates.Count == 0)
            {
                ConsoleWriter.PrintMessage("There is no state to be restored!");
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
            this.Board.MovePerformed += new EventHandler<MovePerformedEventArgs>(this.UpdateTurns);
        }

        private void UpdateTurns(object sender, MovePerformedEventArgs e)
        {
            this.Turn++;
            //// Console.WriteLine(this.Turn);
        }
    }
}
