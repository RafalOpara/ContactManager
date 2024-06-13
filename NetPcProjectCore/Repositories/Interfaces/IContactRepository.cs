namespace NetPc
{
        public interface IContactRepository
        {
            void AddNew(Contact contact);
            void Delete(Contact contact);
            IEnumerable<Contact> GetAllContacts();
            void UpdateContact(Contact contact);

      
        }
    
}
