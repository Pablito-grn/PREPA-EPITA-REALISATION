using System;
using NUnit.Framework;
using Reducto;

namespace TestReducto
{
    public class Polynomial_A_Constructor
    {
        [Test]
        public void Empty()
        {
            Polynomial p = new Polynomial();

            Assert.AreEqual(0, p.Monomials.Count);
        }
        [Test]
        public void Constructor_WithZero()
        {
            Polynomial p = new Polynomial(new Monomial(0));

            Assert.AreEqual(0, p.Monomials.Count);
        }
        
        [Test]
        public void Constructor_WithDifferentThanZero()
        {
            Polynomial p = new Polynomial(new Monomial(1));

            Assert.AreEqual(1, p.Monomials.Count);
        }
        [Test]
        public void Constructor_WithDifferentThanZero_Bis()
        {
            Polynomial p = new Polynomial(new Monomial(1, 3));

            Assert.AreEqual(1, p.Monomials.Count);
        }
    }
    public class Polynomial_B_UnaryMinus
    {
        [Test]
        public void NumberOnly_Simple()
        {
            Polynomial p = new Polynomial(new Monomial(4, 0));
            p = -p;
            Polynomial expected = new Polynomial(new Monomial(-4, 0));
            Assert.AreEqual(1, p.Monomials.Count);
            Assert.True(TestHelper.PolyEqual(expected, p));
        }
        [Test]
        public void NumberOnly_Negative()
        {
            Polynomial p = new Polynomial(new Monomial(-4, 0));
            p = -p;
            Polynomial expected = new Polynomial(new Monomial(4, 0));
            Assert.AreEqual(1, p.Monomials.Count);
            Assert.True(TestHelper.PolyEqual(expected, p));
        }
        [Test]
        public void NumberOnly_Zero()
        {
            Polynomial p = new Polynomial(new Monomial(0, 0));
            p = -p;
            Polynomial expected = new Polynomial(new Monomial(0, 0));
            Assert.AreEqual(0, p.Monomials.Count);
            Assert.True(TestHelper.PolyEqual(expected, p));
        }
        [Test]
        public void WithVariable_Simple()
        {
            Polynomial p = new Polynomial(new Monomial(1, 1));
            p = -p;
            Polynomial expected = new Polynomial(new Monomial(-1, 1));
            Assert.AreEqual(1, p.Monomials.Count);
            Assert.True(TestHelper.PolyEqual(expected, p));
        }
        [Test]
        public void WithVariable_DegreeTwo_Only()
        {
            Polynomial p = new Polynomial(new Monomial(3, 2));
            p = -p;
            Polynomial expected = new Polynomial(new Monomial(-3, 2));
            
            Assert.AreEqual(1, p.Monomials.Count);
            Assert.True(TestHelper.PolyEqual(expected, p));
        }
        [Test]
        public void WithVariable_DegreeTwo_Complete()
        {
            Polynomial p = new Polynomial(new Monomial(12, 0));
            p += new Polynomial(new Monomial(-7, 1));
            p += new Polynomial(new Monomial(3, 2));
            p = -p;
            
            Polynomial expected = new Polynomial(new Monomial(-12, 0));
            expected += new Polynomial(new Monomial(7, 1));
            expected += new Polynomial(new Monomial(-3, 2));
            
            Assert.AreEqual(3, p.Monomials.Count);
            Assert.True(TestHelper.PolyEqual(expected, p));
        }
    }
    public class Polynomial_C_Add
    {
        [Test]
        public void NumberOnly_Simple()
        {
            Polynomial p1 = new Polynomial(new Monomial(4, 0));
            Polynomial p2 = new Polynomial(new Monomial(7, 0));
            Polynomial result = p1 + p2;
            Polynomial expected = new Polynomial(new Monomial(11, 0));
            Assert.AreEqual(1, result.Monomials.Count);
            Assert.True(TestHelper.PolyEqual(expected, result));
        }
        [Test]
        public void NumberOnly_TrickyZero()
        {
            Polynomial p1 = new Polynomial(new Monomial(4, 0));
            Polynomial p2 = new Polynomial(new Monomial(-4, 0));
            Polynomial result = p1 + p2;
            Polynomial expected = new Polynomial(new Monomial(0, 0));
            Assert.AreEqual(0, result.Monomials.Count);
            Assert.True(TestHelper.PolyEqual(expected, result));
        }
        [Test]
        public void Basic_SameDegree()
        {
            Polynomial p1 = new Polynomial(new Monomial(4, 2));
            Polynomial p2 = new Polynomial(new Monomial(2, 2));
            Polynomial result = p1 + p2;
            Polynomial expected = new Polynomial(new Monomial(6, 2));
            Assert.AreEqual(1, result.Monomials.Count);
            Assert.True(TestHelper.PolyEqual(expected, result));
        }
        [Test]
        public void Basic_SameDegree_Zero()
        {
            Polynomial p1 = new Polynomial(new Monomial(4, 2));
            Polynomial p2 = new Polynomial(new Monomial(-4, 2));
            Polynomial result = p1 + p2;
            Polynomial expected = new Polynomial(new Monomial(0, 0));
            Assert.AreEqual(0, result.Monomials.Count);
            Assert.True(TestHelper.PolyEqual(expected, result));
        }
        
