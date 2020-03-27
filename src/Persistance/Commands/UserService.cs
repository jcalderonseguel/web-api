using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Security.Claims;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using Application.Common.Helpers;
using Microsoft.IdentityModel.Tokens;

namespace Persistance.Commands
{
    public interface IUserService
    {
        Users Authenticate(string email, string password);

        IEnumerable<Users> GetAll();
    }

    public class UserService : IUserService
    {
        private readonly AppSettings _appSettings;
        private readonly ClientDbContext _context;

        public UserService(IOptions<AppSettings> appSettings, ClientDbContext context)
        {
            _appSettings = appSettings.Value;
            _context = context;
        }

        public bool ValidateCurrentToken(string token)
        {
            // var myIssuer = "http://mysite.com";
            // var myAudience = "http://myaudience.com";

            var tokenHandler = new JwtSecurityTokenHandler();
            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    //ValidateIssuer = true,
                    //ValidateAudience = true,
                    //ValidIssuer = myIssuer,
                    //ValidAudience = myAudience,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_appSettings.Secret)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                }, out SecurityToken validatedToken);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public Users Authenticate(string email, string password)
        {
            var user = _context.Users.SingleOrDefault(x => x.Email == email && x.Password == password);

            // return null if user not found
            if (user == null)
                return null;

            // authentication successful and token expired so generate jwt token

            if (!ValidateCurrentToken(user.Token))
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim(ClaimTypes.Email, user.UserId.ToString())
                    }),
                    Expires = DateTime.UtcNow.AddDays(_appSettings.TokenExpirationDays),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                user.Token = tokenHandler.WriteToken(token);
                // _context.Users.Update(user);
                _context.SaveChangesAsync();
            }

            return user.WithoutPassword();
        }

        public IEnumerable<Users> GetAll()
        {
            return _context.Users.WithoutPasswords();
        }
    }
}