namespace GameFifteen.Interfaces
{
    using System;

    public interface IGame
    {
        void Restart();

        void SaveState();

        void RestoreState();

        void LoadTurns();
    }
}