        [Test]
        public void Basic_TwoDegree()
        {
            Polynomial p = new Polynomial(new Monomial(4, 2));
            p += new Polynomial(new Monomial(7, 1));
            p += new Polynomial(new Monomial(-1, 1));
            p += new Polynomial(new Monomial(2, 2));
            
            Polynomial expected = new Polynomial(new Monomial(6, 2));
            expected += new Polynomial(new Monomial(6, 1));
            
            Assert.AreEqual(2, p.Monomials.Count);
            Assert.True(TestHelper.PolyEqual(expected, p));
        }
        [Test]
        public void WithVariable_MixedOrder()
        {
            Polynomial p1 = new Polynomial(new Monomial(1, 2));
            p1 += new Polynomial(new Monomial(5, 1));
            p1 += new Polynomial(new Monomial(4, 0));

            Polynomial p2 = new Polynomial(new Monomial(-5, 1));
            p2 += new Polynomial(new Monomial(-2, 0));
            p2 += new Polynomial(new Monomial(1, 2));
            
            Polynomial result = p1 + p2;
            
            Polynomial expected = new Polynomial();
            expected += new Polynomial(new Monomial(2, 2));
            expected += new Polynomial(new Monomial(2, 0));
            
            Assert.AreEqual(2, result.Monomials.Count);
            Assert.True(TestHelper.PolyEqual(expected, result));
        }
    }
    public class Polynomial_D_BinaryMinus
    {
        [Test]
        public void NumberOnly_Simple()
        {
            Polynomial p1 = new Polynomial(new Monomial(4, 0));
            Polynomial p2 = new Polynomial(new Monomial(7, 0));
            Polynomial result = p1 - p2;
            Polynomial expected = new Polynomial(new Monomial(-3, 0));
            Assert.AreEqual(1, result.Monomials.Count);
            Assert.True(TestHelper.PolyEqual(expected, result));
        }
        [Test]
        public void NumberOnly_NotZero()
        {
            Polynomial p1 = new Polynomial(new Monomial(4, 0));
            Polynomial p2 = new Polynomial(new Monomial(-4, 0));
            Polynomial result = p1 - p2;
            Polynomial expected = new Polynomial(new Monomial(8, 0));
            Assert.AreEqual(1, result.Monomials.Count);
            Assert.True(TestHelper.PolyEqual(expected, result));
        }
        [Test]
        public void NumberOnly_Zero()
        {
            Polynomial p1 = new Polynomial(new Monomial(4, 0));
            Polynomial p2 = new Polynomial(new Monomial(4, 0));
            Polynomial result = p1 - p2;
            Polynomial expected = new Polynomial(new Monomial(0, 0));
            Assert.AreEqual(0, result.Monomials.Count);
            Assert.True(TestHelper.PolyEqual(expected, result));
        }
        [Test]
        public void Basic_SameDegree()
        {
            Polynomial p1 = new Polynomial(new Monomial(4, 2));
            Polynomial p2 = new Polynomial(new Monomial(2, 2));
            Polynomial result = p1 - p2;
            Polynomial expected = new Polynomial(new Monomial(2, 2));
            Assert.AreEqual(1, result.Monomials.Count);
            Assert.True(TestHelper.PolyEqual(expected, result));
        }
        [Test]
        public void Basic_SameDegree_Zero()
        {
            Polynomial p1 = new Polynomial(new Monomial(4, 2));
            Polynomial p2 = new Polynomial(new Monomial(4, 2));
            Polynomial result = p1 - p2;
            Polynomial expected = new Polynomial(new Monomial(0, 0));
            Assert.AreEqual(0, result.Monomials.Count);
            Assert.True(TestHelper.PolyEqual(expected, result));
        }
        
