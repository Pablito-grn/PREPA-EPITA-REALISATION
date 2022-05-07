using NUnit.Framework;
using Reducto;

namespace TestReducto
{
    public class Reducto_Step_4_A_Unary_NumberOnly_OneNumber
    {
        [Test]
        public void Minus_Simple()
        {
            var p = Reducto.Reducto.Parse("-3");

            Polynomial expected = new Polynomial();
            expected += new Polynomial(new Monomial(-3));
            
            Assert.True(TestHelper.PolyEqual(expected,p));
        }
        [Test]
        public void Plus_Simple()
        {
            var p = Reducto.Reducto.Parse("+3");

            Polynomial expected = new Polynomial();
            expected += new Polynomial(new Monomial(3));
            
            Assert.True(TestHelper.PolyEqual(expected,p));
        }
        [Test]
        public void Minus_Multiple_Even()
        {
            var p = Reducto.Reducto.Parse("--------3");

            Polynomial expected = new Polynomial();
            expected += new Polynomial(new Monomial(3));
            
            Assert.True(TestHelper.PolyEqual(expected,p));
        }
        [Test]
        public void Minus_Multiple_Odd()
        {
            var p = Reducto.Reducto.Parse("-------3");

            Polynomial expected = new Polynomial();
            expected += new Polynomial(new Monomial(-3));
            
            Assert.True(TestHelper.PolyEqual(expected,p));
        }
        [Test]
        public void Plus_Multiple()
        {
            var p = Reducto.Reducto.Parse("+++++3");

            Polynomial expected = new Polynomial();
            expected += new Polynomial(new Monomial(3));
            
            Assert.True(TestHelper.PolyEqual(expected,p));
        }
        [Test]
        public void Mix_Simple()
        {
            var p = Reducto.Reducto.Parse("+-3");

            Polynomial expected = new Polynomial();
            expected += new Polynomial(new Monomial(-3));
            
            Assert.True(TestHelper.PolyEqual(expected,p));
        }
        [Test]
        public void Mix_Simple_Bis()
        {
            var p = Reducto.Reducto.Parse("-+3");

            Polynomial expected = new Polynomial();
            expected += new Polynomial(new Monomial(-3));
            
            Assert.True(TestHelper.PolyEqual(expected,p));
        }
        [Test]
        public void Minus_Parenthesis()
        {
            var p = Reducto.Reducto.Parse("-(3)");

            Polynomial expected = new Polynomial();
            expected += new Polynomial(new Monomial(-3));
            
            Assert.True(TestHelper.PolyEqual(expected,p));
        }
        [Test]
        public void Plus_Parenthesis()
        {
            var p = Reducto.Reducto.Parse("+(3)");

            Polynomial expected = new Polynomial();
            expected += new Polynomial(new Monomial(3));
            
            Assert.True(TestHelper.PolyEqual(expected,p));
        }
    }
    public class Reducto_Step_4_B_Unary_NumberOnly_MultipleNumber
    {
        [Test]
        public void Mult_Negative_Right()
        {
            var p = Reducto.Reducto.Parse("2*-2");

            Polynomial expected = new Polynomial();
            expected += new Polynomial(new Monomial(-4));
            
            Assert.True(TestHelper.PolyEqual(expected,p));
        }
        [Test]
        public void Mult_Negative_Left()
        {
            var p = Reducto.Reducto.Parse("-2*2");

            Polynomial expected = new Polynomial();
            expected += new Polynomial(new Monomial(-4));
            
            Assert.True(TestHelper.PolyEqual(expected,p));
        }
        [Test]
        public void Mix_All()
        {
            var p = Reducto.Reducto.Parse("---2*-2 + 10 / -2 * ++3 ++1");

            Polynomial expected = new Polynomial();
            expected += new Polynomial(new Monomial(-10));
            
            Assert.True(TestHelper.PolyEqual(expected,p));
        }
    }
    public class Reducto_Step_4_B_Unary_WithVariable
    {
        [Test]
        public void Mult_Negative_Right()
        {
            var p = Reducto.Reducto.Parse("2*-x");

            Polynomial expected = new Polynomial();
            expected += new Polynomial(new Monomial(-2, 1));
            
            Assert.True(TestHelper.PolyEqual(expected,p));
        }
        [Test]
        public void Mult_Negative_Left()
        {
            var p = Reducto.Reducto.Parse("-x*2");

            Polynomial expected = new Polynomial();
            expected += new Polynomial(new Monomial(-2, 1));
            
            Assert.True(TestHelper.PolyEqual(expected,p));
        }
        [Test]
        public void Mix_All()
        {
            var p = Reducto.Reducto.Parse("---x*-x + 10 / -2 * ++3 * x ++x * +7*x * +x");

            Polynomial expected = new Polynomial();
            expected += new Polynomial(new Monomial(-15, 1));
            expected += new Polynomial(new Monomial(1, 2));
            expected += new Polynomial(new Monomial(7, 3));
            
            Assert.True(TestHelper.PolyEqual(expected,p));
        }
    }
}