using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First
{
    /// <summary>
    /// The class has static methods for finding GCD by Stein's and Euclidean's algorithms.
    /// </summary>
    public class GCD
    {
        /// <summary>
        /// Calculates GCD of two integer by the Euclidean algorithm. 
        /// </summary>
        /// <param name="a">First integer</param>
        /// <param name="b">Second integer</param>
        /// <param name="time">Calculating time</param>
        /// <returns>The GCD value</returns>
        public static int GetGcdByEuclidean(int a, int b, out double time)
        {
            Stopwatch timer = Stopwatch.StartNew ();
            if (a == 0 && b == 0)
            {
                throw new ArgumentException (nameof (GetGcdByEuclidean));
            }

            if (a == int.MinValue)
            {
                throw new ArgumentOutOfRangeException (nameof(a));
            }

            if (b == int.MinValue)
            {
                throw new ArgumentOutOfRangeException (nameof (b));
            }

            if (a < 0)
            {
                a *= -1;
            }

            if (b < 0)
            {
                b *= -1;
            }

            while(a != 0 && b != 0)
            {
                if (a > b)
                    a %= b;
                else
                    b %= a;
            }

            timer.Stop ();
            time = timer.ElapsedTicks;
            return a + b;
        }

        /// <summary>
        /// Calculates GCD of three integer by the Euclidean algorithm.
        /// </summary>
        /// <param name="a">First integer</param>
        /// <param name="b">Second integer</param>
        /// <param name="c">Third integer</param>
        /// <returns>The GCD value</returns>
        public static int GetGcdByEuclidean(int a, int b, int c)
        {
            if (a == 0 && b == 0 && c == 0)
            {
                throw new ArgumentException (nameof (GetGcdByEuclidean));
            }

            if (a < int.MinValue)
            {
                throw new ArgumentOutOfRangeException (nameof (a));
            }

            if (b < int.MinValue)
            {
                throw new ArgumentOutOfRangeException (nameof (a));
            }

            if (c < int.MinValue)
            {
                throw new ArgumentOutOfRangeException (nameof (a));
            }

            if (a < 0)
            {
                a *= -1;
            }

            if (b < 0)
            {
                b *= -1;
            }

            if (c < 0)
            {
                c *= -1;
            }

            while(a != 0 && b != 0)
            {
                if (a > b)
                    a %= b;
                else
                    b %= a;
            }

            int result = a + b;

            while(result != 0 && c != 0)
            {
                if (result > c)
                    result %= c;
                else
                    c %= result;
            }

            result += c;

            return result;
        }

        /// <summary>
        /// Calculates GCD of two and more integer by the Euclidean algorithm.
        /// </summary>
        /// <param name="a">First integer</param>
        /// <param name="b">Second integer</param>
        /// <param name="other">Other integers</param>
        /// <returns>The GCD value</returns>
        public static int GetGcdByEuclidean(int a, int b, params int[] other)
        {
            if (a == 0 && b == 0 && other.All (i => i == 0))
                throw new ArgumentException (nameof (GetGcdByEuclidean));

            if (a == int.MinValue)
                throw new ArgumentOutOfRangeException (nameof (a));

            if (b == int.MinValue)
                throw new ArgumentOutOfRangeException (nameof (b));

            if (a < 0)
                a *= -1;

            if (b < 0)
                b *= -1;

            for (int i = 0; i < other.Length; i++)
            {
                if (other[i] == int.MinValue)
                    throw new ArgumentOutOfRangeException (nameof (other));

                if (other[i] < 0)
                    other[i] *= -1;
            }

            while(a != 0 && b != 0)
            {
                if (a > b)
                    a %= b;
                else
                    b %= a;
            }

            int result = a + b, otherResult = 0;

            for (int i = 1; i < other.Length; i++)
            {
                if (!(other[i - 1] == 0 || other[i] == 0))
                {
                    if (other[i - 1] > other[i])
                        other[i - 1] %= other[i];
                    else
                        other[i] %= other[i - 1];

                    otherResult = other[i - 1] + other[i];
                }
            }

            while(result != 0 && otherResult != 0)
            {
                if (result > otherResult)
                    result %= otherResult;
                else
                    otherResult %= result;
            }

            if (result + otherResult == 0)
                return 1;

            return otherResult + result;
        }

        /// <summary>
        /// Calculates GCD of two integer by the Stein algorithm.
        /// </summary>
        /// <param name="a">First integer</param>
        /// <param name="b">Second integer</param>
        /// <param name="time">Calculating time</param>
        /// <returns></returns>
        public static int GetGcdByStein(int a, int b, out double time)
        {
            Stopwatch timer = Stopwatch.StartNew ();
            if (a == 0 && b == 0)
            {
                throw new ArgumentException (nameof (GetGcdByStein));
            }

            if (a == int.MinValue)
                throw new ArgumentOutOfRangeException (nameof (a));

            if (b == int.MinValue)
                throw new ArgumentOutOfRangeException (nameof (b));

            if (a < 0)
                a *= -1;

            if (b < 0)
                b *= -1;

            if (a == 0)
            {
                timer.Stop ();
                time = timer.ElapsedTicks;
                return b;
            }
            if (b == 0)
            {
                timer.Stop ();
                time = timer.ElapsedTicks;
                return a;
            }

            if (a == b)
            {
                timer.Stop ();
                time = timer.ElapsedTicks;
                return a;
            }

            int count = 1;

            while(a != 0 && b != 0)
            {
                while(a % 2 == 0 && b % 2 == 0)
                {
                    a /= 2;
                    b /= 2;
                    count *= 2;
                }

                if (a % 2 == 0 && b % 2 != 0)
                    a /= 2;

                if (a % 2 != 0 && b % 2 == 0)
                    b /= 2;

                if (a > b)
                    a -= b;
                else
                    b -= a;
            }

            timer.Stop ();
            time = timer.ElapsedTicks;
            return (a + b) * count;
        }

        /// <summary>
        /// Gets better time of calculating between Euclidean and Stein algorithm.
        /// </summary>
        /// <param name="timeEuclidean">Time of Euclidean algorithm</param>
        /// <param name="timeStein">Time of Stein algorithm</param>
        public static void GetBetterTime(double timeEuclidean, double timeStein)
        {
            Console.WriteLine ("Time:\n" + "Euclidean:" + timeEuclidean + "\tStein:" + timeStein);

            if (timeEuclidean < timeStein)
                Console.WriteLine ("Euclidean's method has the best time");
            else
                Console.WriteLine ("Stein's method has the best time");
        }
    }
}
