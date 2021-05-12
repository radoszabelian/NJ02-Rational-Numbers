using Microsoft.VisualStudio.TestTools.UnitTesting;
using NJ02_Rational_Numbers;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AdditionTest1()
        {
            Rational r1 = new Rational(2, 1);
            Rational r2 = new Rational(4, 1);

            var result = r1 + r2;
        }
    }
}
