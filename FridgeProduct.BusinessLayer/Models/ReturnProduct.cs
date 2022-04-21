using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeProduct.BusinessLayer.Models
{
    public class ReturnProduct
    {
        public Guid Id { get; set; }
        public EnumProductValidation Status { get; set; }
    }
}
