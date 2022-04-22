using FriendsApi.DTOs;
using FriendsApi.Helpers;
using FriendsApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FriendsApi.Interface
{
    public interface ILikesRepository
    {
        Task<UserLike> GetUserLike(int sourceUserId, int likedUserId);
        Task<AppUser> GetUserWithLikes(int userId);
        Task<PagedList<LikeDto>> GetUserLikes(LikesParams likesParams);
    }
}
