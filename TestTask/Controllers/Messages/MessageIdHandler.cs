namespace TestTask.Controllers.Messages
{
    public class MessageIdHandler
    {
        int messageId = 1;
        public int GetNewMessageId()
        {
            return messageId++;
        }
    }
}
