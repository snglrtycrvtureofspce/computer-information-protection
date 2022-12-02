using System;
using System.CodeDom;
using System.IO;
using static System.Net.Mime.MediaTypeNames;

namespace Part01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StreamReader read = new StreamReader("C:\\Users\\snglrtycrvtureofspce\\Desktop\\Protection-of-computer-information-main\\ЛР05\\pass\\Part01\\Code.txt");
            string text = read.ReadToEnd();
            read.Close();
            text = text.ToUpper();
            Console.WriteLine($"Ваш введенный текст в текстовый файл\n{text}");
            StreamReader readCode = new StreamReader("C:\\Users\\snglrtycrvtureofspce\\Desktop\\Protection-of-computer-information-main\\ЛР05\\pass\\Part01\\Pass.txt");
            string code = readCode.ReadToEnd();
            readCode.Close();
            code = code.ToUpper();
            Console.WriteLine($"Ваш введенный шифр в текстовый файл\n{code}");
            string[] binary = new string[text.Length];//двоичный код
            binary = codeBi(text);
            int[] de = new int[text.Length];//десятичный код
            de = codeDe(binary);
            string[] binary2 = new string[code.Length];//двоичный код для шифра 
            binary2 = codeBi(code);
            int[] de2 = new int[code.Length];//десятичный код для шифра 
            de2 = codeDe(binary2);
            Console.WriteLine($"Шифр для слова {text}");
            PrintS(binary);
            PrintI(de);
            Console.WriteLine($"Шифр для слова {code}");
            PrintS(binary2);
            PrintI(de2);
            int[] last = new int[de.Length];
            last = xor(de, de2);
            Console.Write("Результат: ");
            PrintI(last);
            Console.ReadKey();
        }
        static public string[] codeBi(string text)
        {
            int index = 0;
            string[,] code = {  { "A", "B", "C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z"},
                                { "01000001","01000010","01000011","01000100","01000101","01000110","01000111","01001000","01001001","01001010","01001011","01001100","01001101","01001110","01001111","01010000","01010001","01010010","01010011","01010100","01010101","01010110","01010111","01011000","01011001","01011010"} };
            string[] binary = new string[text.Length];
            int[] de = new int[text.Length];
            for (int i = 0; i < text.Length; i++)
            {
                for (int j = 0; j < code.Length; j++)
                {
                    if (Convert.ToString(text[i]) == code[0, j])
                    {
                        index = j;
                        break;
                    }
                }
                binary[i] = code[1, index];

            }
            return binary;
        }
        static int[] codeDe(string[] binary)
        {
            int[] de = new int[binary.Length];
            for (int i = 0; i < binary.Length; i++)
            {
                de[i] = Convert.ToInt32(binary[i], 2);
            }
            return de;
        }
        static void PrintS(string[] array)
        {
            for(int i = 0; i <array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.Write("\n");
        }
        static void PrintI(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.Write("\n");
        }
        static int[] xor(int[] de, int[] de2)
        {
            int[] last = new int[de.Length];
            for(int i = 0; i < de.Length; i++)
            {
                last[i] = de[i] ^ de2[i];
            }
            return last;
        }
    }
}
