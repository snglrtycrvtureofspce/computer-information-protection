using System;

namespace Part02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[,] mas =  {{ 'ж', 'щ', 'н', 'ю', 'р' },//{ 'и', 'ч', 'г', 'я', 'т' },
                            { 'и', 'т', 'ь', 'ц', 'б' },//{ ',', 'ж', 'ь', 'м', 'о' },
                            { 'я', 'м', 'е', '.', 'с' },//{ 'з', 'ю', 'р', 'в', 'щ' },
                            { 'в', 'ы', 'п', 'ч', ' ' },//{ 'ц', ':', 'п', 'е', 'л' },
                            { ':', 'д', 'у', 'о', 'к' },//{ 'ъ', 'а', 'н', '.', 'х' },
                            { 'з', 'э', 'ф', 'г', 'ш' },//{ 'э', 'к', 'с', 'ш', 'д' },
                            { 'х', 'а', ',', 'л', 'ъ' }};//{ 'б', 'ф', 'у', 'ы', ' '}

            char[,] mas2 = {{ 'и', 'ч', 'г', 'я', 'т' },
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
                if(si == fi)
                {
                    pass += mas[fi, sj] + "" + mas2[si, fj];
                }
                else
                {
                    pass += mas2[fi, sj]+""+ mas[si, fj];
                }
                
            }
            Console.WriteLine(pass);
            Console.ReadKey();
        }
    }
}
