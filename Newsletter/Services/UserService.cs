using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newsletter.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Newsletter.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IConfiguration _configuration;

        public UserService(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        public async Task<IdentityUser> CreateUser(CreateUser createUser)
        {
            IdentityUser user = new IdentityUser(createUser.UserName);
            var result = await _userManager.CreateAsync(user, createUser.Password);
            if (result.Succeeded) return user;
            return null;
        }

        public async Task<bool> DeleteUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            var result = await _userManager.DeleteAsync(user);
            return result.Succeeded;
        }

        public async Task<bool> ExistsUser(string id)
        {
            var result = await _userManager.FindByIdAsync(id);
            if (result == null) return false;
            return true;
        }

        public async Task<IEnumerable<IdentityUser>> GetAllUsers()
        {
            IQueryable<IdentityUser> result = _userManager.Users;

            return await result.ToListAsync();
        }

        public async Task<IdentityUser> GetUserById(string id)
        {
            var result = await _userManager.FindByIdAsync(id);
            return result;
        }

        public async Task<IdentityUser> GetUserByUserName(string userName)
        {
            var result = await _userManager.FindByNameAsync(userName);
            return result;
        }

        public async Task<IdentityUser> UpdateUser(IdentityUser user)
        {
            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded) return user;
            return null;
        }

        public async Task<string> GenerateJwtToken(CreateUser user)
        {
            var userLogin = await _userManager.FindByNameAsync(user.UserName.ToUpper());
            var result = await _signInManager.CheckPasswordSignInAsync(userLogin, user.Password, false);

            if (result.Succeeded)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, userLogin.NormalizedUserName)
                };

                var roles = await _userManager.GetRolesAsync(userLogin);

                foreach (var role in roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role));
                }

                var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration.GetSection("AppSettings:Token").Value));
                var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

                var tokenDescription = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),
                    Expires = DateTime.Now.AddDays(1),
                    SigningCredentials = credentials
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var token = tokenHandler.CreateToken(tokenDescription);

                return tokenHandler.WriteToken(token);
            }
            return null;
        }
    }
}
