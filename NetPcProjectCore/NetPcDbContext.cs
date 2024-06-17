using Microsoft.EntityFrameworkCore;
using NetPcProjectDataBase.Enitites;

namespace NetPc
{
    public class NetPcDbContext : DbContext
    {

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ContactCategory> ContactCategory { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        

        public NetPcDbContext(DbContextOptions options) : base(options)
        {

        }

    }
}
