using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace Cryptocop.Software.API.Repositories.Helpers
{
    public static class HashingHelper
    {
        private static string _salt = "<insert-some-salt-here>";
        public static string HashPassword(string password)
        {
            return Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: CreateSalt(),
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));
        }
        private static byte[] CreateSalt() =>
            Convert.FromBase64String(Convert.ToBase64String(Encoding.UTF8.GetBytes(_salt)));
    }
}
