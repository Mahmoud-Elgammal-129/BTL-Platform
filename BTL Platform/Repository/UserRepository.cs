using BTL_Platform.Intrface;
using BTL_Platform.Models;

namespace BTL_Platform.Repository
{
    public class UserRepository : IUserRepository
    {
        BTLContext bTLContext;
        public UserRepository(BTLContext _bTLContext)
        {

            bTLContext = _bTLContext;
        }
        public void Delete(string id)
        {
            User UserToDelete = GetUser(id);
            if (UserToDelete != null)
            {
                UserToDelete.IsDeleted = true;
                bTLContext.Users.Update(UserToDelete);
                Save(); 
            }
        }

        public User GetUser(string id)
        {
            User user = bTLContext.Users.FirstOrDefault(a => a.Id == id&&a.IsDeleted==false);
            return user;
        }

        public List<User> GetUsers()
        {
            var user = bTLContext.Users.Where(a => a.IsDeleted == false).ToList();
            return user;
        }

        public void Insert(User user)
        {
            bTLContext.Users.Add(user);
            bTLContext.SaveChanges();
        }

        public void Save()
        {
            bTLContext.SaveChanges();
        }

        public void Update(string id, User user)
        {
            User OldUser = GetUser(id);
            OldUser.UserId = user.UserId;
            OldUser.UserName = user.UserName;
            OldUser.Email = user.Email;
            OldUser.Team = user.Team;

            bTLContext.Users.Update(OldUser);
            Save();
        }
    }
}
