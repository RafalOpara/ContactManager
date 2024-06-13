using NetPcProjectDataBase.Enitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetPcProject.Core.ContactCat
{
    public interface IContactCategoryService
    {

        IEnumerable<ContactCategory> GetAllCategories();
        ContactCategory GetCategoryById(int categoryId);
        void AddCategory(ContactCategory category);
        void UpdateCategory(ContactCategory category);
        void DeleteCategory(int categoryId);
    }
}
