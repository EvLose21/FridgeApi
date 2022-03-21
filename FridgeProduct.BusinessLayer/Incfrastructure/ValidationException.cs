using System;

namespace FridgeProduct.BusinessLayer.Incfrastructure
{
    public class ValidationException : Exception
    {
        public string Property { get; protected set; }
        public ValidationException(string message, string prop) 
            : base(message)
        {
            Property = prop;
        }
    }
}
