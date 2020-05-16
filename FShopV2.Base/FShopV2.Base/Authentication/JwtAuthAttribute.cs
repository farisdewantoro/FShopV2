using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace FShopV2.Base.Authentication
{
    public class JwtAuthAttribute : AuthAttribute
    {
        public JwtAuthAttribute(string policy = "") : base(JwtBearerDefaults.AuthenticationScheme, policy)
        {
        }
    }
}