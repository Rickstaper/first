using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First
{
    class GCD
    {
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
                if (other[i - 1] == 0 || other[i] == 0)
                {
                    continue;
                }

                if (other[i - 1] > other[i])
                    other[i - 1] %= other[i];
                else
                    other[i] %= other[i - 1];

                otherResult = other[i - 1] + other[i];
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
    }
}
