using FriendsApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace FriendsApi.Data
{
    public class Seed
    {
        public static async Task SeedUsers(UserManager<AppUser>userManager)
        {
            if (await userManager.Users.AnyAsync()) return;

            var userData = await System.IO.File.ReadAllTextAsync("Data/UserSeedData.json");
            var users =JsonSerializer.Deserialize<List<AppUser>> (userData);
            if (users == null) return;

            foreach (var user in users)
            {
                //using var hmac = new HMACSHA512();
                
                user.UserName = user.UserName.ToLower();
                //user.passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Pa$$w0rd"));
                //user.passwordSalt = hmac.Key;
                await userManager.CreateAsync(user, "Pa$$w0rd");
            }
            
        }
    }
}
