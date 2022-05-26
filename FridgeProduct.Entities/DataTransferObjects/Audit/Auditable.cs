using System;

namespace FridgeProduct.Entities.DataTransferObjects
{
    public class Auditable
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string EntityName { get; set; }

        public DateTime OperatedAt { get; set; }

        public string KeyValues { get; set; }

        public string OldValues { get; set; }

        public string NewValues { get; set; }
    }
}
