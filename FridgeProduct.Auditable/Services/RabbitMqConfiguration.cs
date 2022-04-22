namespace FridgeProduct.Auditable.Services
{
    public class RabbitMqConfiguration
    {
        public string Hostname { get; set; }
        public string QueueName { get; set; }
        public bool Enabled { get; set; }
    }
}
