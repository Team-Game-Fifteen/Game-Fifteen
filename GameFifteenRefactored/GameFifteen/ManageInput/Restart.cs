﻿namespace GameFifteen.ManageInput
{
    using System;
    using System.Linq;
    using Interfaces;

    /// <summary>
    /// Begins a new game.
    /// </summary>
    public class Restart : ICommand
    {
        /// <summary>
        /// The instance of the game to be restarted.
        /// </summary>
        private readonly Game game;

        /// <summary>
        /// Initializes a new instance of the <see cref="Restart"/> class.
        /// </summary>
        /// <param name="game">Current game instance.</param>
        public Restart(Game game)
        {
            this.game = game;
        }

        public void Execute(params object[] list)
        {
            this.game.Restart();
            ConsoleWriter.PrintMessage(Messages.Welcome());
            ConsoleWriter.PrintMatrix(this.game.Board);
        }
    }
}
