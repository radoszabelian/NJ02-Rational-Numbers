using Microsoft.VisualStudio.TestTools.UnitTesting;
using NJ02_Rational_Numbers;
using System;

namespace TestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void throwExceptionWhenInitWith0Denominator()
        {
            Rational r1 = new Rational(1, 0);
        }

        [DataRow(6, 8, 3, 4)]
        [DataRow(10, 5, 2, 1)]
        [DataRow(100, 80, 5, 4)]
        [DataRow(0, 7, 0, 7)]
        [DataTestMethod]
        public void testSimpleStorage(int inputNumerator, int inputDenominator, int expectedNumerator, int expectedDenominator)
        {
            Rational r = new Rational(inputNumerator, inputDenominator);
            Assert.AreEqual(expectedNumerator, r.numerator);
            Assert.AreEqual(expectedDenominator, r.denominator);
        }

        [DataRow(2, 2, 10, 2, -1)]
        [DataRow(7, 12, 19, 27, -1)]
        [DataRow(84, 2, 42, 1, 0)]
        [DataRow(7, 7, 7, 7, 0)]
        [DataRow(84, 45, 1, 111, 1)]
        [DataRow(99, 1, 4, 77, 1)]
        [DataTestMethod]
        public void testComparison(int firstNumerator, int firstDenominator, int secondNumerator, int secondDenominator, int expectedResult)
        {
            Rational a = new Rational(firstNumerator, firstDenominator);
            Rational b = new Rational(secondNumerator, secondDenominator);

            Assert.AreEqual(expectedResult, a.CompareTo(b));
        }

        [DataRow(2, 2, 10, 2, false)]
        [DataRow(7, 12, 19, 27, false)]
        [DataRow(84, 2, 42, 1, true)]
        [DataRow(7, 7, 7, 7, true)]
        [DataRow(84, 45, 1, 111, false)]
        [DataRow(99, 1, 4, 77, false)]
        [DataTestMethod]
        public void testEquality(int firstNumerator, int firstDenominator, int secondNumerator, int secondDenominator, bool expectedResult)
        {
            Rational a = new Rational(firstNumerator, firstDenominator);
            Rational b = new Rational(secondNumerator, secondDenominator);

            Assert.AreEqual(expectedResult, a.Equals(b));
        }

        [DataRow(2, 3, "2r3")]
        [DataRow(7, 7, "1")]
        [DataRow(10, 2, "5")]
        [DataRow(77, 34, "77r34")]
        [DataTestMethod]
        public void testToString(int numerator, int denominator, string expectedResult)
        {
            Rational r = new Rational(numerator, denominator);

            Assert.AreEqual(expectedResult, r.ToString());
        }


        [DataRow(2, 2, 4, 2, 3, 1)]
        [DataRow(3, 7, 6, 14, 6, 7)]
        [DataRow(5, 5, 10, 2, 6, 1)]
        [DataTestMethod]
        public void testAdditionOperator(int firstNumerator, int firstDenominator, int secondNumerator, int secondDenominator, int expectedNumerator, int expectedDenominator)
        {
            Rational a = new Rational(firstNumerator, firstDenominator);
            Rational b = new Rational(secondNumerator, secondDenominator);

            Rational result = a + b;

            Assert.AreEqual(expectedNumerator, result.numerator);
            Assert.AreEqual(expectedDenominator, result.denominator);
        }

        [DataRow(2, 2, 4, 2, -1, 1)]
        [DataRow(3, 7, 6, 14, 0, 7)]
        [DataRow(5, 5, 10, 2, -4, 1)]
        [DataTestMethod]
        public void testSubstractionOperator(int firstNumerator, int firstDenominator, int secondNumerator, int secondDenominator, int expectedNumerator, int expectedDenominator)
        {
            Rational a = new Rational(firstNumerator, firstDenominator);
            Rational b = new Rational(secondNumerator, secondDenominator);

            Rational result = a - b;

            Assert.AreEqual(expectedNumerator, result.numerator);
            Assert.AreEqual(expectedDenominator, result.denominator);
        }

        [DataRow(2, 2, 4, 2, 2, 1)]
        [DataRow(3, 7, 6, 14, 9, 49)]
        [DataRow(5, 5, 10, 2, 5, 1)]
        [DataRow(7, 4, 3, 2, 21, 8)]
        [DataRow(9, 5, 5, 3, 3, 1)]
        [DataTestMethod]
        public void testMultiplicationOperator(int firstNumerator, int firstDenominator, int secondNumerator, int secondDenominator, int expectedNumerator, int expectedDenominator)
        {
            Rational a = new Rational(firstNumerator, firstDenominator);
            Rational b = new Rational(secondNumerator, secondDenominator);

            Rational result = a * b;

            Assert.AreEqual(expectedNumerator, result.numerator);
            Assert.AreEqual(expectedDenominator, result.denominator);
        }

        [DataRow(2, 2, 4, 2, 1, 2)]
        [DataRow(3, 7, 6, 14, 1, 1)]
        [DataTestMethod]
        public void testDivisionOperator(int firstNumerator, int firstDenominator, int secondNumerator, int secondDenominator, int expectedNumerator, int expectedDenominator)
        {
            Rational a = new Rational(firstNumerator, firstDenominator);
            Rational b = new Rational(secondNumerator, secondDenominator);

            Rational result = a / b;

            Assert.AreEqual(expectedNumerator, result.numerator);
            Assert.AreEqual(expectedDenominator, result.denominator);
        }

        [DataRow(2, 2, -1, 1)]
        [DataRow(3, 7, -3, 7)]
        [DataRow(3, 4, -3, 4)]
        [DataTestMethod]
        public void testNegationOperator(int firstNumerator, int firstDenominator, int expectedNumerator, int expectedDenominator)
        {
            Rational a = new Rational(firstNumerator, firstDenominator);

            Rational result = !a;

            Assert.AreEqual(expectedNumerator, result.numerator);
            Assert.AreEqual(expectedDenominator, result.denominator);
        }

    }
}
