using System;

namespace FridgeProduct.Entities.DataTransferObjects
{
    public class Auditable
    {
        //public Guid Id { get; set; }
        /*public string UserId { get; set; }
        public string EntityName { get; set; }
        public string Operation { get; set; }
        public DateTime Changed { get; set; }
        public string OldData { get; set; }
        public string NewData { get; set; }*/
        public int Id { get; set; }
        public string Username { get; set; }
        public string EntityName { get; set; }

        public DateTime OperatedAt { get; set; }

        public string KeyValues { get; set; }

        public string OldValues { get; set; }

        public string NewValues { get; set; }
    }
}
