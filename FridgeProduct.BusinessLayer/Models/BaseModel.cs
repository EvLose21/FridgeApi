using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeProduct.BusinessLayer.Models
{
    public class BaseModel
    {
        private ModelStateDictionary _modelState = new ModelStateDictionary();
        public ModelStateDictionary ModelState
        {
            get
            {
                return _modelState;
            }
            set
            {
                _modelState = value;
            }
        }
    }
}
