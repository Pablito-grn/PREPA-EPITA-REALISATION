using System;
using System.Linq;
using NUnit.Framework;
using Reducto;

namespace TestReducto
{
    public class SanityTest
    {
        [Test]
        public void SanityCheck()
        {
            // Always Succeed
            Assert.Pass();
            
            // Succeed if given boolean is true
            Assert.True(true);
            
            // Succeed if two values are equal
            Assert.AreEqual(1, 1);

            // Succeed if an ArgumentException is throw when executing the given code
            Assert.Throws<ArgumentException>(() => new ArgumentException());
        }
    }
    public static class TestHelper
    {
        // Test if a polynomial contain a given monomial
        private static bool PolyContains(Polynomial p, Monomial m)
        {
            return p.Monomials.Any(monomial => monomial == m);
        }
        // Test if 2 polynomials are equal
        public static bool PolyEqual(Polynomial p1, Polynomial p2)
        {
            return p1.Monomials.Count == p2.Monomials.Count && p1.Monomials.All(m1 => PolyContains(p2, m1));
        }
    }
}