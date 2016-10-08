using System;
using System.Collections.Generic;
using System.Linq;

namespace SofthemeTask2
{
    class Program
    {
        private const int MaxNumber = 1000000;
        private static int[] primes;

        /// <summary>
        /// Main method
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            primes = GeneratePrimes(MaxNumber);
            int circularCount = 0;
            for (int i = 0; i < primes.Length; i++)
            {
                if (CheckCircularPrime(primes[i]))
                {
                    Console.WriteLine(primes[i]);
                    circularCount++;
                }
            }
            Console.WriteLine("Total circular primes: {0}", circularCount);
            Console.ReadLine();
        }

        /// <summary>
        /// Generates all prime numbers from 1 to max limit
        /// </summary>
        /// <param name="max">Maximum number</param>
        /// <returns>Array of prime numbers</returns>
        public static int[] GeneratePrimes(int max)
        {
            bool[] isNotPrime = new bool[max/2];
            isNotPrime[0] = true;
            for (int i = 1; i < isNotPrime.Length; i++)
            {
                if (!isNotPrime[i])
                {
                    int step = i + i + 1;
                    for (int j = i + step; j < isNotPrime.Length; j+=step)
                    {
                        isNotPrime[j] = true;
                    }
                }
            }

            List<int> primesList = new List<int> {2}; // Add number 2
            for (int i = 0; i < isNotPrime.Length; i++)
            {
                if (!isNotPrime[i])
                {
                    primesList.Add(i + i + 1);
                }
            }
            int[] buffer = new int[primesList.Count];
            primesList.CopyTo(buffer);
            return buffer;
        }

        /// <summary>
        /// Checks if prime number is circular prime
        /// </summary>
        /// <param name="num">Number to check</param>
        /// <returns>Boolean result</returns>
        private static bool CheckCircularPrime(int num)
        {
            int length = (int) Math.Floor(Math.Log10(num)) + 1;
            for (int i = 0; i < length - 1; i++)
            {
                num = num%10 * (int) Math.Pow(10, length - 1) + num/10; //циклический сдвиг вправо
                if (num % 2 == 0 || num % 5 == 0)
                    return false;
                if (!primes.Contains(num))
                    return false;
            }
            return true;
        }

    }
}
