namespace GameFifteen.ManageInput
{
    using System;
    using System.Linq;

    public interface ICommand
    {
        void Execute(params object[] list);
    }
}
