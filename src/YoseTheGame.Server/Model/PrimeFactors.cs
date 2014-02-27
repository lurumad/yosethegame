using System;
using System.Collections.Generic;
using System.Linq;

namespace YoseTheGame.Server.Model
{
    public class PrimeFactors
    {
        private const int BigNumberAllow = 100000;

        public bool IsValidNumber(string number)
        {
            int result;
            return int.TryParse(number, out result);
        }

        public bool IsBigNumber(int number)
        {
            return number > BigNumberAllow;
        }

        public int [] Decomposition(int number)
        {
            var primes = new List<int>();

            for (var candidate = 2; number > 1; candidate++)
            {
                for (; number % candidate == 0; number /= candidate)
                {
                    primes.Add(candidate);
                }
            }

            return primes.ToArray();
        }
    }
}
