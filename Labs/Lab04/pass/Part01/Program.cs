using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[,] mas = new char[32, 32];
            char[] letter = { 'а', 'б', 'в', 'г', 'д', 'е', 'ж', 'з', 'и', 'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я' };
            char[] shifr = { 'а', 'б', 'в', 'г', 'д', 'е', 'ж', 'з', 'и', 'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я' };
            for (int i = 0; i < 32; i++)
            {
                for (int j = 0; j < 32; j++)
                {
                    mas[i, j] = shifr[j];
                }
                for (int j = 0; j < 1; j++)
                {
                    char tmp = ' ';
                    for (int w = 0; w < shifr.Length; w++)
                    {
                        if (w == 0)
                        {
                            tmp = shifr[0];
                            continue;
                        }
                        char first = shifr[w];
                        shifr[w - 1] = first;
                        if (w == shifr.Length - 1)
                        {
                            shifr[w] = tmp;
                            continue;
                        }
                    }
                }
            }
            for (int i = 0; i < 32; i ++)
            {
                for(int j = 0; j < 32; j++)
                {
                    Console.Write(mas[i, j] + " ");
                }
                Console.Write("\n");
            }
            Console.WriteLine("Введите предложение которое хотите зашифровать");
            string text = Console.ReadLine();
            Console.WriteLine("Введите ключ слово");
            string slovo = Console.ReadLine();
            string textslovo = "";
            text = text.Replace(" ", "");
            int division = text.Length / slovo.Length;
            for (int i = 0; i < division + 1; i++)
            {
                textslovo += slovo;
            }
            textslovo = textslovo.Remove(text.Length);
            slovo = textslovo;
            int numT = 0;
            int numS = 0;
            int num = 0;
            string pass = "";
            for (int i = 0; i < text.Length; i++)
            {
                for (int j = 0; j < letter.Length; j++)
                {
                    if (text[i] == letter[j])
                    {
                        numT = j + 1;
                        if (num < slovo.Length)
                        {
                            for (int q = 0; q < letter.Length; q++)
                            {
                                if (slovo[num] == letter[q])
                                {
                                    pass += mas[q, j];
                                    numS = q + 1;
                                }
                            }
                            num++;
                        }
                        if (num == slovo.Length) num = 0;
                    }
                }
            }
            Console.WriteLine($"ключи слова: {slovo}");
            Console.WriteLine($"шифрованный текст: {pass}");
            Console.ReadKey();
            Console.ReadKey();
        }
    }
}
