using NetPc;

namespace NetPcProject.Core.Interfacess
{
    public interface IUserManager
    {
        void AddNewUser(UserDto user);
        void DeleteContact(UserDto user);
        List<RoleDto> GetAllCategory();
        List<UserDto> GetAllUsers();
    }
}