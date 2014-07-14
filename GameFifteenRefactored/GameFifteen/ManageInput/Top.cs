using System;
using System.Linq;

namespace GameFifteen.ManageInput
{
    class Top : ICommand
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
