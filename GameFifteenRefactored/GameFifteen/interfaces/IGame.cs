namespace GameFifteen.interfaces
{
    using System;

    interface IGame
    {
        void Restart();
        void SaveState();
        void RestoreState();
        void LoadTurns();
    }
}
