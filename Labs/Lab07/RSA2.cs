using System.Security.Cryptography;
using System;

namespace Lab07
{
    public class RSA2
    {
        private static byte[] publicKey;
        private static byte[] privateKey;
        public void GenerateKeys(int Key_size)
        {
            using (var rsa = new RSACryptoServiceProvider(Key_size))
            {
                rsa.PersistKeyInCsp = false;
                publicKey = rsa.ExportCspBlob(false);
                privateKey = rsa.ExportCspBlob(true);
                string PrivateKey = Convert.ToBase64String(privateKey);
                string PublicKey = Convert.ToBase64String(publicKey);
                Console.WriteLine("Открытый ключ:\n{0}\n", PrivateKey);
                Console.WriteLine("Закрытый ключ:\n{0}\n", PublicKey);
            }
        } 
        public byte[] Encrypt(byte[] input, int Key_size)
        {
            byte[] encrypted;
            using (var rsa = new RSACryptoServiceProvider(Key_size))
            {
                rsa.PersistKeyInCsp = false;
                rsa.ImportCspBlob(publicKey);
                encrypted = rsa.Encrypt(input, true);
            }
            return encrypted;
        }
        public byte[] Decrypt(byte[] input, int Key_size)
        {
            byte[] decrypted;
            using (var rsa = new RSACryptoServiceProvider(Key_size))
            {
                rsa.PersistKeyInCsp = false;
                rsa.ImportCspBlob(privateKey);
                decrypted = rsa.Decrypt(input, true);
            }
            return decrypted;
        }
    }
}