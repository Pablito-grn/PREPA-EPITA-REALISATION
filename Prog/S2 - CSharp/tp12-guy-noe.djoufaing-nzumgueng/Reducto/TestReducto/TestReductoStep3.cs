using System;
using NUnit.Framework;
using Reducto;

namespace TestReducto
{
    public class Reducto_Step_3_A_Parenthesis_Alone
    {
        [Test]
        public void NumberOnly_SinglePair()
        {
            var p = Reducto.Reducto.Parse("(3)");

            Polynomial expected = new Polynomial();
            expected += new Polynomial(new Monomial(3));
            
            Assert.True(TestHelper.PolyEqual(expected,p));
        }
        
        [Test]
        public void NumberOnly_WhiteSpace()
        {
            var p = Reducto.Reducto.Parse(" (  4)  ");

            Polynomial expected = new Polynomial();
            expected += new Polynomial(new Monomial(4));
            
            Assert.True(TestHelper.PolyEqual(expected,p));
        }
        
        [Test]
        public void NumberOnly_TriplePair()
        {
            var p = Reducto.Reducto.Parse("(((610)    )   )");

            Polynomial expected = new Polynomial();
            expected += new Polynomial(new Monomial(610));
            
            Assert.True(TestHelper.PolyEqual(expected,p));
        }
    }
    public class Reducto_Step_3_B_Parenthesis_Operation_NumberOnly
    {
        [Test]
        public void NumberOnly_DivOnly()
        {
            var p = Reducto.Reducto.Parse("((8)/(2))");

            Polynomial expected = new Polynomial();
            expected += new Polynomial(new Monomial(4));
            
            Assert.True(TestHelper.PolyEqual(expected,p));
        }
        [Test]
        public void NumberOnly_Right()
        {
            var p = Reducto.Reducto.Parse("18/(2*3)");

            Polynomial expected = new Polynomial();
            expected += new Polynomial(new Monomial(18/(2*3)));
            
            Assert.True(TestHelper.PolyEqual(expected,p));
        }
        
