using System.Security.Cryptography;
using System.Text;
using System;

namespace HWInternshipProject.Models
{
    /// <summary>
    /// This code was stolen
    /// </summary>
    public static class RFCHasher
    {
        const int SaltSize = 16, HashSize = 20, HashIter = 10000;

        public static string GetHash(string password)
        {
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[SaltSize]);
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, HashIter);
            byte[] hash = pbkdf2.GetBytes(HashSize);
            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, SaltSize);
            Array.Copy(hash, 0, hashBytes, SaltSize, HashSize);
            return Convert.ToBase64String(hashBytes);

        }

        public static bool Verify(string entry_password, string saved_hash)
        {
            try
            {
                byte[] hashBytes = Convert.FromBase64String(saved_hash);
                byte[] salt = new byte[SaltSize];
                Array.Copy(hashBytes, 0, salt, 0, SaltSize);
                var pbkdf2 = new Rfc2898DeriveBytes(entry_password, salt, HashIter);
                byte[] hash = pbkdf2.GetBytes(HashSize);

                for (int i = 0; i < HashSize; i++)
                    if (hashBytes[i + SaltSize] != hash[i])
                        return false;
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
