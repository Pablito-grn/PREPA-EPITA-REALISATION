using System;
using NUnit.Framework;
using Reducto;

namespace TestReducto
{
    public class Reducto_Step_0_A_Empty
    {
        [Test]
        public void Nothing()
        {
            Assert.Throws<ArgumentException>(() => Reducto.Reducto.Parse(""));
        }
        
        [Test]
        public void OnlyWhiteSpace()
        {
            Assert.Throws<ArgumentException>(() => Reducto.Reducto.Parse("   "));
        }
    }
    public class Reducto_Step_0_B_PositiveNumber
    {
        [Test]
        public void Basic_Digit()
        {
            var p = Reducto.Reducto.Parse("3");

            Polynomial expected = new Polynomial();
            expected += new Polynomial(new Monomial(3));
            
            Assert.True(TestHelper.PolyEqual(expected,p));
        }
        
        [Test]
        public void Basic_TripleDigit()
        {
            var p = Reducto.Reducto.Parse("123");

            Polynomial expected = new Polynomial();
            expected += new Polynomial(new Monomial(123));
            
            Assert.True(TestHelper.PolyEqual(expected,p));
        }
        
        [Test]
        public void Basic_WhiteSpace_Begin()
        {
            var p = Reducto.Reducto.Parse("   123");

            Polynomial expected = new Polynomial();
            expected += new Polynomial(new Monomial(123));
            
            Assert.True(TestHelper.PolyEqual(expected,p));
        }
        
        [Test]
        public void Basic_WhiteSpace_End()
        {
            var p = Reducto.Reducto.Parse("123   ");

            Polynomial expected = new Polynomial();
            expected += new Polynomial(new Monomial(123));
            
            Assert.True(TestHelper.PolyEqual(expected,p));
        }
        
        [Test]
        public void Basic_WhiteSpace_BeginEnd()
        {
            var p = Reducto.Reducto.Parse("   123   ");

            Polynomial expected = new Polynomial();
            expected += new Polynomial(new Monomial(123));
            
            Assert.True(TestHelper.PolyEqual(expected,p));
        }
    }
    public class Reducto_Step_0_C_VariableOnly
    {
        [Test]
        public void Basic_Digit()
        {
            var p = Reducto.Reducto.Parse("x");

            Polynomial expected = new Polynomial();
            expected += new Polynomial(new Monomial(1, 1));
            
            Assert.True(TestHelper.PolyEqual(expected,p));
        }
        
        [Test]
        public void Basic_WhiteSpace_BeginEnd()
        {
            var p = Reducto.Reducto.Parse(" x   ");

            Polynomial expected = new Polynomial();
            expected += new Polynomial(new Monomial(1, 1));
            
            Assert.True(TestHelper.PolyEqual(expected,p));
        }
    }
    public class Reducto_Step_0_D_Error_Management
    {
        [Test]
        public void WrongVariable()
        {
            Assert.Throws<ArgumentException>(() => Reducto.Reducto.Parse("a"));
        }
        
        [Test]
        public void GoodAndWrongVariable()
        {
            Assert.Throws<ArgumentException>(() => Reducto.Reducto.Parse(" x  a"));
        }
    }
}