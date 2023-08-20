namespace TestTask.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Queue<Message> Messages { get; set; } = new Queue<Message>(10);
    }
}
