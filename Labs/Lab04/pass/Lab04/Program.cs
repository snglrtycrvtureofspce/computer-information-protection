using System;

namespace Lab04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите номер: ");
            int pp = Convert.ToInt32(Console.ReadLine());
            switch (pp)
            {
                case 1:
                    {
                        char[,] mas =  {
                            { 'ж', 'щ', 'н', 'ю', 'р' },//{ 'и', 'ч', 'г', 'я', 'т' },
                            { 'и', 'т', 'ь', 'ц', 'б' },//{ ',', 'ж', 'ь', 'м', 'о' },
                            { 'я', 'м', 'е', '.', 'с' },//{ 'з', 'ю', 'р', 'в', 'щ' },
                            { 'в', 'ы', 'п', 'ч', ' ' },//{ 'ц', ':', 'п', 'е', 'л' },
                            { ':', 'д', 'у', 'о', 'к' },//{ 'ъ', 'а', 'н', '.', 'х' },
                            { 'з', 'э', 'ф', 'г', 'ш' },//{ 'э', 'к', 'с', 'ш', 'д' },
                            { 'х', 'а', ',', 'л', 'ъ' }};//{ 'б', 'ф', 'у', 'ы', ' '}

                        char[,] mas2 = {
                            { 'и', 'ч', 'г', 'я', 'т' },
                            { ',', 'ж', 'ь', 'м', 'о' },
                            { 'з', 'ю', 'р', 'в', 'щ' },
                            { 'ц', ':', 'п', 'е', 'л' },
                            { 'ъ', 'а', 'н', '.', 'х' },
                            { 'э', 'к', 'с', 'ш', 'д' },
                            { 'б', 'ф', 'у', 'ы', ' ' }};
                        Console.WriteLine("Введите текст");
                        string text = Console.ReadLine();
                        double x = text.Length / 2.0;
                        int z = 0;
                        bool last = false;
                        if (x < Math.Round(x))
                        {
                            z = (int)Math.Round(x);
                            text += " ";
                            last = true;
                        }
                        else
                        {
                            z = (int)x;
                        }
                        char[,] t = new char[z, 2];
                        int q = 0;
                        for (int i = 0; i < z; i++)
                        {
                            for (int j = 0; j < 2; j++)
                            {
                                t[i, j] = text[q];
                                q++;
                            }
                        }
                        /* for (int i = 0; i < z; i++)//вывод таблиц
                         {
                             for (int j = 0; j < 2; j++)
                             {
                                 Console.Write(t[i, j] + " ");
                             }
                             Console.Write("\n");
                         }*/
                        int fi = 0;
                        int fj = 0;
                        int si = 0;
                        int sj = 0;
                        bool w = false;
                        string pass = "";
                        for (int i = 0; i < z; i++)
                        {
                            for (int j = 0; j < 2; j++)
                            {
                                if (j == 0)
                                {
                                    for (int p = 0; p < 7; p++)
                                    {
                                        for (int f = 0; f < 5; f++)
                                        {
                                            if (t[i, j] == mas[p, f])
                                            {
                                                fi = p;
                                                fj = f;
                                                w = true;
                                                break;
                                            }
                                        }
                                        if (w == true)
                                        {
                                            break;
                                        }
                                    }
                                    //Console.WriteLine($"{t[i, j]} i = {fi} j = {fj}");
                                    w = false;
                                }
                                else
                                {
                                    for (int p = 0; p < 7; p++)
                                    {
                                        for (int f = 0; f < 5; f++)
                                        {
                                            if (t[i, j] == mas2[p, f])
                                            {
                                                si = p;
                                                sj = f;
                                                w = true;
                                                break;
                                            }
                                        }
                                        if (w == true)
                                        {
                                            break;
                                        }
                                    }
                                    //Console.WriteLine($"{t[i, j]} i = {si} j = {sj}");
                                    w = false;
                                }


                                ////////

                            }
                            if (si == fi)
                            {
                                pass += mas[fi, sj] + "" + mas2[si, fj];
                            }
                            else
                            {
                                pass += mas2[fi, sj] + "" + mas[si, fj];
                            }

                        }
                        Console.WriteLine(pass);
                        break;
                    }
                case 2:
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
                        for (int i = 0; i < 32; i++)
                        {
                            for (int j = 0; j < 32; j++)
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
