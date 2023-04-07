using System;
using System.Numerics;

namespace ConsoleApp1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("---------------------------------------");
            Tasks tasks = new Tasks();
            tasks.Task1RSA();
            Console.WriteLine("---------------------------------------");
            tasks.Task2AlGamal();
            Console.WriteLine("---------------------------------------");
        }
    }

    class Tasks
    {
        public void Task2AlGamal()
        {
            int p = 23;
            int g = 5;

            int x = 9;
            int k = 19;
            int m = 3;

            int y = (int)BigInteger.ModPow(g, x, p);
            int r = (int)BigInteger.ModPow(g, k, p);
            int s = ModInverse(k, p - 1) * (m - x * r) % (p - 1);
            bool isValid = VerifySignature(p, g, y, m, r, s);

            Console.WriteLine($"Открытый ключ:  y = {y} \nПодпись: (r, s) = ({r},{s}) \nПроверка подписи: {isValid}");
        }

        public void Task1RSA()
        {
            BigInteger n = 33;
            BigInteger e_ = 3;
            Tuple<BigInteger, BigInteger>[] messages = new Tuple<BigInteger, BigInteger>[]
            {
                Tuple.Create(new BigInteger(17), new BigInteger(8)),
                Tuple.Create(new BigInteger(10), new BigInteger(14)),
                Tuple.Create(new BigInteger(24), new BigInteger(18))
            };
            foreach (Tuple<BigInteger, BigInteger> message in messages)
            {
                BigInteger M = message.Item1;

                BigInteger s = message.Item2;

                BigInteger M_ = BigInteger.ModPow(s, e_, n);

                if (M == M_)
                {
                    Console.WriteLine($"Подпись верна M = {M}");
                }
                else
                {
                    Console.WriteLine($"Подпись верна M = {M}");
                }
            }
        }

        static int ModInverse(int a, int m)
        {
            int m0 = m, t, q;
            int x0 = 0, x1 = 1;

            if (m == 1)
                return 0;

            while (a > 1)
            {
                q = a / m;
                t = m;
                m = a % m;
                a = t;
                t = x0;
                x0 = x1 - q * x0;
                x1 = t;
            }

            if (x1 < 0)
                x1 += m0;

            return x1;
        }

        static bool VerifySignature(int p, int g, int y, int m, int r, int s)
        {
            int w = ModInverse(s, p - 1);
            int u1 = (int)(m * w % (p - 1));
            int u2 = (int)(r * w % (p - 1));
            int v = (int)(BigInteger.ModPow(g, u1, p) 
                * BigInteger.ModPow(y, u2, p) % p % (p - 1));
            return v != r;
        }
    }
}