using System;

namespace FridgeProduct.Auditable.Data.Models
{
    public class RecieveMessage
    {
        public Guid Id { get; set; }
        //public Guid UserId { get; set; }
        public string Message { get; set; }
        //public DateTime Changed { get; set; }
        //public string OldData { get; set; }
        //public string NewData { get; set; }
    }
}
