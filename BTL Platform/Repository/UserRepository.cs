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
            try
            {
                User userToDelete = GetUser(id);
                if (userToDelete != null)
                {
                    userToDelete.IsDeleted = true;
                    bTLContext.Users.Update(userToDelete);
                    Save();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while deleting the user: {ex.Message}");
                throw;
            }
        }

        public User GetUser(string id)
        {
            try
            {
                return bTLContext.Users.FirstOrDefault(a => a.Id == id && !a.IsDeleted);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while retrieving the user: {ex.Message}");
                throw;
            }
        }

        public List<User> GetUsers()
        {
            try
            {
                return bTLContext.Users.Where(a => !a.IsDeleted).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while retrieving users: {ex.Message}");
                throw;
            }
        }

        public void Insert(User user)
        {
            try
            {
                bTLContext.Users.Add(user);
                Save();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while inserting the user: {ex.Message}");
                throw;
            }
        }

        public void Save()
        {
            try
            {
                bTLContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while saving changes: {ex.Message}");
                throw;
            }
        }

        public void Update(string id, User user)
        {
            try
            {
                User oldUser = GetUser(id);
                if (oldUser != null)
                {
                    oldUser.UserId = user.UserId;
                    oldUser.UserName = user.UserName;
                    oldUser.Email = user.Email;
                    oldUser.Team = user.Team;

                    bTLContext.Users.Update(oldUser);
                    Save();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while updating the user: {ex.Message}");
                throw;
            }
        }
    }
}
