using System;
using NUnit.Framework;
using Reducto;

namespace TestReducto
{
    public class Monomial_A_Constructor
    {
        [Test]
        public void NothingSpecial_NoThrow()
        {
            Monomial m1 = new Monomial(1, 2);
            Assert.Pass();
        }
        [Test]
        public void DegreeZero_NoThrow()
        {
            Monomial m1 = new Monomial(1, 0);
            Assert.Pass();
        }
        [Test]
        public void Zero_Default_NoThrow()
        {
            Monomial m1 = new Monomial(0);
            Assert.Pass();
        }
        [Test]
        public void Zero_PositiveDegree_NoThrow()
        {
            Monomial m1 = new Monomial(0, 10);
            Assert.Pass();
        }
        [Test]
        public void Zero_NegativeDegree_NoThrow()
        {
            Monomial m1 = new Monomial(0, -10);
            Assert.Pass();
        }
        [Test]
        public void NegativeCoef_MustThrow_MinusFour()
        {
            Assert.Throws<ArgumentException>(() => new Monomial(1, -4));
        }
        [Test]
        public void NegativeCoef_MustThrow_MinusOne()
        {
            Assert.Throws<ArgumentException>(() => new Monomial(7, -1));
        }
    }
    public class Monomial_B_Equality
    {
        [Test]
        public void BasicEqual()
        {
            Monomial m1 = new Monomial(1, 2);
            Monomial m2 = new Monomial(1, 2);
            Assert.True(m1 == m2);
            Assert.False(m1 != m2);
        }
        
        [Test]
        public void BasicNotEqual()
        {
            Monomial m1 = new Monomial(1, 2);
            Monomial m2 = new Monomial(3, 10);
            Assert.True(m1 != m2);
            Assert.False(m1 == m2);
        }
        
        [Test]
        public void SameCoefNotEqual()
        {
            Monomial m1 = new Monomial(1, 2);
            Monomial m2 = new Monomial(1, 10);
            Assert.True(m1 != m2);
            Assert.False(m1 == m2);
        }
        
        [Test]
        public void SameDegreeNotEqual()
        {
            Monomial m1 = new Monomial(1, 2);
            Monomial m2 = new Monomial(3, 2);
            Assert.True(m1 != m2);
            Assert.False(m1 == m2);
        }
    }
    public class Monomial_C_Add
    {
        [Test]
        public void SameDegree()
        {
            Monomial m1 = new Monomial(1, 2);
            Monomial m2 = new Monomial(4, 2);

            Monomial expected = new Monomial(5, 2);
            Assert.True(m1 + m2 == expected);
        }
        
        [Test]
        public void SameDegree_NegativeCoef()
        {
            Monomial m1 = new Monomial(1, 2);
            Monomial m2 = new Monomial(-4, 2);

            Monomial expected = new Monomial(-3, 2);
            Assert.True(m1 + m2 == expected);
        }

        private static void TestAddMonomial(Monomial m1, Monomial m2)
        {
            Monomial m = m1 + m2;
        }
        
        [Test]
        public void DifferentDegree_Basic()
        {
            Monomial m1 = new Monomial(1, 2);
            Monomial m2 = new Monomial(2, 1);


            Assert.Throws<ArithmeticException>(() => TestAddMonomial(m1, m2));
        }
        [Test]
        public void DifferentDegree_Zero_CoefNotZero()
        {
            Monomial m1 = new Monomial(1, 2);
            Monomial m2 = new Monomial(3, 0);


            Assert.Throws<ArithmeticException>(() => TestAddMonomial(m1, m2));
        }
        
        [Test]
        public void SameDegree_Zero_CoefZero()
        {
            Monomial m1 = new Monomial(1, 2);
            Monomial m2 = new Monomial(0, 10);

            Monomial expected = new Monomial(1, 2);
            Assert.True(m1 + m2 == expected);
        }
        
        [Test]
        public void SameDegree_Zero_CoefZero_Reversed()
        {
            Monomial m1 = new Monomial(1, 2);
            Monomial m2 = new Monomial(0, 10);

            Monomial expected = new Monomial(1, 2);
            Assert.True(m2 + m1 == expected);
        }
    }
    public class Monomial_D_UnaryMinus
    {
        [Test]
        public void Simple()
        {
            Monomial m1 = new Monomial(1, 2);

            Monomial expected = new Monomial(-1, 2);
            Assert.True(-m1 == expected);
        }
        
        [Test]
        public void Simple_DegreeZero()
        {
            Monomial m1 = new Monomial(14, 0);

            Monomial expected = new Monomial(-14, 0);
            Assert.True(-m1 == expected);
        }
        [Test]
        public void Simple_CoefZero()
        {
            Monomial m1 = new Monomial(0, 3);

            Monomial expected = new Monomial(0, 3);
            Assert.True(-m1 == expected);
        }
        
        [Test]
        public void Simple_Nagative()
        {
            Monomial m1 = new Monomial(-2, 3);

            Monomial expected = new Monomial(2, 3);
            Assert.True(-m1 == expected);
        }
    }
    public class Monomial_E_BinaryMinus
    {
        [Test]
        public void SameDegree()
        {
            Monomial m1 = new Monomial(1, 2);
            Monomial m2 = new Monomial(4, 2);

            Monomial expected = new Monomial(-3, 2);
            Assert.True(m1 - m2 == expected);
        }
        
        [Test]
        public void SameDegree_NegativeCoef()
        {
            Monomial m1 = new Monomial(1, 2);
            Monomial m2 = new Monomial(-4, 2);

            Monomial expected = new Monomial(5, 2);
            Assert.True(m1 - m2 == expected);
        }

