using BTL_Platform.Models;

namespace BTL_Platform.Intrface
{
    public interface IUserRepository
    {
        List<User> GetUsers();
        User GetUser(string id);

        void Insert(User user);
        void Update(string id, User user);
        void Delete(string id);
        void Save();
    }
}
