using NetPcProjectDataBase.Enitites;

namespace NetPcProjectDataBase.Repositories.Interfaces
{
    public interface IContactCategoryRepository
    {
 
        IEnumerable<ContactCategory> GetAllContactCategory();
    }
}