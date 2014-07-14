using System;
using System.Linq;

namespace GameFifteen.ManageInput
{
    public interface ICommand
    {
        void Execute(params object[] list);
    }
}
