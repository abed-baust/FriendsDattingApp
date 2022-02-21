using FriendsApi.Data;
using FriendsApi.DTOs;
using FriendsApi.Interface;
using FriendsApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FriendsApi.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly DataContext _context;
        private readonly ITokenService _tokenService;
        public AccountController(DataContext context, ITokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            if(await UserExists(registerDto.userName))
                return BadRequest("User Name is Taken!");

            using var hmac = new HMACSHA512();
            var user = new AppUser()
            {
                userName = registerDto.userName.ToLower(),
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.password)),
                passwordSalt = hmac.Key
            };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return new UserDto
            {
                UserName = user.userName,
                Token = _tokenService.CreateToken(user)
            };
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>>Login(LoginDto loginDto)
        {
            var user = await _context.Users.SingleOrDefaultAsync(x=>x.userName==loginDto.userName);
            if(user==null) return Unauthorized("Invalid username");
            using var hmac=new HMACSHA512(user.passwordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.password));
            for(int i = 0; i< computedHash.Length; i++)
            {
                if (computedHash[i] != user.passwordHash[i]) return Unauthorized("Invalid password");
            }
            return new UserDto
            {
                UserName = user.userName,
                Token = _tokenService.CreateToken(user)
            };
        }





        private async Task<bool> UserExists(string userName)
        {
            return await _context.Users.AnyAsync(x => x.userName == userName.ToLower());
        }
    }
}
