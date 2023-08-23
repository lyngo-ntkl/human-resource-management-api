using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Common
{
    public sealed class EncryptionUtils
    {
        public static void encrypt(string data, out byte[] key, out byte[] hash)
        {
            var hmac = new HMACSHA512();
            key = hmac.Key;
            hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(data));
        }

        public static byte[] encrypt(string data, byte[] key)
        {
            var hmac = new HMACSHA512(key);
            var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(data));
            return hash;
        }
    }
}