        [Test]
        public void Basic_TwoDegree()
        {
            Polynomial p = new Polynomial(new Monomial(4, 2));
            p -= new Polynomial(new Monomial(7, 1));
            p -= new Polynomial(new Monomial(-1, 1));
            p -= new Polynomial(new Monomial(2, 2));
            
            Polynomial expected = new Polynomial(new Monomial(2, 2));
            expected += new Polynomial(new Monomial(-6, 1));
            
            Assert.AreEqual(2, p.Monomials.Count);
            Assert.True(TestHelper.PolyEqual(expected, p));
        }
        [Test]
        public void WithVariable_MixedOrder()
        {
            Polynomial p1 = new Polynomial(new Monomial(1, 2));
            p1 += new Polynomial(new Monomial(5, 1));
            p1 += new Polynomial(new Monomial(4, 0));

            Polynomial p2 = new Polynomial(new Monomial(-5, 1));
            p2 += new Polynomial(new Monomial(-2, 0));
            p2 += new Polynomial(new Monomial(1, 2));
            
            Polynomial result = p1 - p2;
            
            Polynomial expected = new Polynomial();
            expected += new Polynomial(new Monomial(10, 1));
            expected += new Polynomial(new Monomial(6, 0));
            
            Assert.AreEqual(2, result.Monomials.Count);
            Assert.True(TestHelper.PolyEqual(expected, result));
        }
    }
    public class Polynomial_E_Mult
    {
        [Test]
        public void NumberOnly_Simple()
        {
            Polynomial p1 = new Polynomial(new Monomial(4, 0));
            Polynomial p2 = new Polynomial(new Monomial(7, 0));
            Polynomial result = p1 * p2;
            Polynomial expected = new Polynomial(new Monomial(4*7, 0));
            Assert.AreEqual(1, result.Monomials.Count);
            Assert.True(TestHelper.PolyEqual(expected, result));
        }
        [Test]
        public void NumberOnly_Long()
        {
            Polynomial p1 = new Polynomial(new Monomial(4165, 0));
            Polynomial p2 = new Polynomial(new Monomial(748, 0));
            Polynomial result = p1 * p2;
            Polynomial expected = new Polynomial(new Monomial(4165*748, 0));
            Assert.AreEqual(1, result.Monomials.Count);
            Assert.True(TestHelper.PolyEqual(expected, result));
        }
        [Test]
        public void NumberOnly_One()
        {
            Polynomial p1 = new Polynomial(new Monomial(214, 0));
            Polynomial p2 = new Polynomial(new Monomial(1, 0));
            Polynomial result = p1 * p2;
            Polynomial expected = new Polynomial(new Monomial(214, 0));
            Assert.AreEqual(1, result.Monomials.Count);
            Assert.True(TestHelper.PolyEqual(expected, result));
        }
        [Test]
        public void NumberOnly_Zero_Left()
        {
            Polynomial p1 = new Polynomial(new Monomial(0, 0));
            Polynomial p2 = new Polynomial(new Monomial(7, 0));
            Polynomial result = p1 * p2;
            Polynomial expected = new Polynomial(new Monomial(0, 0));
            Assert.AreEqual(0, result.Monomials.Count);
            Assert.True(TestHelper.PolyEqual(expected, result));
        }
        [Test]
        public void NumberOnly_Zero_Right()
        {
            Polynomial p1 = new Polynomial(new Monomial(4, 0));
            Polynomial p2 = new Polynomial(new Monomial(0, 0));
            Polynomial result = p1 * p2;
            Polynomial expected = new Polynomial(new Monomial(0, 0));
            Assert.AreEqual(0, result.Monomials.Count);
            Assert.True(TestHelper.PolyEqual(expected, result));
        }
        [Test]
        public void NumberOnly_Zero_Both()
        {
            Polynomial p1 = new Polynomial(new Monomial(0, 0));
            Polynomial p2 = new Polynomial(new Monomial(0, 0));
            Polynomial result = p1 * p2;
            Polynomial expected = new Polynomial(new Monomial(0, 0));
            Assert.AreEqual(0, result.Monomials.Count);
            Assert.True(TestHelper.PolyEqual(expected, result));
        }
        [Test]
        public void WithVariable_Simple_7x()
        {
            Polynomial p1 = new Polynomial(new Monomial(1, 1));
            Polynomial p2 = new Polynomial(new Monomial(7, 0));
            Polynomial result = p1 * p2;
            Polynomial expected = new Polynomial(new Monomial(7, 1));
            Assert.AreEqual(1, result.Monomials.Count);
            Assert.True(TestHelper.PolyEqual(expected, result));
        }
        [Test]
        public void WithVariable_Simple_xx()
        {
            Polynomial p1 = new Polynomial(new Monomial(1, 1));
            Polynomial p2 = new Polynomial(new Monomial(1, 1));
            Polynomial result = p1 * p2;
            Polynomial expected = new Polynomial(new Monomial(1, 2));
            Assert.AreEqual(1, result.Monomials.Count);
            Assert.True(TestHelper.PolyEqual(expected, result));
        }
        [Test]
        public void WithVariable_Factoring_Simple()
        {
            // 2x + 3
            Polynomial p1 = new Polynomial(new Monomial(2, 1));
            p1 += new Polynomial(new Monomial(3, 0));
            // 4
            Polynomial p2 = new Polynomial(new Monomial(4, 0));
            Polynomial result = p1 * p2;
            // 8x + 12
            Polynomial expected = new Polynomial(new Monomial(12, 0));
            expected += new Polynomial(new Monomial(8, 1));
            Assert.AreEqual(2, result.Monomials.Count);
            Assert.True(TestHelper.PolyEqual(expected, result));
        }
        [Test]
        public void WithVariable_Factoring_Complete()
        {
            // 2x + 3
            Polynomial p1 = new Polynomial(new Monomial(2, 1));
            p1 += new Polynomial(new Monomial(3, 0));
            // 6x^2 - x -3
            Polynomial p2 = new Polynomial(new Monomial(-3, 0));
            p2 += new Polynomial(new Monomial(-1, 1));
            p2 += new Polynomial(new Monomial(6, 2));
            Polynomial result = p1 * p2;
            // (2x + 3)(6x^2 - x -3)
            // = 2x(6x^2 - x -3) + 3(6x^2 - x -3)
            // = 12x^3 - 2x^2 -6x + 18x^2 - 3x -9
            // = 12x^3 + 16x^2 - 9x -9
            Polynomial expected = new Polynomial(new Monomial(-9, 0));
            expected += new Polynomial(new Monomial(-9, 1));
            expected += new Polynomial(new Monomial(16, 2));
            expected += new Polynomial(new Monomial(12, 3));
            Assert.AreEqual(4, result.Monomials.Count);
            Assert.True(TestHelper.PolyEqual(expected, result));
        }
    }
    public class Polynomial_F_Div
    {
        [Test]
        public void OnlyNumberDiv_Perfect()
        {
            Polynomial p = new Polynomial(new Monomial(8, 0));
            p /=  new Polynomial(new Monomial(2, 0));
            
            
            Polynomial expected = new Polynomial(new Monomial(4, 0));
            
            Assert.True(TestHelper.PolyEqual(expected, p));
        }
        [Test]
        public void OnlyNumberDiv_WithRemainder()
        {
            Polynomial p = new Polynomial(new Monomial(46, 0));
            p /= new Polynomial(new Monomial(9, 0));
            
            
            Polynomial expected = new Polynomial(new Monomial(5, 0));
            
            Assert.True(TestHelper.PolyEqual(expected, p));
        }
        [Test]
        public void BiggerDegree_Simple()
        {
            Polynomial p1 = new Polynomial(new Monomial(7, 0));
            p1 += new Polynomial(new Monomial(7, 1));
            p1 += new Polynomial(new Monomial(2, 2));
            
            Polynomial p2 = new Polynomial(new Monomial(2, 0));
            p2 += new Polynomial(new Monomial(1, 1));

            Polynomial result = p1 / p2;
            
            Polynomial expected = new Polynomial(new Monomial(3, 0));
            expected += new Polynomial(new Monomial(2, 1));
            
            Assert.True(TestHelper.PolyEqual(expected, result));
        }
        
