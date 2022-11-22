using System.Security.Cryptography;
using System;

namespace Lab07
{
    public class RSA
    {
        public byte[] RSAEncrypt(byte[] DataToEncrypt, RSAParameters RSAKeyInfo, bool DoOAEPPadding)
        {
            try
            {
                byte[] encryptedData;
                //Создайте новый экземпляр RSACryptoServiceProvider..
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {

                    //Импортируйте информацию о ключе RSA. Это нужно только
                    //включить информацию об открытом ключе.
                    RSA.ImportParameters(RSAKeyInfo);

                    //Зашифруйте переданный массив байтов и укажите заполнение OAEP (Оптимальное асимметричное шифрование с дополнением).
                    encryptedData = RSA.Encrypt(DataToEncrypt, DoOAEPPadding);
                }
                return encryptedData;
            }
            catch (CryptographicException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public byte[] RSADecrypt(byte[] DataToDecrypt, RSAParameters RSAKeyInfo, bool DoOAEPPadding)
        {
            try
            {
                byte[] decryptedData;
                //Создайте новый экземпляр RSACryptoServiceProvider.
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {
                    //Импортируйте информацию о ключе RSA. Это нужно
                    //для того что бы включить информацию о закрытом ключе.
                    RSA.ImportParameters(RSAKeyInfo);

                    //Расшифровать переданный массив байтов и указать заполнение OAEP.  
                    decryptedData = RSA.Decrypt(DataToDecrypt, DoOAEPPadding);
                }
                return decryptedData;
            }
            catch (CryptographicException e)
            {
                Console.WriteLine(e.ToString());

                return null;
            }
        }
    }
}