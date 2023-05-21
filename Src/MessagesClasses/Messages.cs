using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memorer.Src.MessagesClasses
{
    public class Messages : List<Message>
    {
        public Message? CheckMessages() => this.FirstOrDefault(message => message.DateTime <= DateTime.Now);
        new public void Add(Message item)
        {
            base.Add(item);
            Program.iOLogic.PutStringsToFile(this, IOLogic.Files.Messages);
            Program.DgvHandler?.Update();
        }
        new public void Remove(Message item)
        {
            base.Remove(item);
            Program.iOLogic.PutStringsToFile(this, IOLogic.Files.Messages);
            Program.DgvHandler?.Update();
        }
        public void Remove(int index)
        {
            base.Remove(this[index]);
            Program.iOLogic.PutStringsToFile(this, IOLogic.Files.Messages);
            Program.DgvHandler?.Update();
        }
    }
}
