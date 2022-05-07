using System;
using System.Linq;
using System.Threading;

namespace tp14
{
    public class Generation
    {
        public Bird[] Birds { get; private set; }

        public Generation(int size)
        {
            Birds = new Bird[size];
            
            for (int i = 0; i < size; i++)
            {
                Birds[i] = new Bird(); //===============================
            }
        }

        public Generation(Bird bird)
        {
            Birds = new[] {bird};
        }

        /// <summary>
        /// Sort function
        /// </summary>
        private void Sort()
        {
            Array.Sort(Birds, (b1, b2) => b1.Score.CompareTo(b2.Score));
        }

        /// <summary>
        /// Select a bird using fitness proportionate selection
        /// </summary>
        /// <param name="fitnessSum"> Sum of all the score of all birds </param>
        /// <returns> Bird chosen </returns>
        /// <exception cref="Exception"> If no bird are found, it should never happen </exception>
        private Bird SelectBird(double fitnessSum)
        {
            double rdmValue = Neurone.__RandomDouble(0, fitnessSum);
            double temp = 0;
            foreach (var bird in Birds)
            {
                temp += bird.Score;
                if (temp > rdmValue) return bird;
            }

            throw new ApplicationException();
        }

        /// <summary>
        /// Create new generation of bird
        /// </summary>
        public void NewGen()
        {
            int middle = Birds.Length / 2;
            int quart = Birds.Length / 2 + Birds.Length / 3;

            double fitnessSum = 0;
            foreach (var bird in Birds)
            {
                fitnessSum += bird.Score;
            }
            
            
            for (int i = 0; i < middle; i++)
            {
                Birds[i].Crossover(SelectBird(fitnessSum));
            }
            
            for (int i = middle; i < quart; i++)
            {
                Birds[i].Crossover(GetBestBird());
            }
            
            for (int i = quart; i < Birds.Length; i++)
            {
                Birds[i] = GetBestBird();
                Birds[i].Mutate();
            }
            
        }

        public void PrintBirdsScore()
        {
            Sort();
            foreach (var bird in Birds)
                Console.Write(bird.Score + " "); // Do not mind the trailing space...
            Console.WriteLine();
            Console.WriteLine("BEST SCORE: " + Birds[^1].Score);
        }

        /// <summary>
        /// Compute average score of all birds
        /// </summary>
        /// <returns></returns>
        public void PrintAvg()
        {
            Console.WriteLine("Average: " + Birds.Sum(bird => bird.Score) / Birds.Length);
        }

        /// <summary>
        /// Select the best bird in the current generation
        /// </summary>
        /// <returns></returns>
        public Bird GetBestBird()
        {
            Sort();
            return Birds[^1];
        }
    }
}