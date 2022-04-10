using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Architect4Hire.netCore6ApiStarter.Models
{
    public class AuthOptions
    {
        public const string ISSUER = "A4H";
        public const string AUDIENCE = "https://www.architect4hire.com/";
        const string KEY = "gVkYp3s5v8y/B?E(H+MbQeThWmZq4t7w9z$C&F)J@NcRfUjXn2r5u8x/A%D*G-KaPdSgVkYp3s6v9y$B&E(H+MbQeThWmZq4t7w!z%C*F-J@NcRfUjXn2r5u8x/A?D(G";
        public const int LIFETIME = 15;
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
