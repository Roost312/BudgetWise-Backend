using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using BudgetWise.Api.Entities;
using BudgetWise.Api.Models.Requests;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace BudgetWise.Api.Services
{
    public class AuthenticationService
    {
        private readonly BudgetWiseDbContext _dbContext;
        private readonly IConfiguration _configuration;

        public AuthenticationService(BudgetWiseDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }

        public UsersEntity? Authenticate(AuthenticationRequest request)
        {
            var user = _dbContext.Users.Single(u => u.Username.Equals(request.Username));
            var userHash = Hash(request.Password, user.Salt);

            var verifyHash = Hash(user.Password, user.Salt);

            return userHash.Equals(verifyHash) ? user : null;
        }
        
        public string BuildToken(UsersEntity user)
        {
            var jwtSettings = _configuration.GetSection("Authentication:Jwt").Get<JwtSettings>();
            var claims = new List<Claim>()
            {
                new Claim("budgetwise_user_id", user.Id.ToString()),
                new Claim("budgetwise_username", user.Username)
            };
            
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(jwtSettings.SigningKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Issuer = "https://localhost:5002",
                Audience = "https://localhost:5002",
                Expires = DateTime.UtcNow.AddDays((int) jwtSettings.ExpirationDays),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public string GenerateSalt()
        {
            byte[] salt = new byte[16];
            using RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            rng.GetBytes(salt);

            return Encoding.UTF8.GetString(salt);
        }

        private string Hash(string input, string salt)
        {
            var hash = new SHA256Managed().ComputeHash(Encoding.UTF8.GetBytes(salt + input));
            return string.Concat(hash.Select(b => b.ToString("x2")));
        }

    }
}