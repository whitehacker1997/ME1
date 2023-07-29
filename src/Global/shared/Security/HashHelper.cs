using System.Security.Cryptography;
using System.Text;

namespace Global.Security
{
    public static class HashHelper
    {
        public static string CreateRandomSalt()
        {
            byte[] array = new byte[4];

            RandomNumberGenerator.Create()
                                    .GetBytes(array);

            return Convert.ToBase64String(array);
        }

        public static string ComputeSaltedHash(string password,
                                               string salt)
        {
            byte[] bytes = new UnicodeEncoding().GetBytes(password);
            byte[] array = Convert.FromBase64String(salt);
            byte[] array2 = new byte[bytes.Length + array.Length];

            Array.Copy(bytes, 0, array2, 0, bytes.Length);
            Array.Copy(array, 0, array2, bytes.Length, array.Length);
            
            return Convert.ToBase64String(SHA512.Create().ComputeHash(array2));
        }

    }
}
