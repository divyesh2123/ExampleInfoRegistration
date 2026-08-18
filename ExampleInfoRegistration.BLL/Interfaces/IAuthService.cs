using ExampleInfoRegistration.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleInfoRegistration.BLL.Interfaces
{
    public interface IAuthService
    {
        bool Register(RegisterRequest request);
    }
}
