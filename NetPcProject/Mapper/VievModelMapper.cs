using AutoMapper;
using NetPcProject.Models;

namespace NetPc
{
    public class ViewModelMapper
    {
        private IMapper mMapper;

        public ViewModelMapper()
        {
            mMapper = new MapperConfiguration(config =>
            {
                config.CreateMap<ContactDto, ContactViewModel>().ReverseMap();
                config.CreateMap<ContactCategoryDto, ContactCategoryViewModel>().ReverseMap();
                config.CreateMap<RoleDto, RoleViewModel>().ReverseMap();
                config.CreateMap<UserDto, UserViewModel>().ReverseMap();
            }).CreateMapper();
        }

        #region Contact maps

        public ContactViewModel Map(ContactDto contact)
            => mMapper.Map<ContactViewModel>(contact);

        public List<ContactViewModel> Map(List<ContactDto> contact)
            => mMapper.Map<List<ContactViewModel>>(contact);

        public ContactDto Map(ContactViewModel contact)
            => mMapper.Map<ContactDto>(contact);

        public List<ContactDto> Map(List<ContactViewModel> contact)
            => mMapper.Map<List<ContactDto>>(contact);

        #endregion

        #region ContactCategory maps

        public ContactCategoryViewModel Map(ContactCategoryDto contactCategory)
            => mMapper.Map<ContactCategoryViewModel>(contactCategory);

        public List<ContactCategoryViewModel> Map(List<ContactCategoryDto> contactCategory)
            => mMapper.Map<List<ContactCategoryViewModel>>(contactCategory);

        public ContactCategoryDto Map(ContactCategoryViewModel contactCategory)
            => mMapper.Map<ContactCategoryDto>(contactCategory);

        public List<ContactCategoryDto> Map(List<ContactCategoryViewModel> contactCategory)
            => mMapper.Map<List<ContactCategoryDto>>(contactCategory);

        #endregion

        #region Role maps

        public RoleViewModel Map(RoleDto role)
            => mMapper.Map<RoleViewModel>(role);

        public List<RoleViewModel> Map(List<RoleDto> role)
            => mMapper.Map<List<RoleViewModel>>(role);

        public RoleDto Map(RoleViewModel role)
            => mMapper.Map<RoleDto>(role);

        public List<RoleDto> Map(List<RoleViewModel> role)
            => mMapper.Map<List<RoleDto>>(role);

        #endregion

        #region User maps

        public UserViewModel Map(UserDto user)
            => mMapper.Map<UserViewModel>(user);

        public List<UserViewModel> Map(List<UserDto> user)
            => mMapper.Map<List<UserViewModel>>(user);

        public UserDto Map(UserViewModel user)
            => mMapper.Map<UserDto>(user);

        public List<UserDto> Map(List<UserViewModel> user)
            => mMapper.Map<List<UserDto>>(user);

        #endregion
    }

   
}
