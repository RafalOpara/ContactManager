using Microsoft.EntityFrameworkCore;
using NetPc;

namespace NetPcProject
{
   

    public class ContactManager : IContactManager
    {
        private readonly IContactRepository mContactRepository;

        private readonly DtoMapper mDtoMapper;

        public ContactManager(IContactRepository contactRepository, DtoMapper mapper)
        {
            mContactRepository = contactRepository;
            mDtoMapper = mapper;
        }

        public List<ContactDto> GetAllContacts()
        {
            var contactEntitites = mContactRepository.GetAllContacts().ToList();

            return mDtoMapper.Map(contactEntitites);
        }

        public void AddNewContact(ContactDto contact)
        {
            var entity = mDtoMapper.Map(contact);

            mContactRepository.AddNew(entity);
        }

        public void DeleteContact(ContactDto contact)
        {
            var entity = mDtoMapper.Map(contact);

            mContactRepository.Delete(entity);
        }

        public void UpdateContact(ContactDto updatedContact)
        {
            var mappedDto = mDtoMapper.Map(updatedContact);

            mContactRepository.UpdateContact(mappedDto);
        }
    }
}
