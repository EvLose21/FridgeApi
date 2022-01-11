using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeProduct.Entities.DataTransferObjects
{
    public class FridgeToProductForCreationDto
    {
        public Guid ProductId { get; set; }
        public Guid FridgeId { get; set; }
        public int Quantity { get; set; }
    }
}
