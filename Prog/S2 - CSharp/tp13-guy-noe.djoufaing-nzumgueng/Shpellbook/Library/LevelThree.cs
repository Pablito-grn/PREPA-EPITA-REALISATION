using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Library
{
    public class LevelThree
    {
        /// <summary>
        ///     Generates all primes numbers up to n included
        /// </summary>
        public static List<int> UsualPrimesGenerator(int n)
        {
            if (n < 0)
                return new List<int>();
            
            var numbers = Enumerable.Range(2, n).ToList();
            numbers.RemoveAll(x =>
            {
                for (var i = 2; i < x; i++)
                    if (x % i == 0 && x != i)
                        return true;

                return false;
            });

            return numbers;
        }


        /// <summary>
        ///     Remove integers divisible by n in the list
        /// </summary>
        /// <param name="n">the base multiple</param>
        /// <param name="primes">the list to remove from</param>
        public static void RemoveNotPrimes(int n, List<int> primes)
        {
            lock (primes)
            {
                primes.RemoveAll((int x) => x % n == 0);
            }
        }

        public static List<int> MagicPrimesGenerator(int n, int nbTasks)
        {
            if (n < 1)
                throw new ArgumentException("n msut be higher than 0");
            
            List<int> res = new List<int>();
            
            if (n < 2)
                return res;
            
            res = Enumerable.Range(2, n-1).ToList();

            List<Task> lTask = new List<Task>();

            
            var tasks = new Task[nbTasks];

            for (var i = 0; i < nbTasks; i++)
            {
                var i1 = i + 2;
                tasks[i] = new Task(() => RemoveNotPrimes(i1, res));
            }

            for (var i = 0; i < nbTasks; i++)
                tasks[i].Start();
            
            for (var i = 0; i < nbTasks; i++)
                tasks[i].Wait();
            
            return res;
            


            return res;
        }
    }
}