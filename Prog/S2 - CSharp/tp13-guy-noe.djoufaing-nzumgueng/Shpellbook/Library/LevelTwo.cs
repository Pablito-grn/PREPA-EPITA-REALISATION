using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Library
{
    public class LevelTwo
    {
        /// <summary>
        ///     Suppose we can read a book in 1000 milliseconds, simulate someone reading this list of books
        /// </summary>
        public static void Reading(List<Book> books)
        {
            Task read = new Task(() =>
            {
                foreach (var bk1 in books)
                {
                    Console.WriteLine(bk1.ToString());
                    System.Threading.Thread.Sleep(1000);
                }
            });
            
            read.Start();
            read.Wait();

        }

        /// <summary>
        ///     Create /parallel/ readers who are reading together
        ///     Make the reader1 start reading first
        /// </summary>
        public static void PairReading(List<Book> reader1, List<Book> reader2)
        {
            Task read = new Task(() =>
            {
                foreach (var bk1 in reader1)
                {
                    Console.WriteLine(bk1.ToString());
                    System.Threading.Thread.Sleep(1000);
                }
            });
            
            Task read2 = new Task(() =>
            {
                foreach (var bk2 in reader2)
                {
                    Console.WriteLine(bk2.ToString());
                    System.Threading.Thread.Sleep(1000);
                }
            });
            
            read.Start();
            read2.Start();

            read.Wait();
            read2.Wait();
        }


        /// <summary>
        ///     Should find the first shelf which satisfy the criteria
        ///     from each book until the time is over.
        /// </summary>
        /// <param name="books">the books to sort, shall not be modified</param>
        /// <param name="shelves">all the shelves there is</param>
        /// <param name="time">the time of the detention in milliseconds</param>
        public static void Detention(List<Book> books, Shelf[] shelves, int time)
        {
            //int currentTime = 0;

            Task range = Task.Run(() =>
            {
                foreach (var bk in books)
                {
                    foreach (var sh in shelves)
                    {
                        if (sh.Criteria(bk))
                        {
                            sh.Books.Add(bk);
                            break;
                        }
                    }
                }
            });

            Task tk = Task.Run(() =>
            {
                Task.Delay(time);
                range.Wait(); // On arrete la tache apres time temps;
            });

            tk.Wait();

        }
    }
}