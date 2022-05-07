using System;
using NUnit.Framework;
using Reducto;

namespace TestReducto
{
    public class Reducto_Step_1_A_NumberOnly_Addition
    {
        [Test]
        public void NumberOnly_Add_NoWhiteSpace_TwoMembers()
        {
            var p = Reducto.Reducto.Parse("1+3");

            Polynomial expected = new Polynomial();
            expected += new Polynomial(new Monomial(4));
            
            Assert.True(TestHelper.PolyEqual(expected,p));
        }
        
        [Test]
        public void NumberOnly_Add_WithWhiteSpace_TwoMembers()
        {
            var p = Reducto.Reducto.Parse(" 1 + 3 ");

            Polynomial expected = new Polynomial();
            expected += new Polynomial(new Monomial(4));
            
            Assert.True(TestHelper.PolyEqual(expected,p));
        }
        
        [Test]
        public void NumberOnly_Add_WithWhiteSpace_ALotOfMembers()
        {
            var p = Reducto.Reducto.Parse(" 1+3+1+3+5");

            Polynomial expected = new Polynomial();
            expected += new Polynomial(new Monomial(13));
            
            Assert.True(TestHelper.PolyEqual(expected,p));
        }
    }
    public class Reducto_Step_1_B_NumberOnly_Minus
    {
        [Test]
        public void NumberOnly_Minus_NoWhiteSpace_TwoMembers()
        {
            var p = Reducto.Reducto.Parse("1-3");

            Polynomial expected = new Polynomial();
            expected += new Polynomial(new Monomial(-2));
            
            Assert.True(TestHelper.PolyEqual(expected,p));
        }
        
        [Test]
        public void NumberOnly_Minus_WithWhiteSpace_TwoMembers()
        {
            var p = Reducto.Reducto.Parse(" 1 - 3 ");

            Polynomial expected = new Polynomial();
            expected += new Polynomial(new Monomial(-2));
            
            Assert.True(TestHelper.PolyEqual(expected,p));
        }
        
        [Test]
        public void NumberOnly_Minus_WithWhiteSpace_ALotOfMembers()
        {
            var p = Reducto.Reducto.Parse(" 1 - 3- 1 - 3 - 5");

            Polynomial expected = new Polynomial();
            expected += new Polynomial(new Monomial(-11));
            
            Assert.True(TestHelper.PolyEqual(expected,p));
        }
    }
    public class Reducto_Step_1_C_NumberOnly_Mix_Addition_Substraction
    {
        [Test]
        public void NumberOnly_Mix_AS_1()
        {
            var p = Reducto.Reducto.Parse("1-3+2+3");

            Polynomial expected = new Polynomial();
            expected += new Polynomial(new Monomial(3));
            
            Assert.True(TestHelper.PolyEqual(expected,p));
        }
        
        [Test]
        public void NumberOnly_Mix_AS_2()
        {
            var p = Reducto.Reducto.Parse(" 1 - 3+2");

            Polynomial expected = new Polynomial();
            expected += new Polynomial(new Monomial(0));
            
            Assert.True(TestHelper.PolyEqual(expected,p));
        }
    }
    public class Reducto_Step_1_D_WithVariable
    {
        [Test]
        public void SimpleAddition()
        {
            var p = Reducto.Reducto.Parse("1+ x");

            Polynomial expected = new Polynomial();
            expected += new Polynomial(new Monomial(1, 0));
            expected += new Polynomial(new Monomial(1, 1));
            
            Assert.True(TestHelper.PolyEqual(expected,p));
        }
        
        [Test]
        public void Mix_Result_Mix()
        {
            var p = Reducto.Reducto.Parse("1+ x + 4-x-x");

            Polynomial expected = new Polynomial();
            expected += new Polynomial(new Monomial(5, 0));
            expected += new Polynomial(new Monomial(-1, 1));
            
            Assert.True(TestHelper.PolyEqual(expected,p));
        }
        
        [Test]
        public void Mix_Result_OnlyNumber()
        {
            var p = Reducto.Reducto.Parse("x + 1 -x");

            Polynomial expected = new Polynomial();
            expected += new Polynomial(new Monomial(1, 0));
            
            Assert.True(TestHelper.PolyEqual(expected,p));
        }
        
        [Test]
        public void Mix_Result_OnlyVariable()
        {
            var p = Reducto.Reducto.Parse("2 + x -2 + x");

            Polynomial expected = new Polynomial();
            expected += new Polynomial(new Monomial(2, 1));
            
            Assert.True(TestHelper.PolyEqual(expected,p));
        }
    }
    public class Reducto_Step_1_E_Error_Management
    {
        [Test]
        public void DoubleNumber()
        {
            Assert.Throws<ArgumentException>(() => Reducto.Reducto.Parse("1 4+ x"));
        }
        [Test]
        public void DoubleVariable()
        {
            Assert.Throws<ArgumentException>(() => Reducto.Reducto.Parse("1+ x x"));
        }
        [Test]
        public void TrailingOperator_Plus()
        {
            Assert.Throws<ArgumentException>(() => Reducto.Reducto.Parse("1 - 3 +"));
        }
        [Test]
        public void TrailingOperator_Minus()
        {
            Assert.Throws<ArgumentException>(() => Reducto.Reducto.Parse("1 - 3 -"));
        }
    }
}