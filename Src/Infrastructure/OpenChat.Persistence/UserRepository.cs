using System.Linq;
using OpenChat.Application.Users;
using OpenChat.Domain.Entities;

namespace OpenChat.Persistence
{
    public class UserRepository : IUserRepository
    {
        private readonly OpenChatDbContext dbContext;

        public UserRepository(OpenChatDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Add(User user)
        {
            dbContext.Users.Add(user);
            dbContext.SaveChanges();
        }

        public bool IsUsernameInUse(string username)
        {
            return dbContext.Users.Any(u => u.Username == username);
        }
    }
}