using System;
using System.Security.Cryptography;
using System.Text;

namespace Lab07
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("1, 2 - Шифрование с использованием библиотеки");
            Console.Write("Введите номер: ");
            int p = Convert.ToInt32(Console.ReadLine());
            switch (p)
            {
                case 1:
                    {
                        try
                        {
                            RSA gen = new RSA();
                            //Создайте UnicodeEncoder для преобразования между массивом байтов и строкой.
                            UnicodeEncoding ByteConverter = new UnicodeEncoding();

                            //Создавайте массивы байтов для хранения исходных, зашифрованных и расшифрованных данных..
                            Console.Write("Введите текст: ");
                            string text = Console.ReadLine();
                            byte[] dataToEncrypt = ByteConverter.GetBytes(text);
                            byte[] encryptedData;
                            byte[] decryptedData;

                            //Создаётся новый экземпляр RSACryptoServiceProvider для создания
                            //данных открытого и закрытого ключей.
                            using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                            {

                                //Передайте данные в ENCRYPT, информацию об открытом ключе. 
                                //(с использованием RSACryptoServiceProvider.ExportParameters(false),
                                //а также логический флаг, указывающий отсутствие заполнения OAEP
                                encryptedData = gen.RSAEncrypt(dataToEncrypt, RSA.ExportParameters(false), false);

                                //Передайте данные в DECRYPT, информацию о секретном ключе 
                                //(с использованием RSACryptoServiceProvider.ExportParameters(true),
                                //а также логический флаг, указывающий отсутствие заполнения OAEP.
                                decryptedData = gen.RSADecrypt(encryptedData, RSA.ExportParameters(true), false);

                                Console.WriteLine("Зашифрованный текст: {0}", ByteConverter.GetString(encryptedData));
                                Console.WriteLine("Расшифрованный текст: {0}", ByteConverter.GetString(decryptedData));
                            }
                        }
                        catch (ArgumentNullException)
                        {
                            Console.WriteLine("Ошибка шифрования.");
                        }
                        break;
                    }
                case 2:
                {
                        RSA2 gen = new RSA2();
                        Console.Write("Текст для шифрования: ");
                        string message = Console.ReadLine();
                        Console.WriteLine();
                        Console.Write("Размер ключей: ");
                        int Key_size = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine();
                        gen.GenerateKeys(Key_size);
                        byte[] encrypted = gen.Encrypt(Encoding.UTF8.GetBytes(message), Key_size);
                        byte[] decrypted = gen.Decrypt(encrypted, Key_size);
                        Console.WriteLine("Зашифрованный текст:\n{0}\n", BitConverter.ToString(encrypted).Replace("-",""));
                        Console.WriteLine("Расшифрованный текст:\n{0}\n", Encoding.UTF8.GetString(decrypted));
                        Console.ReadKey();
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Exit...");
                        break;
                    }
            }

        }


    }
}
