namespace NetPc
{


    public class ContactRepository : IContactRepository
    {
        private readonly NetPcDbContext _context;

        public ContactRepository(NetPcDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Contact> GetAllContacts()
        {

            return _context.Contacts.Select(x => x);
        }



        public void AddNew(Contact contact)
        {
            _context.Contacts.Add(contact);
            _context.SaveChanges();
        }



        public void Delete(Contact contact)
        {
            _context.Contacts.Remove(contact);
            _context.SaveChanges();

        }

        public void UpdateContact(Contact updatedContact)
        {
            var existingContact = _context.Contacts.FirstOrDefault(c => c.Id == updatedContact.Id);


            if (existingContact != null)
            {
                existingContact.Name = updatedContact.Name;
                existingContact.LastName = updatedContact.LastName;
                existingContact.Email = updatedContact.Email;
                existingContact.Password = updatedContact.Password;
                existingContact.Category = updatedContact.Category;
                existingContact.PhoneNumber = updatedContact.PhoneNumber;

                _context.SaveChanges();
            }
        }
    }
}
