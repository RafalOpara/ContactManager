using NetPcProjectDataBase.Enitites;
using System.Security.Claims;

namespace NetPcProjectDataBase.Repositories.Interfaces
{
    public interface IUserRepository
    {
        void AddNew(User user);
        void Delete(User user);
        IEnumerable<User> GetAllUsers();
        bool CheckPassword(User user);

      


    }
}