        [Test]
        public void BiggerDegree_Wikipedia()
        {
            Polynomial p1 = new Polynomial(new Monomial(-4, 0));
            p1 += new Polynomial(new Monomial(-2, 2));
            p1 += new Polynomial(new Monomial(1, 3));
            
            Polynomial p2 = new Polynomial(new Monomial(-3, 0));
            p2 += new Polynomial(new Monomial(1, 1));

            Polynomial result = p1 / p2;
            
            Polynomial expected = new Polynomial(new Monomial(3, 0));
            expected += new Polynomial(new Monomial(1, 1));
            expected += new Polynomial(new Monomial(1, 2));
            
            Assert.True(TestHelper.PolyEqual(expected, result));
        }
        
        [Test]
        public void SameDegree_Simple()
        {
            Polynomial p1 = new Polynomial(new Monomial(7, 0));
            p1 += new Polynomial(new Monomial(6, 2));
            
            Polynomial p2 = new Polynomial(new Monomial(1, 0));
            p2 += new Polynomial(new Monomial(2, 2));

            Polynomial result = p1 / p2;
            
            Polynomial expected = new Polynomial(new Monomial(3, 0));
            
            Assert.True(TestHelper.PolyEqual(expected, result));
        }
        
        [Test]
        public void SameDegree_MathStackExchange()
        {
            Polynomial p1 = new Polynomial(new Monomial(2, 0));
            p1 += new Polynomial(new Monomial(5, 1));
            p1 += new Polynomial(new Monomial(10, 2));
            p1 += new Polynomial(new Monomial(4, 3));
            
            Polynomial p2 = new Polynomial(new Monomial(1, 0));
            p2 += new Polynomial(new Monomial(3, 1));
            p2 += new Polynomial(new Monomial(3, 2));
            p2 += new Polynomial(new Monomial(2, 3));

            Polynomial result = p1 / p2;
            
            Polynomial expected = new Polynomial(new Monomial(2, 0));
            
            Assert.True(TestHelper.PolyEqual(expected, result));
        }
        
