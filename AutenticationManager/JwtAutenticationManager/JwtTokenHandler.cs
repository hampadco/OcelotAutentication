using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

public class JwtTokenHandler
{
    public const string SecretKey = "xyz1234567890";
    //token expiration time 20 minutes
    public const int TokenExpirationTime = 20;

    //UserAccunt 
    private readonly List<UserAccunt> _userAccunt;

    public JwtTokenHandler()
    {
        _userAccunt = new List<UserAccunt>
        {
            new UserAccunt { UserName = "admin", Password = "admin", Role = "Admin" },
            new UserAccunt { UserName = "user", Password = "user", Role = "User" }

        };
    }

        //generate token by AutenticationResponse and AutenticationRequest
        public AutenticationResponse GenerateToken(AutenticationRequest request)
        {
            var user = _userAccunt.SingleOrDefault(x => x.UserName == request.UserName && x.Password == request.Password);
            if (user == null) return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(SecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Role, user.Role)
                }),
                Expires = DateTime.UtcNow.AddMinutes(TokenExpirationTime),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var autenticationResponse = new AutenticationResponse
            {
                Token = tokenHandler.WriteToken(token),
                Role = user.Role,
                UserName = user.UserName,
                Expiration = (int)TokenExpirationTime
            };
            return autenticationResponse;

        }
        
    }
