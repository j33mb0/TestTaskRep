using TestTask.Models;

namespace TestTask.Controllers.Messages
{

    public class MessageController : IMessageController
    {
        MessageIdHandler idHandler = new MessageIdHandler();
        MessageHandler Handler = new MessageHandler(20);

        public async Task<Message> CreateNewMessage(string _username, string _message)
        {
            return new Message { Id = idHandler.GetNewMessageId(), UserName = _username, Text = _message, Time = DateTime.Now.ToString() };
        }

        public async Task<List<Message>> GetMessagesAsync()
        {
            return await MessageHandler.GetMessagesAsync(Handler);
        }

        public async Task AddToMessagesList(Message message)
        {
            await MessageHandler.AddToMessagesList(Handler, message);
        }


    }

}
