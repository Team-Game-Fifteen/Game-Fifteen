namespace GameFifteen.ManageInput
{
    using System;
    using System.Linq;

    /// <summary>
    /// Top class for printing top list of players.
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
