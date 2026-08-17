using ExampleInfoRegistration.DAL.Data;
using ExampleInfoRegistration.DAL.Interfaces;
using ExampleInfoRegistration.Entities;

namespace ExampleInfoRegistration.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }
        public bool CreateUserInfo(User user)
        {
            _context.Users.Add(user);

           return _context.SaveChanges() > 0 ? true : false;
        }
    }
}
