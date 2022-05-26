using System;

namespace FridgeProduct.Entities.DataTransferObjects.Auth
{
    public class AuthenticatedResponse
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenExpiration { get; set; }
    }
}
