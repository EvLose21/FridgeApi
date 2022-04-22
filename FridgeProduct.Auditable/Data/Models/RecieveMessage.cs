using System;

namespace FridgeProduct.Auditable.Data.Models
{
    public class RecieveMessage
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public string EntityName { get; set; }
        public string Operation { get; set; }
        public DateTime Changed { get; set; }
        public string OldData { get; set; }
        public string NewData { get; set; }
    }
}
