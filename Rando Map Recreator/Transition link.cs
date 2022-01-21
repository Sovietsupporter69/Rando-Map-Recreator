using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rando_Map_Recreator
{
    internal class Transition_link
    {
        public string EntryRoom;
        public string EntryDirection;
        public string ExitRoom;
        public string ExitDirection;

        public Transition_link()
        {
            EntryRoom = "Error";
            EntryDirection = "Error";
            ExitRoom = "Error";
            ExitDirection = "Error";
        }
        public Transition_link(string EntryRoom, string EntryDirection, string ExitRoom, string ExitDirection)
        {
            this.EntryRoom = EntryRoom;
            this.EntryDirection = EntryDirection;
            this.ExitRoom = ExitRoom;
            this.ExitDirection = ExitDirection;
        }
    }
}
