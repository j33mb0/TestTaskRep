namespace TestTask.Controllers.Users
{
    public class UserIdHandler
    {
        int userId = 1;
        public int GetNewUserId()
        {
            return userId++;
        }
    }
}
