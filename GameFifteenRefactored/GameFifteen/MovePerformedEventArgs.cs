using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFifteen
{
    public class MovePerformedEventArgs : EventArgs
    {
        public MovePerformedEventArgs(int moves)
        {
            this.Moves = moves;
        }
        public int Moves { get; set; }
    }
}
