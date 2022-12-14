using System.IdentityModel.Tokens.Jwt;
using System.Text;
using GeoPet.Constants;
using Microsoft.IdentityModel.Tokens;

namespace GeoPet.Services
{
  public class TokenGenerator
  {
    public string Generate()
    {
      JwtSecurityTokenHandler tokenHandler = new();

      byte[] key = Encoding.ASCII.GetBytes(TokenConstants.Secret);

      SecurityTokenDescriptor tokenDescriptor = new()
      {
        SigningCredentials = new SigningCredentials(
          new SymmetricSecurityKey(key),
          SecurityAlgorithms.HmacSha256Signature
      ),
        Expires = DateTime.Now.AddHours(5)
      };

      SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

      return tokenHandler.WriteToken(token);
    }
  }
}
