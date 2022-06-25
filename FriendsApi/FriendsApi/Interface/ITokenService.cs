using FriendsApi.Models;
using System.Threading.Tasks;

namespace FriendsApi.Interface
{
    public interface ITokenService
    {
        Task<string> CreateToken(AppUser user)
 ;   }
}
