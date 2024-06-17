using NetPcProjectDataBase.Enitites;
using NetPcProjectDataBase.Repositories.Interfaces;

namespace NetPc
{


    public class ContactCategoryRepository : IContactCategoryRepository
    {
        private readonly NetPcDbContext _context;

        public ContactCategoryRepository(NetPcDbContext context)
        {
            _context = context;
        }

        public IEnumerable<ContactCategory> GetAllContactCategory()
        {

            return _context.ContactCategory.Select(x => x);
        }



    }
}
