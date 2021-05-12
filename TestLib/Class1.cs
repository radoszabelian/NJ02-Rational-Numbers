using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using NJ02_Rational_Numbers;

namespace TestLib
{
    public class TestClass
    {
        //[DataRow(0,0)]
        //[DataRow(1,1)]
        //[DataTestMethod]
        //public void GivenDataRationalReturnsResultsOk(int )

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void throwExceptionWhenInitWith0Denominator()
        {
            Rational r1 = new Rational(1, 0);
        }

    }
}
