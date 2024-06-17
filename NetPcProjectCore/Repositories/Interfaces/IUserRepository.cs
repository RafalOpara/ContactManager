using NetPcProjectDataBase.Enitites;

namespace NetPcProjectDataBase.Repositories.Interfaces
{
    public interface IUserRepository
    {
        void AddNew(User user);
        void Delete(User user);
        IEnumerable<User> GetAllUsers();
    }
}