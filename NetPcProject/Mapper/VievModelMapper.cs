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

                config.CreateMap<ContactDto, ContactViewModel>()
                .ReverseMap();

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

    }
}
