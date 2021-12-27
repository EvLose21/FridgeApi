using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeProduct.Entities.DataTransferObjects
{
    public class FridgeDto
    {
        public Guid Id { get; set; }
        public Guid ModelId { get; set; }
        public string Names { get; set; }
    }
}
