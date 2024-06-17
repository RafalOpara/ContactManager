using NetPcProjectDataBase.Enitites;

namespace NetPcProjectDataBase.Repositories.Interfaces
{
    public interface IRoleRepository
    {
        IEnumerable<Role> GetAllRoles();
    }
}