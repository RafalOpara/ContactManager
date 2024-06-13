using NetPc;

namespace NetPcProject
{
    public interface IContactManager
    {
        void AddNewContact(ContactDto contact);
        void DeleteContact(ContactDto contact);
        List<ContactDto> GetAllContacts();
        void UpdateContact(ContactDto updatedContact);
    }
}
