using System.Collections.Generic;

namespace FShopV2.Base.Authentication
{
    public interface IJwtHandler
    {
        JsonWebToken CreateToken(string userId, string role = null, IDictionary<string, string> claims = null);
        JsonWebTokenPayload GetTokenPayload(string accessToken);
    }
}