        public void TestAddMonomial(Monomial m1, Monomial m2)
        {
            Monomial m = m1 - m2;
        }
        
        [Test]
        public void DifferentDegree_Basic()
        {
            Monomial m1 = new Monomial(1, 2);
            Monomial m2 = new Monomial(2, 1);


            Assert.Throws<ArithmeticException>(() => TestAddMonomial(m1, m2));
        }
        [Test]
        public void DifferentDegree_Zero_CoefNotZero()
        {
            Monomial m1 = new Monomial(1, 2);
            Monomial m2 = new Monomial(3, 0);


            Assert.Throws<ArithmeticException>(() => TestAddMonomial(m1, m2));
        }
        
        [Test]
        public void SameDegree_Zero_CoefZero()
        {
            Monomial m1 = new Monomial(1, 2);
            Monomial m2 = new Monomial(0, 10);

            Monomial expected = new Monomial(1, 2);
            Assert.True(m1 - m2 == expected);
        }
        
        [Test]
        public void SameDegree_Zero_CoefZero_Reversed()
        {
            Monomial m1 = new Monomial(0, 10);
            Monomial m2 = new Monomial(1, 2);

            Monomial expected = new Monomial(-1, 2);
            Assert.True(m1 - m2 == expected);
        }
    }
    public class Monomial_F_Mult
    {
        [Test]
        public void SameDegree()
        {
            Monomial m1 = new Monomial(7, 3);
            Monomial m2 = new Monomial(4, 3);

            Monomial expected = new Monomial(28, 6);
            Assert.True(m1 * m2 == expected);
        }
        
        [Test]
        public void SameDegree_NegativeCoef()
        {
            Monomial m1 = new Monomial(7, 3);
            Monomial m2 = new Monomial(-4, 3);

            Monomial expected = new Monomial(-28, 6);
            Assert.True(m1 * m2 == expected);
        }

        [Test]
        public void DifferentDegree()
        {
            Monomial m1 = new Monomial(7, 2);
            Monomial m2 = new Monomial(4, 3);

            Monomial expected = new Monomial(28, 5);
            Assert.True(m1 * m2 == expected);
        }
        
        [Test]
        public void DifferentDegree_NegativeCoef()
        {
            Monomial m1 = new Monomial(7, 2);
            Monomial m2 = new Monomial(-4, 3);

            Monomial expected = new Monomial(-28, 5);
            Assert.True(m1 * m2 == expected);
        }
        
        [Test]
        public void SameDegree_Zero_CoefZero()
        {
            Monomial m1 = new Monomial(1, 2);
            Monomial m2 = new Monomial(0, 10);

            Monomial expected = new Monomial(0, 0);
            Assert.True(m1 * m2 == expected);
        }
        
        [Test]
        public void SameDegree_Zero_CoefZero_Reversed()
        {
            Monomial m1 = new Monomial(1, 2);
            Monomial m2 = new Monomial(0, 10);

            Monomial expected = new Monomial(0, 0);
            Assert.True(m2 * m1 == expected);
        }
        
        [Test]
        public void SameDegree_Zero_Both()
        {
            Monomial m1 = new Monomial(0, 2);
            Monomial m2 = new Monomial(0, 10);

            Monomial expected = new Monomial(0, 0);
            Assert.True(m1 * m2 == expected);
        }
    }
    public class Monomial_G_Div
    {
        [Test]
        public void Simple()
        {
            Monomial m1 = new Monomial(8, 2);
            Monomial m2 = new Monomial(2, 0);
            Monomial expected = new Monomial(4, 2);
            Assert.True(m1 / m2 == expected);
        }
        
        [Test]
        public void Simple_TrickDivision()
        {
            Monomial m1 = new Monomial(8, 2);
            Monomial m2 = new Monomial(3, 0);
            Monomial expected = new Monomial(8/3, 2);
            Assert.True(m1 / m2 == expected);
        }
        
        [Test]
        public void Simple_TrickDivision_Bis()
        {
            Monomial m1 = new Monomial(8, 2);
            Monomial m2 = new Monomial(11, 0);
            Monomial expected = new Monomial(8/11, 2);
            Assert.True(m1 / m2 == expected);
        }
        
        [Test]
        public void Simple_BothDegree()
        {
            Monomial m1 = new Monomial(8, 5);
            Monomial m2 = new Monomial(4, 5);
            Monomial expected = new Monomial(2, 0);
            Assert.True(m1 / m2 == expected);
        }
        
        [Test]
        public void Simple_BothDegree_Zero()
        {
            Monomial m1 = new Monomial(8, 0);
            Monomial m2 = new Monomial(4, 0);
            Monomial expected = new Monomial(2, 0);
            Assert.True(m1 / m2 == expected);
        }

        public void TestDivMonomial(Monomial m1, Monomial m2)
        {
            Monomial m = m1 / m2;
        }
        
        [Test]
        public void ZeroDivision_Left()
        {
            Monomial m1 = new Monomial(0, 2);
            Monomial m2 = new Monomial(4, 1);
            Monomial expected = new Monomial(0);
            Assert.True(m1 / m2 == expected);
        }
        
        [Test]
        public void ZeroDivision_Right()
        {
            Monomial m1 = new Monomial(4, 2);
            Monomial m2 = new Monomial(0, 1);
            Assert.Throws<ArithmeticException>(() => TestDivMonomial(m1, m2));
        }
        
        [Test]
        public void ZeroDivision_Both()
        {
            Monomial m1 = new Monomial(0, 2);
            Monomial m2 = new Monomial(0, 1);
            Assert.Throws<ArithmeticException>(() => TestDivMonomial(m1, m2));
        }
    }
}