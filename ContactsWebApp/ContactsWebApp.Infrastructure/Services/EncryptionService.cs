using System.Security.Cryptography;
using System.Text;

namespace ContactsWebApp.Infrastructure.Services
{
    public class AesEncryptionService : IEncryptionService
    {
        private readonly string encryptionKey = "randomSecureKey"; //Should be stored securely in real application(vault)

        public string Encrypt(string plainText)
        {
            if (string.IsNullOrEmpty(plainText)) return plainText;

            using Aes aes = Aes.Create();
            byte[] keyBytes = Encoding.UTF8.GetBytes(encryptionKey);
            Array.Resize(ref keyBytes, 32);

            aes.Key = keyBytes;
            aes.GenerateIV();
            byte[] iv = aes.IV;

            using var encryptor = aes.CreateEncryptor();
            byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);
            byte[] encryptedBytes = encryptor.TransformFinalBlock(plainBytes, 0, plainBytes.Length);

            byte[] combinedData = new byte[iv.Length + encryptedBytes.Length];
            Array.Copy(iv, 0, combinedData, 0, iv.Length);
            Array.Copy(encryptedBytes, 0, combinedData, iv.Length, encryptedBytes.Length);

            return Convert.ToBase64String(combinedData);
        }

        public string Decrypt(string encryptedText)
        {
            if (string.IsNullOrEmpty(encryptedText)) return encryptedText;

            byte[] combinedData = Convert.FromBase64String(encryptedText);

            using Aes aes = Aes.Create();
            byte[] keyBytes = Encoding.UTF8.GetBytes(encryptionKey);
            Array.Resize(ref keyBytes, 32);

            aes.Key = keyBytes;

            byte[] iv = new byte[aes.BlockSize / 8];
            byte[] encryptedBytes = new byte[combinedData.Length - iv.Length];

            Array.Copy(combinedData, 0, iv, 0, iv.Length);
            Array.Copy(combinedData, iv.Length, encryptedBytes, 0, encryptedBytes.Length);

            aes.IV = iv;

            using var decryptor = aes.CreateDecryptor();
            byte[] decryptedBytes = decryptor.TransformFinalBlock(encryptedBytes, 0, encryptedBytes.Length);

            return Encoding.UTF8.GetString(decryptedBytes);
        }
    }
}
