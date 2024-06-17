using NetPcProjectDataBase.Enitites;
using NetPcProjectDataBase.Repositories.Interfaces;

namespace NetPc
{


    public class RoleRepository : IRoleRepository
    {
        private readonly NetPcDbContext _context;

        public RoleRepository(NetPcDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Role> GetAllRoles()
        {

            return _context.Roles.Select(x => x);
        }


    }
}
