using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeProduct.Entities.DataTransferObjects
{
    public class Auditable
    {
        public string EntityName { get; set; }
        public string Operation { get; set; }
        public DateTime Changed { get; set; }
    }
}
