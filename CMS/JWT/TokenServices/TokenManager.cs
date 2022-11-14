using CMS.Models.Shared;
using CMS.Models.User;

using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CMS.JWT.TokenServices
{
    public class TokenManager : ITokenManager
    {
        /// <summary>
        ///  Object of type TokenBuilder which is then chained in series of 
        ///  methods which add Audience, Issuer, Expiry, Key and Claims to the token
        /// </summary>
        /// <param name="user"></param>
        /// <returns>AuthToken</returns>
        public AuthToken Generate(User user)
        {
            List<Claim> claims = new List<Claim>() {
                new Claim (JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim (JwtRegisteredClaimNames.Email, user.EmailAddress),
                new Claim (JwtRegisteredClaimNames.UniqueName, user.UserName),
                new Claim (JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim (ClaimTypes.Role, user.Role),
                 new Claim (ClaimTypes.Email, user.EmailAddress)
            };
            

            JwtSecurityToken token = new TokenBuilder()
            .AddAudience(TokenConstants.Audience)
            .AddIssuer(TokenConstants.Issuer)
            .AddExpiry(TokenConstants.ExpiryInMinutes)
            .AddKey(TokenConstants.key)
            .AddClaims(claims)
            .Build();


            /// <summary>
            ///  generate the token by creating an instance of JwtSecurityTokenHandler class and invoking
            ///  WriteToken() method with the created SecurityToken instance.
            /// </summary>

            string accessToken = new JwtSecurityTokenHandler().WriteToken(token);

            return new AuthToken()
            {
                AccessToken = accessToken,
                ExpiresIn = TokenConstants.ExpiryInMinutes
            };
        }

    }
}