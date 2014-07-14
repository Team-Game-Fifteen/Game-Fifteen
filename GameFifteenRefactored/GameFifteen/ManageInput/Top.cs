namespace GameFifteen.ManageInput
{
    using System;
    using System.Linq;

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
