using TestTask.Models;

namespace TestTask.Controllers.Users
{
    public class UserHandler
    {
        private List<User> Users = new List<User>();

        public async Task<bool> UserExistence(string username)
        {
            var user = Users.FirstOrDefault(u => u.Name == username);
            if(user == null) return false;
            return true;
        }

        public async Task AddUserInList(User user)
        {
            Users.Add(user);
        }

        public async Task<User> CreateNewUser(int id, string username)
        {
            return new User { Id = id, Name = username };
        }

        public async Task<User> GetUserByNickname(string nickname)
        {
            return Users.FirstOrDefault(u => u.Name == nickname);
        }

        public async Task AddMessagesToUserMessagesList(User user, Message message)
        {
            if(user.Messages.Count >= 10)
                user.Messages.Dequeue();
            user.Messages.Enqueue(message);
        }



    }
}
