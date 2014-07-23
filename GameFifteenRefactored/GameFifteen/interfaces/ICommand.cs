namespace GameFifteen.Interfaces
{
    using System;
    using System.Linq;

    public interface ICommand
    {
        void Execute(params object[] list);
    }
}
