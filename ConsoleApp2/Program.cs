using System;

namespace euclidean_console
{

    internal class Program
    {
        static int InputNumber()
        {
            while (true)
            {
                if (Int32.TryParse(Console.ReadLine(), out var result))
                {
                    return result;
                }
                Console.WriteLine("You entered not valid number. Try again.");
            }
        }
        static int Mod(int a, int n)
        {
            return a - (int)Math.Floor((double)a / n) * n;
        }

        static int SimpleEuclideanAlgorithm(int a, int n)
        {
            while (a != 0 && n != 0)
            {
                if (a > n) a %= n;
                else n %= a;
            }
            return a == 0 ? n : a;
        }

        static Tuple<int, int, int> ExtendedEuclideanAlgorithm(int a, int n)
        {
            if (n == 0) return new Tuple<int, int, int>(a, 1, 0);

            var res = ExtendedEuclideanAlgorithm(n, a % n);
            return new Tuple<int, int, int>(res.Item1, res.Item3, res.Item2 - (a / n) * res.Item3);
        }


        static void Main(string[] args)
        {
            Console.WriteLine("Enter a:");
            var a = InputNumber();
            Console.WriteLine("Enter n:");
            var n = InputNumber();

            var gcd = SimpleEuclideanAlgorithm(a, n);
            Console.WriteLine("GCD found by Simple Euclidean Algorithm is " + gcd);
 
            if (gcd == 1)
            {
                int inputA, inputN;
                if (a > n)
                {
                    inputA = a;
                    inputN = n;
                }
                else
                {
                    inputA = n;
                    inputN = a;
                }

                var res = ExtendedEuclideanAlgorithm(inputA, inputN);
                Console.WriteLine("Multiplicative inverse of " + a + " mod " + n + " is " + Mod(res.Item3, n) + " mod " + n);
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Cannot find multiplicative inverse");
                Console.ReadKey();
            }
        }
    }
}
