using Microsoft.AspNetCore.Identity;
using NetPcProjectDataBase.Enitites;
using NetPcProjectDataBase.Repositories.Interfaces;

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


    }
}
