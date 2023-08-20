using TestTask.Models;

namespace TestTask.Controllers.Messages
{
    public class MessageHandler
    {
        static int _size;
        private Queue<Message> MessagesList = new Queue<Message>(_size);

        public static async Task AddToMessagesList(MessageHandler handler, Message message)
        {
            if (handler.MessagesList.Count >= _size)
            {
                handler.MessagesList.Dequeue();
            }
            handler.MessagesList.Enqueue(message);
        }

        public static async Task<List<Message>> GetMessagesAsync(MessageHandler handler)
        {
            return handler.MessagesList.ToList();
        }


        public MessageHandler(int size)
        {
            _size = size;
        }
    }
}