        [Test]
        public void SmallerDegree_Simple()
        {
            Polynomial p1 = new Polynomial(new Monomial(2, 0));
            
            Polynomial p2 = new Polynomial(new Monomial(1, 0));
            p2 += new Polynomial(new Monomial(3, 1));

            Polynomial result = p1 / p2;
            
            Polynomial expected = new Polynomial(new Monomial(0, 0));
            
            Assert.True(TestHelper.PolyEqual(expected, result));
        }
        
        [Test]
        public void SmallerDegree_Hard()
        {
            Polynomial p1 = new Polynomial(new Monomial(2, 0));
            p1 += new Polynomial(new Monomial(5, 1));
            p1 += new Polynomial(new Monomial(10, 2));
            
            Polynomial p2 = new Polynomial(new Monomial(1, 0));
            p2 += new Polynomial(new Monomial(3, 1));
            p2 += new Polynomial(new Monomial(3, 2));
            p2 += new Polynomial(new Monomial(2, 3));

            Polynomial result = p1 / p2;
            
            Polynomial expected = new Polynomial(new Monomial(0, 0));
            
            Assert.True(TestHelper.PolyEqual(expected, result));
        }
    }
    public class Polynomial_G_Pow
    {
        [Test]
        public void NumberOnly_Simple()
        {
            Polynomial p1 = new Polynomial(new Monomial(2, 0));
            Polynomial p2 = new Polynomial(new Monomial(3, 0));
            Polynomial result = p1 ^ p2;
            Polynomial expected = new Polynomial(new Monomial(8, 0));
            Assert.True(TestHelper.PolyEqual(expected, result));
        }
        [Test]
        public void NumberOnly_Negative_Even()
        {
            Polynomial p1 = new Polynomial(new Monomial(-2, 0));
            Polynomial p2 = new Polynomial(new Monomial(4, 0));
            Polynomial result = p1 ^ p2;
            Polynomial expected = new Polynomial(new Monomial(16, 0));
            Assert.True(TestHelper.PolyEqual(expected, result));
        }
        [Test]
        public void NumberOnly_Negative_Odd()
        {
            Polynomial p1 = new Polynomial(new Monomial(-2, 0));
            Polynomial p2 = new Polynomial(new Monomial(3, 0));
            Polynomial result = p1 ^ p2;
            Polynomial expected = new Polynomial(new Monomial(-8, 0));
            Assert.True(TestHelper.PolyEqual(expected, result));
        }
        [Test]
        public void NumberOnly_Zero()
        {
            Polynomial p1 = new Polynomial(new Monomial(2, 0));
            Polynomial p2 = new Polynomial(new Monomial(0, 0));
            Polynomial result = p1 ^ p2;
            Polynomial expected = new Polynomial(new Monomial(1, 0));
            Assert.True(TestHelper.PolyEqual(expected, result));
        }
        [Test]
        public void NumberOnly_Zero_Zero()
        {
            Polynomial p1 = new Polynomial(new Monomial(0, 0));
            Polynomial p2 = new Polynomial(new Monomial(0, 0));
            Polynomial result = p1 ^ p2;
            Polynomial expected = new Polynomial(new Monomial(1, 0));
            Assert.True(TestHelper.PolyEqual(expected, result));
        }
        [Test]
        public void NumberOnly_Zero_Negative()
        {
            Polynomial p1 = new Polynomial(new Monomial(-3, 0));
            Polynomial p2 = new Polynomial(new Monomial(0, 0));
            Polynomial result = p1 ^ p2;
            Polynomial expected = new Polynomial(new Monomial(1, 0));
            Assert.True(TestHelper.PolyEqual(expected, result));
        }
        [Test]
        public void WithVariable_Simple()
        {
            Polynomial p1 = new Polynomial(new Monomial(2, 1));
            Polynomial p2 = new Polynomial(new Monomial(3, 0));
            Polynomial result = p1 ^ p2;
            Polynomial expected = new Polynomial(new Monomial(8, 3));
            Assert.True(TestHelper.PolyEqual(expected, result));
        }
        [Test]
        public void WithVariable_Simple_HighDegree()
        {
            Polynomial p1 = new Polynomial(new Monomial(2, 4));
            Polynomial p2 = new Polynomial(new Monomial(10, 0));
            Polynomial result = p1 ^ p2;
            Polynomial expected = new Polynomial(new Monomial(1024, 40));
            Assert.True(TestHelper.PolyEqual(expected, result));
        }
        [Test]
        public void WithVariable_Expr_Complete()
        {
            Polynomial p1 = new Polynomial(new Monomial(5, 0));
            p1 += new Polynomial(new Monomial(2, 1));
            Polynomial p2 = new Polynomial(new Monomial(3, 0));
            // (2x + 5)^3
            // = 8x^3 + 60x^2 + 150x + 125
            Polynomial result = p1 ^ p2;
            Polynomial expected = new Polynomial(new Monomial(125, 0));
            expected += new Polynomial(new Monomial(150, 1));
            expected += new Polynomial(new Monomial(60, 2));
            expected += new Polynomial(new Monomial(8, 3));
            Assert.True(TestHelper.PolyEqual(expected, result));
        }
        
