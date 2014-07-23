namespace GameFifteen.ManageInput
{
    using System;
    using System.Linq;
    using Interfaces;

    /// <summary>
    /// Print top list of players.
    /// </summary>
    public class Top : ICommand
    {
        public Top()
        {
        }

        public void Execute(params object[] list)
        {
            ConsoleWriter.PrintTopScores();
        }
    }
}
