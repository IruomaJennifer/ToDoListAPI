
using CCSANoteApp.Domain;

namespace CCSANoteApp.Infrastructure
{
    public interface IUserService
    {
        void CreateUser(string username, string email, string password);
        void CreateUser(User user);
        void UpdateName(Guid id, string name);
        void UpdateEmail(Guid id, string email);
        void DeleteUser(Guid id);
        User GetUser(Guid id);
        List<User> GetUsers();
    }
}
