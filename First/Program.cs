using System;

namespace First
{
    class Program
    {
        static void Main(string[] args)
        {
            double timeEuclidean, timeStein;
            int euclidean = GCD.GetGcdByEuclidean (10, 15, out timeEuclidean);
            int stein = GCD.GetGcdByStein (10, 15, out timeStein);

            Console.WriteLine ("Stein:" + stein + "\nEuclidean:" + euclidean);

            GCD.GetBetterTime (timeEuclidean, timeStein);
        }
    }
}
