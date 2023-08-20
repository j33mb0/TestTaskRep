using TestTask.Models;

namespace TestTask.Controllers.Users
{
    public interface IUserController
    {
        Task<bool> UserExistence(string username);
        Task CreateNewUser(string username);
        Task<User> GetUserByNickname(string nickname);
        Task AddMessagesToUserMessagesList(User user, Message message);
    }
}
