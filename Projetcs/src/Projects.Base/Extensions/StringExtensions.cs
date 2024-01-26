using System.Security.Cryptography;
using System.Text;

namespace Projects.Base.Extensions
{
    public static class StringExtensions
    {
        //TODO: alterar esses métodos de encryp e descrypt para a correta

        private const string securityKey = "5CDBA63E-6487-4CF7-9DC7-250982171391";
        public static string Encrypt(this string text)
        {
            byte[] results;
            byte[] data = UTF8Encoding.UTF8.GetBytes(text);

            using (var sha256 = SHA256.Create())
            {
                byte[] keys = sha256.ComputeHash(UTF8Encoding.UTF8.GetBytes(securityKey));
                var tripDes = TripleDES.Create();
                tripDes.Key = keys;
                tripDes.Mode = CipherMode.ECB;
                tripDes.Padding = PaddingMode.PKCS7;

                ICryptoTransform transform = tripDes.CreateEncryptor();
                results = transform.TransformFinalBlock(data, 0, data.Length);
            }

            return Convert.ToBase64String(results, 0, results.Length);
        }


        public static string Decrypt(this string text)
        {
            try
            {
                byte[] results;
                byte[] data = Convert.FromBase64String(text);
                using (var sha256 = SHA256.Create())
                {
                    byte[] keys = sha256.ComputeHash(UTF8Encoding.UTF8.GetBytes(securityKey));
                    var tripDes = TripleDES.Create();
                    tripDes.Key = keys;
                    tripDes.Mode = CipherMode.ECB;
                    tripDes.Padding = PaddingMode.PKCS7;

                    ICryptoTransform transform = tripDes.CreateDecryptor();
                    results = transform.TransformFinalBlock(data, 0, data.Length);
                }
                return UTF8Encoding.UTF8.GetString(results);
            }
            catch
            {
                return "Security Key Is Invalid";
            }
        }
    }
}
