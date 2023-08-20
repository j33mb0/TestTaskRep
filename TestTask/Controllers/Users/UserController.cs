using TestTask.Models;

namespace TestTask.Controllers.Users
{
    public class UserController:IUserController
    {
        UserIdHandler idHandler = new UserIdHandler();
        UserHandler userHandler = new UserHandler();

        public async Task<bool> UserExistence(string username)
        {
            return await userHandler.UserExistence(username);
        }

        public async Task CreateNewUser(string username)
        {
            var user = await userHandler.CreateNewUser(idHandler.GetNewUserId(), username);
            await userHandler.AddUserInList(user);
        }

        public async Task<User> GetUserByNickname(string nickname)
        {
            return await userHandler.GetUserByNickname(nickname);
        }

        public async Task AddMessagesToUserMessagesList(User user, Message message)
        {
            await userHandler.AddMessagesToUserMessagesList(user, message);
        }



    }
}
