using System;
using NUnit.Framework;
using Reducto;

namespace TestReducto
{
    public class Reducto_Step_2_A_NumberOnly_Mult
    {
        [Test]
        public void NumberOnly_Mult_Lot()
        {
            var p = Reducto.Reducto.Parse("1*3  *2 *3");

            Polynomial expected = new Polynomial();
            expected += new Polynomial(new Monomial(18));
            
            Assert.True(TestHelper.PolyEqual(expected,p));
        }
        
        [Test]
        public void NumberOnly_Mult_Zero()
        {
            var p = Reducto.Reducto.Parse(" 1*0");

            Polynomial expected = new Polynomial();
            expected += new Polynomial(new Monomial(0));
            
            Assert.True(TestHelper.PolyEqual(expected,p));
        }
        [Test]
        public void NumberOnly_Mult_Zero_Long()
        {
            var p = Reducto.Reducto.Parse(" 1*0 *12345678 * 42");

            Polynomial expected = new Polynomial();
            expected += new Polynomial(new Monomial(0));
            
            Assert.True(TestHelper.PolyEqual(expected,p));
        }
    }
    public class Reducto_Step_2_B_NumberOnly_MultDiv
    {
        [Test]
        public void NumberOnly_DivOnly()
        {
            var p = Reducto.Reducto.Parse("8/2");

            Polynomial expected = new Polynomial();
            expected += new Polynomial(new Monomial(4));
            
            Assert.True(TestHelper.PolyEqual(expected,p));
        }
        [Test]
        public void NumberOnly_Mult_Lot()
        {
            var p = Reducto.Reducto.Parse("8/2*3");

            Polynomial expected = new Polynomial();
            expected += new Polynomial(new Monomial(12));
            
            Assert.True(TestHelper.PolyEqual(expected,p));
        }
        
        [Test]
        public void NumberOnly_Mult_Zero()
        {
            var p = Reducto.Reducto.Parse(" 46*5/ 46  / 5");

            Polynomial expected = new Polynomial();
            expected += new Polynomial(new Monomial(1));
            
            Assert.True(TestHelper.PolyEqual(expected,p));
        }
    }
    public class Reducto_Step_2_C_NumberOnly_Mix
    {
        [Test]
        public void NotTrick()
        {
            var p = Reducto.Reducto.Parse("2*3 + 7");

            Polynomial expected = new Polynomial();
            expected += new Polynomial(new Monomial(2*3 + 7));
            
            Assert.True(TestHelper.PolyEqual(expected,p));
        }
        [Test]
        public void PriorityTrick()
        {
            var p = Reducto.Reducto.Parse("7 + 2*3");

            Polynomial expected = new Polynomial();
            expected += new Polynomial(new Monomial(7 + 2*3));
            
            Assert.True(TestHelper.PolyEqual(expected,p));
        }
        
        [Test]
        public void PriorityTrick_Mix()
        {
            var p = Reducto.Reducto.Parse("7 + 2*3 -2/2  + 14-2*3");

            Polynomial expected = new Polynomial();
            expected += new Polynomial(new Monomial(7 + 2*3 -2/2 +  14-2*3));
            
            Assert.True(TestHelper.PolyEqual(expected,p));
        }
    }
    public class Reducto_Step_2_D_WithVariable
    {
        [Test]
        public void SimpleMult_WithNumber()
        {
            var p = Reducto.Reducto.Parse("2*x");

            Polynomial expected = new Polynomial();
            expected += new Polynomial(new Monomial(2, 1));
            
            Assert.True(TestHelper.PolyEqual(expected,p));
        }
        
        [Test]
        public void SimpleMult_WithVariable()
        {
            var p = Reducto.Reducto.Parse("x*x*x");

            Polynomial expected = new Polynomial();
            expected += new Polynomial(new Monomial(1, 3));
            
            Assert.True(TestHelper.PolyEqual(expected,p));
        }
        
        [Test]
        public void Hard_NoDiv()
        {
            var p = Reducto.Reducto.Parse("2*x + 7 - x *x");

            Polynomial expected = new Polynomial();
            expected += new Polynomial(new Monomial(7));
            expected += new Polynomial(new Monomial(2, 1));
            expected += new Polynomial(new Monomial(-1, 2));
            
            Assert.True(TestHelper.PolyEqual(expected,p));
        }
    }
    public class Reducto_Step_2_E_Error_Management
    {
        [Test]
        public void DivByZero_Number()
        {
            Assert.Throws<ArithmeticException>(() => Reducto.Reducto.Parse("3- 4 / 0"));
        }
        [Test]
        public void DivByZero_Variable()
        {
            Assert.Throws<ArithmeticException>(() => Reducto.Reducto.Parse("x / 0"));
        }
        
        [Test]
        public void MultipleMult()
        {
            Assert.Throws<ArgumentException>(() => Reducto.Reducto.Parse("4*x**2"));
        }
        [Test]
        public void MultipleMult_Far()
        {
            Assert.Throws<ArgumentException>(() => Reducto.Reducto.Parse("x *  * 2"));
        }
        
        [Test]
        public void MultipleDiv()
        {
            Assert.Throws<ArgumentException>(() => Reducto.Reducto.Parse("4*x//2"));
        }
        [Test]
        public void MultipleDiv_Far()
        {
            Assert.Throws<ArgumentException>(() => Reducto.Reducto.Parse("4*x / / 2"));
        }
        [Test]
        public void LeadingOperator_Mult()
        {
            Assert.Throws<ArgumentException>(() => Reducto.Reducto.Parse(" * 1 + 2 + 3 "));
        }
        [Test]
        public void LeadingOperator_Div()
        {
            Assert.Throws<ArgumentException>(() => Reducto.Reducto.Parse(" / 1 + 2 + 3 "));
        }
        [Test]
        public void TrailingOperator_Mult()
        {
            Assert.Throws<ArgumentException>(() => Reducto.Reducto.Parse(" 1 + 2 + 3 * "));
        }
        [Test]
        public void TrailingOperator_Div()
        {
            Assert.Throws<ArgumentException>(() => Reducto.Reducto.Parse(" 1 + 2 + 3 / "));
        }
    }
    public class Reducto_Step_2_F_BONUS_Implicit_Multiplication
    {
        [Test]
        public void ImplicitMult_VarAfterNumber()
        {
            var p = Reducto.Reducto.Parse("2x");

            Polynomial expected = new Polynomial();
            expected += new Polynomial(new Monomial(2, 1));
            
            Assert.True(TestHelper.PolyEqual(expected,p));
        }
        [Test]
        public void ImplicitMult_NumberAfterVar()
        {
            var p = Reducto.Reducto.Parse("x2");

            Polynomial expected = new Polynomial();
            expected += new Polynomial(new Monomial(2, 1));
            
            Assert.True(TestHelper.PolyEqual(expected,p));
        }
        [Test]
        public void ImplicitMult_Hard()
        {
            var p = Reducto.Reducto.Parse("x3x4x");

            Polynomial expected = new Polynomial();
            expected += new Polynomial(new Monomial(12, 3));
            
            Assert.True(TestHelper.PolyEqual(expected,p));
        }
    }
}