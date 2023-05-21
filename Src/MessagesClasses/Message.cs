namespace Memorer.Src.MessagesClasses
{
    public class Message
    {
        public string Content { get; private set; }
        public DateTime DateTime { get; private set; }

        public Message(string content, DateTime dateTime)
        {
            Content = content;
            DateTime = dateTime;
        }
    }
}
