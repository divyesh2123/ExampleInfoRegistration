using ExampleInfoRegistration.BLL.Interfaces;
using ExampleInfoRegistration.DAL.Interfaces;
using ExampleInfoRegistration.Entities;
using ExampleInfoRegistration.Entities.DTOs;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleInfoRegistration.BLL.Services
{
    public class AuthService : IAuthService
    {

        private readonly IUserRepository _userRepository;
        private readonly PasswordService _passwordService;

        public AuthService(
      IUserRepository userRepository,
      PasswordService passwordService
     )
        {
            _userRepository = userRepository;
            _passwordService = passwordService;
        }
        public bool Register(RegisterRequest request)
        {
            var email = request.Email
            .Trim()
            .ToLowerInvariant();

            // Check duplicate email
            var existingUser =
                 _userRepository.IsEmailAlreadyExisiting(email);

            if (existingUser== true)
            {
                throw new InvalidOperationException(
                    "Email is already registered.");
            }

            // Create User
            var user = new User
            {
                FirstName = request.FirstName.Trim(),

                LastName = request.LastName.Trim(),

                Email = email,

                CreatedDate = DateTime.UtcNow
            };

            var data = _passwordService.HashPassword(request.Password);


            user.PasswordHash = data.Hash;
            user.PasswordSalt = data.Salt;
            var createdUser =
            _userRepository.CreateUserInfo(user);

            return createdUser;

        }
    }
}
