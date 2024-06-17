using NetPcProjectDataBase.Enitites;
using System.ComponentModel.DataAnnotations;

namespace NetPcProject.Models
{
    public class UserViewModel
    {
        public int Id { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [MinLength(6)]
        public string PasswrodHash { get; set; }

        [Required]
        public int RoleId { get; set; } = 1;




    }
}
