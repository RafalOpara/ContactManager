using Microsoft.AspNetCore.Identity;
using NetPc;
using NetPcProject.Core.Interfacess;
using NetPcProjectDataBase.Enitites;
using NetPcProjectDataBase.Repositories.Interfaces;
using System.Security.Claims;

namespace NetPcProject
{
    public class UserManager : IUserManager
    {
        private readonly IRoleRepository mRoleRepository;
        private readonly IUserRepository mUserRepository;
        private readonly IPasswordHasher<User> mPasswordHasher;



        private readonly DtoMapper mDtoMapper;

        public UserManager(IRoleRepository roleRepository, IUserRepository userRepository, DtoMapper mapper, IPasswordHasher<User> passwordHasher)
        {
            mRoleRepository = roleRepository;
            mUserRepository = userRepository;
            mDtoMapper = mapper;
            mPasswordHasher = passwordHasher;
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

        public bool CheckPassword(UserDto user)
        {
            var entity = mDtoMapper.Map(user);

            var checkedPassword = mUserRepository.CheckPassword(entity);

            return (checkedPassword);
        }

     

        
    }
}