        private static void TestPowPolynomial(Polynomial p1, Polynomial p2)
        {
            Polynomial p = p1 ^ p2;
        }
        [Test]
        public void ErrorManagement_Negative()
        {
            Polynomial p1 = new Polynomial(new Monomial(3, 0));
            Polynomial p2 = new Polynomial(new Monomial(-1, 0));
            Assert.Throws<ArithmeticException>(() => TestPowPolynomial(p1, p2));
        }
        [Test]
        public void ErrorManagement_Negative_Bis()
        {
            Polynomial p1 = new Polynomial(new Monomial(0, 0));
            Polynomial p2 = new Polynomial(new Monomial(-12, 0));
            Assert.Throws<ArithmeticException>(() => TestPowPolynomial(p1, p2));
        }
        [Test]
        public void ErrorManagement_NonConst()
        {
            Polynomial p1 = new Polynomial(new Monomial(3, 0));
            Polynomial p2 = new Polynomial(new Monomial(1, 1));
            Assert.Throws<ArithmeticException>(() => TestPowPolynomial(p1, p2));
        }
        [Test]
        public void ErrorManagement_NonConst_Big()
        {
            Polynomial p1 = new Polynomial(new Monomial(3, 0));
            Polynomial p2 = new Polynomial(new Monomial(3, 0));
            p2 += new Polynomial(new Monomial(1, 1));
            p2 += new Polynomial(new Monomial(-4, 2));
            Assert.Throws<ArithmeticException>(() => TestPowPolynomial(p1, p2));
        }
    }
}