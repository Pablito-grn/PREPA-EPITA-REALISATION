using System;
using NUnit.Framework;
using Reducto;

namespace TestReducto
{
    public class Reducto_Step_5_A_NumberOnly_Power
    {
        [Test]
        public void NumberOnly_Simple_Pow()
        {
            var p = Reducto.Reducto.Parse("3^2");

            Polynomial expected = new Polynomial();
            expected += new Polynomial(new Monomial(9));
            
            Assert.True(TestHelper.PolyEqual(expected,p));
        }
        [Test]
        public void NumberOnly_Zero()
        {
            var p = Reducto.Reducto.Parse("3^0");

            Polynomial expected = new Polynomial();
            expected += new Polynomial(new Monomial(1));
            
            Assert.True(TestHelper.PolyEqual(expected,p));
        }
        [Test]
        public void NumberOnly_Zero_Zero()
        {
            var p = Reducto.Reducto.Parse("0^0");

            Polynomial expected = new Polynomial();
            expected += new Polynomial(new Monomial(1));
            
            Assert.True(TestHelper.PolyEqual(expected,p));
        }
        [Test]
        public void NumberOnly_Zero_Zero_Zero_Zero_Zero_Zero()
        {
            var p = Reducto.Reducto.Parse("0^0^0^0^0^0^0^0^0^0");

            Polynomial expected = new Polynomial();
            expected += new Polynomial(new Monomial(1));
            
            Assert.True(TestHelper.PolyEqual(expected,p));
        }
        [Test]
        public void NumberOnly_Pow_WithExpr_Right()
        {
            var p = Reducto.Reducto.Parse("3^(1 + 1)");

            Polynomial expected = new Polynomial();
            expected += new Polynomial(new Monomial(9));
            
            Assert.True(TestHelper.PolyEqual(expected,p));
        }
        [Test]
        public void NumberOnly_Pow_WithExpr_Left()
        {
            var p = Reducto.Reducto.Parse("(9 / 3)^2");

            Polynomial expected = new Polynomial();
            expected += new Polynomial(new Monomial(9));
            
            Assert.True(TestHelper.PolyEqual(expected,p));
        }
        [Test]
        public void NumberOnly_Pow_WithExpr_Both()
        {
            var p = Reducto.Reducto.Parse("(2 + 1)^(1 * 2)");

            Polynomial expected = new Polynomial();
            expected += new Polynomial(new Monomial(9));
            
            Assert.True(TestHelper.PolyEqual(expected,p));
        }
        [Test]
        public void NumberOnly_WithUnary_Negative()
        {
            var p = Reducto.Reducto.Parse("1000 + 2^--3 + 100");

            Polynomial expected = new Polynomial();
            expected += new Polynomial(new Monomial(1108));
            
            Assert.True(TestHelper.PolyEqual(expected,p));
        }
        [Test]
        public void NumberOnly_WithUnary_Positive()
        {
            var p = Reducto.Reducto.Parse("1000 + 2^++3 + 100");

            Polynomial expected = new Polynomial();
            expected += new Polynomial(new Monomial(1108));
            
            Assert.True(TestHelper.PolyEqual(expected,p));
        }
        [Test]
        public void Subject_Example_Hard_NumberOnly()
        {
            var p = Reducto.Reducto.Parse("- -+(+-(-  -+( ((  2^(3 * 2)  -8+87) / 5) + 8) - -4) + 5 )* -1 + --7");

            Polynomial expected = new Polynomial();
            expected += new Polynomial(new Monomial(42));
            
            Assert.True(TestHelper.PolyEqual(expected,p));
        }
        [Test]
        public void Minus_Pow()
        {
            var p = Reducto.Reducto.Parse("-3^2");

            Polynomial expected = new Polynomial();
            expected += new Polynomial(new Monomial(9));
            
            Assert.True(TestHelper.PolyEqual(expected,p));
        }
        [Test]
        public void Minus_Parenthesis_Pow()
        {
            var p = Reducto.Reducto.Parse("-(3^2)");

            Polynomial expected = new Polynomial();
            expected += new Polynomial(new Monomial(-9));
            
            Assert.True(TestHelper.PolyEqual(expected,p));
        }
        [Test]
        public void Plus_Parenthesis_Pow()
        {
            var p = Reducto.Reducto.Parse("+(3^2)");

            Polynomial expected = new Polynomial();
            expected += new Polynomial(new Monomial(9));
            
            Assert.True(TestHelper.PolyEqual(expected,p));
        }
    }
    public class Reducto_Step_5_B_WithVariable
    {
        [Test]
        public void WithVariable_SimpleX()
        {
            var p = Reducto.Reducto.Parse("x^2");

            Polynomial expected = new Polynomial();
            expected += new Polynomial(new Monomial(1, 2));
            
            Assert.True(TestHelper.PolyEqual(expected,p));
        }
        [Test]
        public void WithVariable_Power_Zero()
        {
            var p = Reducto.Reducto.Parse("x^0");

            Polynomial expected = new Polynomial();
            expected += new Polynomial(new Monomial(1));
            
            Assert.True(TestHelper.PolyEqual(expected,p));
        }
        [Test]
        public void WithVariable_SimpleX_WithCoef_Left()
        {
            var p = Reducto.Reducto.Parse("3*x^2");

            Polynomial expected = new Polynomial();
            expected += new Polynomial(new Monomial(3, 2));
            
            Assert.True(TestHelper.PolyEqual(expected,p));
        }
        [Test]
        public void WithVariable_SimpleX_WithCoef_Right()
        {
            var p = Reducto.Reducto.Parse("x^2*3");

            Polynomial expected = new Polynomial();
            expected += new Polynomial(new Monomial(3, 2));
            
            Assert.True(TestHelper.PolyEqual(expected,p));
        }
        [Test]
        public void WithVariable_SimpleX_WithAddition_Both()
        {
            var p = Reducto.Reducto.Parse("3+x^2+x");

            Polynomial expected = new Polynomial();
            expected += new Polynomial(new Monomial(3));
            expected += new Polynomial(new Monomial(1, 1));
            expected += new Polynomial(new Monomial(1, 2));
            
            Assert.True(TestHelper.PolyEqual(expected,p));
        }
        [Test]
        public void WithVariable_SimpleX_WithAddition_Both_Bis()
        {
            var p = Reducto.Reducto.Parse("x+x^2+3");

            Polynomial expected = new Polynomial();
            expected += new Polynomial(new Monomial(3));
            expected += new Polynomial(new Monomial(1, 1));
            expected += new Polynomial(new Monomial(1, 2));
            
            Assert.True(TestHelper.PolyEqual(expected,p));
        }
        [Test]
        public void WithVariable_Parenthesis()
        {
            var p = Reducto.Reducto.Parse("(x + 1)^2");

            Polynomial expected = new Polynomial();
            expected += new Polynomial(new Monomial(1));
            expected += new Polynomial(new Monomial(2, 1));
            expected += new Polynomial(new Monomial(1, 2));
            
            Assert.True(TestHelper.PolyEqual(expected,p));
        }
        [Test]
        public void Subject_Example_Hard_X()
        {
            var p = Reducto.Reducto.Parse("2 * x * 2 * x ^ 2 * 4 * 2 / x ^ 2 + 10*x");

            Polynomial expected = new Polynomial();
            expected += new Polynomial(new Monomial(42, 1));
            
            Assert.True(TestHelper.PolyEqual(expected,p));
        }
    }
    public class Reducto_Step_5_C_Error_Management
    {
        [Test]
        public void X_Power_Negative()
        {
            Assert.Throws<ArithmeticException>(() => Reducto.Reducto.Parse("x^(0-1)"));
        }
        [Test]
        public void X_Power_Unary_Negative()
        {
            Assert.Throws<ArithmeticException>(() => Reducto.Reducto.Parse("x^-1"));
        }
        [Test]
        public void X_Power_Negative_Bis()
        {
            Assert.Throws<ArithmeticException>(() => Reducto.Reducto.Parse("3*x^(0-1024) + 2"));
        }
        [Test]
        public void X_Power_X()
        {
            Assert.Throws<ArithmeticException>(() => Reducto.Reducto.Parse("x^x"));
        }
        [Test]
        public void Expr_Power_Expr()
        {
            Assert.Throws<ArithmeticException>(() => Reducto.Reducto.Parse("(x + 1)^(x^2 + 1)"));
        }
        [Test]
        public void Num_Power_X()
        {
            Assert.Throws<ArithmeticException>(() => Reducto.Reducto.Parse("2^x"));
        }
        [Test]
        public void Num_Power_Expr()
        {
            Assert.Throws<ArithmeticException>(() => Reducto.Reducto.Parse("2^(2*x + x^3)"));
        }
        [Test]
        public void MultiplePow()
        {
            Assert.Throws<ArgumentException>(() => Reducto.Reducto.Parse("4*x^^2"));
        }
        [Test]
        public void MultiplePow_Far()
        {
            Assert.Throws<ArgumentException>(() => Reducto.Reducto.Parse("x ^  ^ 2"));
        }
    }
}