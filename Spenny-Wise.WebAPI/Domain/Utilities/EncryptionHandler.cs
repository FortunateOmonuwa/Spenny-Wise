using System.Security.Cryptography;
using System.Text;

namespace Spenny_Wise.WebAPI.Domain.Utilities
{
    public static class EncryptionHandler
    {
        public static void EncryptPassword(string password, out byte[] passwordHash , out byte[] passwordSalt)
        {
            using var hmac = new HMACSHA512();
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        }


        public static bool VerifyPassword(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using var hmac = new HMACSHA512(passwordSalt);
            var genHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            var res = genHash.SequenceEqual(passwordHash);
            return res;
        }
    }
}
