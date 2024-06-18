using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NetPcProjectDataBase.Enitites;
using NetPcProjectDataBase.Repositories.Interfaces;
using System.Security.Claims;

namespace NetPc
{


    public class UserRepository : IUserRepository
    {
        private readonly NetPcDbContext _context;
        private readonly IPasswordHasher<User> _passwordHasher;
       


        public UserRepository(NetPcDbContext context, IPasswordHasher<User> passwordHasher)
        {
            _context = context;
            _passwordHasher= passwordHasher;
        }

        public IEnumerable<User> GetAllUsers()
        {

            return _context.Users.Select(x => x);
        }



        public void AddNew(User user)
        {
            user.PasswrodHash = _passwordHasher.HashPassword(user, user.PasswrodHash);
            _context.Users.Add(user);
            _context.SaveChanges();
        }



        public void Delete(User user)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();

        }

        public bool CheckPassword(User user)
        {
            var tempUser = GetAllUsers().Where(x => x.Email == user.Email).FirstOrDefault();

            Console.WriteLine(tempUser.PasswrodHash);
            Console.WriteLine(user.PasswrodHash);

            var result = _passwordHasher.VerifyHashedPassword(tempUser, tempUser.PasswrodHash, user.PasswrodHash);

            if (result == PasswordVerificationResult.Failed)
            {
                return (false);
            }
            else
            {
                
                return true;
            }

            
        }

        public IQueryable<User> GetAllUsersWithRoles()
        {
            return _context.Users.Include(u => u.Role);
        }


    }
}
