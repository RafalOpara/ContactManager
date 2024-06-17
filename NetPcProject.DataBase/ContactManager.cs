using Microsoft.EntityFrameworkCore;
using NetPc;
using NetPcProjectDataBase.Repositories.Interfaces;

namespace NetPcProject
{
   

    public class ContactManager : IContactManager
    {
        private readonly IContactRepository mContactRepository;
        private readonly IContactCategoryRepository mContactCatRepository;

        private readonly DtoMapper mDtoMapper;

        public ContactManager(IContactRepository contactRepository, IContactCategoryRepository contactCategoryRepository, DtoMapper mapper)
        {
            mContactRepository = contactRepository;
            mContactCatRepository = contactCategoryRepository;
            mDtoMapper = mapper;
        }


        public List<ContactCategoryDto> GetAllContactsCategory()
        {
            var contactEntitites = mContactCatRepository.GetAllContactCategory().ToList();

            return mDtoMapper.Map(contactEntitites);
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

        ////////
    }
}
