using NetPc;
using NetPcProject.Core.Interfacess;
using NetPcProjectDataBase.Repositories.Interfaces;

namespace NetPcProject
{
    public class UserManager : IUserManager
    {
        private readonly IRoleRepository mRoleRepository;
        private readonly IUserRepository mUserRepository;


        private readonly DtoMapper mDtoMapper;

        public UserManager(IRoleRepository roleRepository, IUserRepository userRepository, DtoMapper mapper)
        {
            mRoleRepository = roleRepository;
            mUserRepository = userRepository;
            mDtoMapper = mapper;
        }

        public List<RoleDto> GetAllCategory()
        {
            var temp = mRoleRepository.GetAllRoles().ToList();

            return mDtoMapper.Map(temp);
        }

        public List<UserDto> GetAllUsers()
        {
            var temp = mUserRepository.GetAllUsers().ToList();

            return mDtoMapper.Map(temp);
        }



        public void AddNewUser(UserDto user)
        {
            var entity = mDtoMapper.Map(user);

            mUserRepository.AddNew(entity);
        }

        public void DeleteContact(UserDto user)
        {
            var entity = mDtoMapper.Map(user);

            mUserRepository.Delete(entity);
        }


    }
}
