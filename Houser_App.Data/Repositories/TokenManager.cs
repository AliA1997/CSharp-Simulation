using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Houser_App.Data.Repositories
{
    public static class TokenManager
    {
        //Define a property called secret that will act as a secret key for tokens.
        //Create it using online generator or generate it using c#.
        public static HMACSHA256 hmac = new HMACSHA256();
        private static string key = Convert.ToBase64String(hmac.Key);

        private static string Secret = "XCAP05H6LoKvbRRa/QkqLNMI7cOHguaRyHzyg7n5qEkGjQmtBhz4SzYh4Fqwjyi3KJHlSXKPwVu2+bXr6CtpgQ==";

        //Generate a token using the user's username
        public static string GenerateToken(string username)
        {
            byte[] key = Convert.FromBase64String(Secret);

            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(key);

            //Security Token Descriptor represents the main context of the json web token
            //It will contain claims, expires, and signing credentials.
            SecurityTokenDescriptor descriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, username)
                }),
                //The security token will last for 2 hours
                Expires = DateTime.UtcNow.AddMinutes(120),
                SigningCredentials = new SigningCredentials(
                    securityKey, SecurityAlgorithms.HmacSha256Signature
                )
            };

            //Now define a new instance of the JwtSecurityTokenHandler
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

            //THen define a new jwt security token using the handler's create jwt token with your descriptor or the 
            //content of the jwt as an argument.
            JwtSecurityToken token = handler.CreateJwtSecurityToken(descriptor);

            return handler.WriteToken(token);
        }


        public static ClaimsPrincipal GetPrincipal(string token)
        {
            try
            {
                JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

                JwtSecurityToken jwtToken = (JwtSecurityToken)tokenHandler.ReadToken(token);

                if (jwtToken == null)
                    return null;

                byte[] key = Convert.FromBase64String(Secret);

                //Define the parameters for token validation.
                TokenValidationParameters parameters = new TokenValidationParameters()
                {
                    RequireExpirationTime = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                };

                //Define a security which would be used as a parameter.
                SecurityToken securityToken;

                //Retrieve multiple claims.
                ClaimsPrincipal principal = tokenHandler.ValidateToken(token, parameters, out securityToken);

                return principal;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public static string ValidateToken(string token)
        {
            string username = null;
            //Define a principal when it retrieves a token.
            ClaimsPrincipal principal = GetPrincipal(token);

            //If the principal is null return null.
            if (principal == null)
                return null;

            //If the identitiy is null return null.
            ClaimsIdentity identity = null;
            try
            {
                //Assign the Identity variables a casted claimsIdentity with the principal identity property.
                identity = (ClaimsIdentity)principal.Identity;
            }
            catch (NullReferenceException)
            {
                //If there is a null reference exception then return null.
                return null;
            }

            //Find the first username claim from the identity
            Claim usernameClaim = identity.FindFirst(ClaimTypes.Name);

            //Assign the username you want to return to teh usernameClaim value.
            username = usernameClaim.Value;
            
            //Then return the usernam.
            return username;
        }
    }
}
