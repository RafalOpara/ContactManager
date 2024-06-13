// ContactCategoryService.cs
using NetPc;
using NetPcProject.Core.ContactCat;
using NetPcProjectDataBase.Enitites;

namespace YourAppName.Core.Services
{
    public class ContactCategoryService : IContactCategoryService
    {
        private readonly NetPcDbContext _context;

        public ContactCategoryService(NetPcDbContext context)
        {
            _context = context;
        }

        public IEnumerable<ContactCategory> GetAllCategories()
        {
            return _context.ContactCategory.ToList();
        }

        public ContactCategory GetCategoryById(int categoryId)
        {
            return _context.ContactCategory.FirstOrDefault(c => c.Id == categoryId);
        }

        public void AddCategory(ContactCategory category)
        {
            _context.ContactCategory.Add(category);
            _context.SaveChanges();
        }

        public void UpdateCategory(ContactCategory category)
        {
            _context.ContactCategory.Update(category);
            _context.SaveChanges();
        }

        public void DeleteCategory(int categoryId)
        {
            var categoryToDelete = _context.ContactCategory.Find(categoryId);
            if (categoryToDelete != null)
            {
                _context.ContactCategory.Remove(categoryToDelete);
                _context.SaveChanges();
            }
        }


    }
}
