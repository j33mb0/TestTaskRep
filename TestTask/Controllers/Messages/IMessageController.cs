using TestTask.Models;

namespace TestTask.Controllers.Messages
{
    public interface IMessageController
    {
        Task<List<Message>> GetMessagesAsync();
        Task AddToMessagesList(Message message);
        Task<Message> CreateNewMessage(string _username, string _message);
    }
}
