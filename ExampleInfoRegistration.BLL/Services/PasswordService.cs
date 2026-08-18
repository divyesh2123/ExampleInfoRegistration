using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ExampleInfoRegistration.BLL.Services
{
    public class PasswordService
    {
        public (string Hash, string Salt) HashPassword(string password)
        {
            byte[] salt = RandomNumberGenerator.GetBytes(32);

            byte[] hash = Rfc2898DeriveBytes.Pbkdf2(
                password,
                salt,
                600_000,
                HashAlgorithmName.SHA512,
                64);

            return (
                Convert.ToBase64String(hash),
                Convert.ToBase64String(salt)
            );
        }

        public bool VerifyPassword(
     string password,
     string storedHash,
     string storedSalt)
        {
            byte[] salt =
                Convert.FromBase64String(storedSalt);

            byte[] expectedHash =
                Convert.FromBase64String(storedHash);

            byte[] actualHash = Rfc2898DeriveBytes.Pbkdf2(
                password,
                salt,
                600_000,
                HashAlgorithmName.SHA512,
                64);

            return CryptographicOperations.FixedTimeEquals(
                actualHash,
                expectedHash);
        }

    }
}
