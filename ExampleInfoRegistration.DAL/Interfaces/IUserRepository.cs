using ExampleInfoRegistration.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleInfoRegistration.DAL.Interfaces
{
    public interface IUserRepository
    {
        bool CreateUserInfo(User user);

        bool IsEmailAlreadyExisiting(string email); 
    }
}
