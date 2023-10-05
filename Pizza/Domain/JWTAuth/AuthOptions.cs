using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Pizza.Domain.JWTAuth
{
    public class AuthOptions
    {
        public const string ISSUER = "PizzaClient";
        public const string AUDIENCE = "PizzaClientServer";
        private const string KEY = "Gk3pKXLJsP3KA8qQyvx88aL2cJwBxM4zFmB33ShdFKXeQkeAouPOH7I8sFn1ztIICwbG7E";
        public static SymmetricSecurityKey GetSymmetricSecurityKey() =>
            new(Encoding.UTF8.GetBytes(KEY));
    }
}
