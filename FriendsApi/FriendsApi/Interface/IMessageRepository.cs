using FriendsApi.DTOs;
using FriendsApi.Helpers;
using FriendsApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FriendsApi.Interface
{
    public interface IMessageRepository
    {
        void AddMessage(Message message);
        void DeleteMessage (Message message);
        Task<Message> GetMessage(int id);
        Task<PagedList<MessageDto>> GetMessagesForUser();
        Task<IEnumerable<MessageDto>> GetMessageThread(int currentUserId, int recipientId);
        Task<bool> SaveAllAsync();

    }
}
