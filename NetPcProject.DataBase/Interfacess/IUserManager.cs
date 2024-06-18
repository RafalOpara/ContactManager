using NetPc;
using System.Security.Claims;

namespace NetPcProject.Core.Interfacess
{
    public interface IUserManager
    {
        void AddNewUser(UserDto user);
        void DeleteContact(UserDto user);
        List<RoleDto> GetAllCategory();
        List<UserDto> GetAllUsers();
        bool CheckPassword(UserDto user);

      


    }
}