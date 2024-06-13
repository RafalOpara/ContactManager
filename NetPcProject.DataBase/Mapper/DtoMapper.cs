using AutoMapper;

namespace NetPc
{
    public class DtoMapper
    {
        private IMapper mMapper;

        public DtoMapper()
        {
            mMapper = new MapperConfiguration(config=>
            {
                config.CreateMap<Contact, ContactDto>()
                    .ReverseMap();
                
            }).CreateMapper();
        }

        #region Doctor Maps

        public ContactDto Map(Contact contact)
           => mMapper.Map<ContactDto>(contact);

        public List<ContactDto> Map(List<Contact> contact)
            => mMapper.Map<List<ContactDto>>(contact);

        public Contact Map(ContactDto contact)
           => mMapper.Map<Contact>(contact);

        public List<Contact> Map(List<ContactDto> contact)
            => mMapper.Map<List<Contact>>(contact);



        #endregion

       
    }


}

