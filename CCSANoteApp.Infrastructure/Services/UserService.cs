
using CCSANoteApp.Domain;

namespace CCSANoteApp.Infrastructure
{
    public class UserService : IUserService
    {
        static public List<User> users = new List<User>();

        public void CreateUser(string username, string email, string password)
        {
            users.Add(new User
            {
                Email = email,
                Username = username,
                Password = password
            });
        }

        public void CreateUser(User user)
        {
            users.Add(user);
        }

        public void DeleteUser(Guid id)
        {
            var user = users.FirstOrDefault(x => x.Id == id);
            if (user != null)
            {
                users.Remove(user);
            }
        }

        public User GetUser(Guid id)
        {
            var user = users.FirstOrDefault(x => x.Id == id);
            return user;
        }

        public List<User> GetUsers()
        {
            return users;
        }

        public void UpdateEmail(Guid id, string email)
        {
            var user = users.FirstOrDefault(x => x.Id == id);
            if (user != null)
            {
                user.Email = email;
            }
        }

        public void UpdateName(Guid id, string name)
        {
            var user = users.FirstOrDefault(x => x.Id == id);
            if (user != null)
            {
                user.Username = name;
            }
        }
    }
}
