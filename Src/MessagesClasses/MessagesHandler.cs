using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memorer.Src.MessagesClasses
{
    internal class MessagesHandler
    {
        public Messages Messages { get; private set; }
        public MessagesHandler()
        {
            Messages = new Messages();
        }
    }
}
