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
        public Guid FridgeModelId { get; set; }
        public string Name { get; set; }
        public string OwnerName { get; set; }
    }
}
