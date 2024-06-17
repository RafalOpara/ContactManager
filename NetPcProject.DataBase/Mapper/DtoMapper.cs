using AutoMapper;
using NetPcProjectDataBase.Enitites;

namespace NetPc
{
    public class DtoMapper
    {
        private IMapper mMapper;

        public DtoMapper()
        {
            mMapper = new MapperConfiguration(config =>
            {
                config.CreateMap<Contact, ContactDto>().ReverseMap();
                config.CreateMap<ContactCategory, ContactCategoryDto>().ReverseMap();
                config.CreateMap<Role, RoleDto>().ReverseMap();
                config.CreateMap<User, UserDto>().ReverseMap();
            }).CreateMapper();
        }

        #region Contact Maps

        public ContactDto Map(Contact contact)
            => mMapper.Map<ContactDto>(contact);

        public List<ContactDto> Map(List<Contact> contact)
            => mMapper.Map<List<ContactDto>>(contact);

        public Contact Map(ContactDto contact)
            => mMapper.Map<Contact>(contact);

        public List<Contact> Map(List<ContactDto> contact)
            => mMapper.Map<List<Contact>>(contact);

        #endregion

        #region ContactCategory Maps

        public ContactCategoryDto Map(ContactCategory contactCategory)
            => mMapper.Map<ContactCategoryDto>(contactCategory);

        public List<ContactCategoryDto> Map(List<ContactCategory> contactCategory)
            => mMapper.Map<List<ContactCategoryDto>>(contactCategory);

        public ContactCategory Map(ContactCategoryDto contactCategory)
            => mMapper.Map<ContactCategory>(contactCategory);

        public List<ContactCategory> Map(List<ContactCategoryDto> contactCategory)
            => mMapper.Map<List<ContactCategory>>(contactCategory);

        #endregion

        #region Role Maps

        public RoleDto Map(Role role)
            => mMapper.Map<RoleDto>(role);

        public List<RoleDto> Map(List<Role> role)
            => mMapper.Map<List<RoleDto>>(role);

        public Role Map(RoleDto role)
            => mMapper.Map<Role>(role);

        public List<Role> Map(List<RoleDto> role)
            => mMapper.Map<List<Role>>(role);

        #endregion

        #region User Maps

        public UserDto Map(User user)
            => mMapper.Map<UserDto>(user);

        public List<UserDto> Map(List<User> user)
            => mMapper.Map<List<UserDto>>(user);

        public User Map(UserDto user)
            => mMapper.Map<User>(user);

        public List<User> Map(List<UserDto> user)
            => mMapper.Map<List<User>>(user);

        #endregion
    }

  
}
