using System;
using System.Collections.Generic;
using System.Linq;

namespace Competitive.MathFundamentals
{
    public class Prime
    {
        /*
            Returns true is the value is prime
        */
        public static bool IsPrime(int n)
        {
            if (n < 2)
                return true;
            for (int i = 2; i < Math.Sqrt(n); i++)
            {
                if (n % i == 0)
                    return false;
            }
            return true;
        }
        /*
            Every number can be expressed as the result of the factos of prime numbers.
            6 = 2^1 * 3^1
            10 = 2^1 * 5^1
            15 = 3^1 * 5^1
            100 = 2^2 * 5^2
            101 = 101^1
        */
        public static string PrimeFactorization(int n)
        {
            if (n == 1)
            {
                return ($"2^0");
            }
            int originalN = n;
            List<int> factors = new List<int>();
            List<int> expo = new List<int>();
            int d = 2;
            while (n > 1 && d <= Math.Sqrt(n))
            {
                int k = 0;
                while (n % d == 0)
                {
                    k++;
                    n = n / d;
                }
                if (k > 0)
                {
                    factors.Add(d);
                    expo.Add(k);
                }
                d++;
            }
            if (n > 1)
            {
                factors.Add(n);
                expo.Add(1);
            }
            string ret = string.Empty;
            for (int i = 0; i < factors.Count; i++)
            {
                ret += $"{factors[i]}^{expo[i]} * ";
            }
            return ret.Substring(0, ret.Length - 3).Trim();
        }
        /*
            Returns a List with the prime numbers up to N
            Starting from 2 and marking every multiple as false (since its not a prime number) and advancing until n/2
        */
        public static List<int> Seave(int n)
        {
            bool[] primes = new bool[n + 1];
            for (int i = 0; i < n + 1; i++)
            {
                primes[i] = true;
            }
            for (int i = 2; i <= n / 2; i++)
            {
                if (primes[i])
                {
                    for (int j = i * 2; j <= n; j += i)
                    {
                        primes[j] = false;
                    }
                }
            }
            List<int> ret = new List<int>();
            for (int i = 2; i < n+1; i++)
            {
                if (primes[i])
                {
                    // Console.WriteLine(i);
                    ret.Add(i);
                }
            }
            return ret;
        }
    }
}