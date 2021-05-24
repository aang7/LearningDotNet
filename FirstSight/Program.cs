using System;
using System.Collections.Generic;
using System.Linq;

namespace FirstSight
{
    class Program
    {

        public static int N_NUMBERS = 200;
        static void Main(string[] args)
        {
            while(true)
            {
                List<uint> numbers = generate_numbers();
                Console.WriteLine("=========prime numbers==========");
                
                var primes = numbers.Where(x => is_prime((int)x));
                
                Console.WriteLine("Primes: ");
                foreach (var prime in primes.OrderBy(p => (int)p))
                    Console.Write($"{prime} ");
                
                
                string input = Console.ReadLine();
                if (input == "end")
                    break;
           

            }
            

        }

        static bool is_prime(int x)
        {
            for(int i = 2; i <= Math.Sqrt(x); i++)
                if (x % i == 0)
                    return false;

            return true;
        }

        static List<uint> group_prime_numbers(List<uint> numbers)
        {
            return numbers.Where(x => is_prime((int)x)).ToList();
        }


        static List<uint> generate_numbers()
        {
            var rd = new Random();
            var randomsn = new List<uint>();

            for (int i = 0; i < N_NUMBERS; i++)
                randomsn.Add((uint)rd.Next(1, 500));


            // using collections methods to filter 
            int m300 = randomsn.Where(x => x < 250).Count();
            int g300 = randomsn.Count - m300;

            Console.WriteLine("menores a 300: {0} -> %{1} mayores a 300: {2} -> %{3}", m300, (100.0 * m300) / N_NUMBERS, g300, (100.0 * g300) / N_NUMBERS);

            return randomsn;
        }
    }
}
