using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace NJ02_Rational_Numbers
{
    public struct Rational : IComparable<Rational>, IEquatable<Rational>
    {

        public Rational(int numerator, int denominator)
        {
            try
            {
                this.numerator = numerator;

                if (denominator == 0)
                {
                    throw new ArgumentException("Rational number's denominator cannot be 0!");
                }

                this.denominator = denominator;

                // simplifying the numbers
                if (numerator != 0)
                {
                    int gcd = Gcd(numerator, denominator);
                    this.numerator /= gcd;
                    this.denominator /= gcd;
                }
            }
            catch (ArgumentException ex)
            {
                throw ex;
            }

        }

        public int numerator;
        public int denominator;

        public int CompareTo(Rational other)
        {
            Rational a = new Rational(numerator, denominator);

            ChangeNumbersToCommonDenominator(ref a, ref other);

            if (a.numerator > other.numerator) return 1;
            if (a.numerator == other.numerator) return 0;
            return -1;
        }

        public bool Equals([AllowNull] Rational other)
        {
            Rational a = new Rational(numerator, denominator);

            ChangeNumbersToCommonDenominator(ref a, ref other);

            if (a.numerator == other.numerator) return true;
            return false;
        }

        //greatest common divisor
        public static int Gcd(int x, int y)
        {
            return y == 0 ? x : Gcd(y, x % y);
        }

        //least common multiple
        //http://csharphelper.com/blog/2014/08/calculate-the-greatest-common-divisor-gcd-and-least-common-multiple-lcm-of-two-integers-in-c/
        public static int Lcm(int x, int y)
        {
            return x * y / Gcd(x, y);
        }

        public override string ToString()
        {
            if (denominator == 1)
            {
                return numerator.ToString();
            }
            else
            {
                return $"{numerator}r{denominator}";
            }
        }

        public static Rational operator +(Rational a, Rational b)
        {
            ChangeNumbersToCommonDenominator(ref a, ref b);

            var result = new Rational(a.numerator + b.numerator, a.denominator);

            var gcd = Gcd(result.numerator, result.denominator);
            result /= gcd;

            return result;
        }

        public static void ChangeNumbersToCommonDenominator(ref Rational a, ref Rational b)
        {
            if (a.denominator != b.denominator)
            {
                var lcm = Lcm(a.denominator, b.denominator);
                a *= lcm;
                b *= lcm;
            }
        }

        public static Rational operator -(Rational a, Rational b)
        {
            ChangeNumbersToCommonDenominator(ref a, ref b);

            return new Rational(a.numerator - b.numerator, a.denominator);
        }

        public static Rational operator *(Rational a, int b)
        {
            return new Rational(a.numerator * b, a.denominator);
        }

        public static Rational operator *(Rational a, Rational b)
        {
            return new Rational(a.numerator * b.numerator, a.denominator * b.denominator);
        }

        public static Rational operator /(Rational a, int b)
        {
            return new Rational(a.numerator, a.denominator * b);
        }

        public static Rational operator /(Rational a, Rational b)
        {
            return new Rational(a.numerator * b.denominator, a.denominator * b.numerator);
        }

        public static Rational operator !(Rational r)
        {
            return r * -1;
        }
    }
}
