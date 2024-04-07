using BTL_Platform.Models;

namespace BTL_Platform.Intrface
{
    public interface IUserRepository
    {
        List<User> GetUsers();
        User GetUser(long id);

        void Insert(User user);
        void Update(long id, User user);
        void Delete(long id);
        void Save();
    }
}