        [Test]
        public void NumberOnly_Left()
        {
            var p = Reducto.Reducto.Parse("(1 + 3) * 8");

            Polynomial expected = new Polynomial();
            expected += new Polynomial(new Monomial((1 + 3) * 8));
            
            Assert.True(TestHelper.PolyEqual(expected,p));
        }
        [Test]
        public void NumberOnly_Both()
        {
            var p = Reducto.Reducto.Parse(" ((46*5)/ (46  / 5) )");

            Polynomial expected = new Polynomial();
            expected += new Polynomial(new Monomial(46*5/ (46  / 5)));
            
            Assert.True(TestHelper.PolyEqual(expected,p));
        }
    }
    public class Reducto_Step_3_C_Parenthesis_Operation_WithVariable
    {
        [Test]
        public void TonsOfParenthesis()
        {
            var p = Reducto.Reducto.Parse("(((((x))+(1)) ))");

            Polynomial expected = new Polynomial();
            expected += new Polynomial(new Monomial(1));
            expected += new Polynomial(new Monomial(1, 1));
            
            Assert.True(TestHelper.PolyEqual(expected,p));
        }
        [Test]
        public void MultBetweenParenthesis()
        {
            var p = Reducto.Reducto.Parse("((8 + x)*(2))");

            Polynomial expected = new Polynomial();
            expected += new Polynomial(new Monomial(16));
            expected += new Polynomial(new Monomial(2, 1));
            
            Assert.True(TestHelper.PolyEqual(expected,p));
        }
        [Test]
        public void DivBetweenParenthesis_Wikipedia()
        {
            var p = Reducto.Reducto.Parse("(x*x*x-2*x*x-4)/(x - 3)");

            Polynomial expected = new Polynomial();
            expected += new Polynomial(new Monomial(3));
            expected += new Polynomial(new Monomial(1, 1));
            expected += new Polynomial(new Monomial(1, 2));
            Assert.True(TestHelper.PolyEqual(expected,p));
        }
    }
    public class Reducto_Step_3_D_Error_Management
    {
        [Test]
        public void OneDangling_Left()
        {
            Assert.Throws<ArgumentException>(() => Reducto.Reducto.Parse("x+ 1 - ( 1-x"));
        }
        [Test]
        public void OneDangling_Right()
        {
            Assert.Throws<ArgumentException>(() => Reducto.Reducto.Parse("x+ 1 - ) 1-x"));
        }
        [Test]
        public void OneDangling_Left_Begin()
        {
            Assert.Throws<ArgumentException>(() => Reducto.Reducto.Parse(" (x+ 1 - 1-x"));
        }
        [Test]
        public void OneDangling_Right_End()
        {
            Assert.Throws<ArgumentException>(() => Reducto.Reducto.Parse("x+ 1 - 1-x)  "));
        }
        [Test]
        public void OneDangling_AmongOther_Left()
        {
            Assert.Throws<ArgumentException>(() => Reducto.Reducto.Parse("x+ (1 - ( 1-x)* 4"));
        }
        [Test]
        public void OneDangling_AmongOther_Right()
        {
            Assert.Throws<ArgumentException>(() => Reducto.Reducto.Parse("x+ (1 - ) 1-x) *3"));
        }
        [Test]
        public void MultipleDangling_AmongOther_Left()
        {
            Assert.Throws<ArgumentException>(() => Reducto.Reducto.Parse("(x+ (1 - ((( 1-x)* 4)"));
        }
        [Test]
        public void MultipleDangling_AmongOther_Right()
        {
            Assert.Throws<ArgumentException>(() => Reducto.Reducto.Parse("(x+ (1 - ))) 1-x) *3)"));
        }
    }
    public class Reducto_Step_3_E_BONUS_Implicit_Multiplication
    {
        [Test]
        public void NumberOnly_LeftImplicit()
        {
            var p = Reducto.Reducto.Parse("2(x + 1)");

            Polynomial expected = new Polynomial();
            expected += new Polynomial(new Monomial(2));
            expected += new Polynomial(new Monomial(2, 1));
            
            Assert.True(TestHelper.PolyEqual(expected,p));
        }
        [Test]
        public void NumberOnly_RightImplicit()
        {
            var p = Reducto.Reducto.Parse("(x + 1)2");

            Polynomial expected = new Polynomial();
            expected += new Polynomial(new Monomial(2));
            expected += new Polynomial(new Monomial(2, 1));
            
            Assert.True(TestHelper.PolyEqual(expected,p));
        }
        [Test]
        public void NumberOnly_LeftImplicit_Hard()
        {
            var p = Reducto.Reducto.Parse("10(2((x + 1)))");

            Polynomial expected = new Polynomial();
            expected += new Polynomial(new Monomial(20));
            expected += new Polynomial(new Monomial(20, 1));
            
            Assert.True(TestHelper.PolyEqual(expected,p));
        }
        [Test]
        public void NumberOnly_RightImplicit_Hard()
        {
            var p = Reducto.Reducto.Parse("(((x + 1))2)10");

            Polynomial expected = new Polynomial();
            expected += new Polynomial(new Monomial(20));
            expected += new Polynomial(new Monomial(20, 1));
            
            Assert.True(TestHelper.PolyEqual(expected,p));
        }
        [Test]
        public void NumberOnly_both()
        {
            var p = Reducto.Reducto.Parse("3*(x*x + 5*x - 7) * 2");

            Polynomial expected = new Polynomial();
            expected += new Polynomial(new Monomial(-42));
            expected += new Polynomial(new Monomial(30, 1));
            expected += new Polynomial(new Monomial(6, 2));
            
            Assert.True(TestHelper.PolyEqual(expected,p));
        }
    }
}