using System;

namespace FridgeProduct.Auditable.Data.Models
{
    public class RecieveMessage
    {
        
        public int Id { get; set; }
        public string UserName { get; set; }
        public string EntityName { get; set; }
        public DateTime OperatedAt { get; set; }
        public string KeyValues { get; set; }
        public string OldValues { get; set; }
        public string NewValues { get; set; }
    }
}
