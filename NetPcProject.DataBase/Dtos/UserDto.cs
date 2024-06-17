using NetPcProjectDataBase.Enitites;

namespace NetPc
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string PasswrodHash { get; set; }


        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
    }
}
