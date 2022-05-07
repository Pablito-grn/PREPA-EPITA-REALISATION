using System;

namespace Reducto
{
    public class Monomial
    {
        private readonly int _coef;
        private readonly int _degree;
        public bool IsZero => _coef == 0;
        public int Coef => _coef;
        public int Degree => _degree;

        // Constructor for Monomial
        // - A monomial of coefficient 0 is of degree -1
        // - A monomial of degree negative (and of coefficient different than 0) is an ArgumentException
        public Monomial(int coef, int degree = 0)
        {
            if (coef == 0)
            {
                _coef = coef;
                _degree = -1;
            }
            else
            {
                if (degree > -1)
                {
                    _coef = coef;
                    _degree = degree;
                }
                else
                    throw new ArgumentException();
            }
        }
        
        // Operator
        public static bool HasSameDegree(Monomial m1, Monomial m2)
        {

            //On evalue les degrés
            return m1.Degree == m2.Degree;
        }

        public static bool HasSameCoeff(Monomial m1, Monomial m2)
        {
            // On evalue les coeffs
            return m1.Coef == m2.Coef;
        }
        
        
        public static bool operator ==(Monomial m1, Monomial m2)
        {
            // on verifie les coeffs et les degrés
            return m1.Degree == m2.Degree && m1.Coef == m2.Coef; 
        }

        public static bool operator !=(Monomial m1, Monomial m2)
        {
            // on verifie les coeffs et les degrés
            return m1.Degree != m2.Degree || m1.Coef != m2.Coef; 
        }

        
        
        
        
        
        
        public static Monomial operator -(Monomial m)
        {
            //On mets le coef en negatif.
            return new Monomial((-1) * m.Coef, m.Degree);
        }
            
        public static Monomial operator +(Monomial m1, Monomial m2)
        {
            //On teste les coeff, degree et sinon on leve une exception
            if (HasSameDegree(m1, m2))
                if (m1.Coef == -m2.Coef)
                    return new Monomial(0, 0);    // On retourne le polynome null
                else
                    return new Monomial(m1.Coef+ m2.Coef, m1.Degree);
            else
            {
                if (m1.IsZero)
                    return new Monomial( m2.Coef, m2.Degree);
                if(m2.IsZero) 
                    return new Monomial(m1.Coef, m1.Degree);
            }
            throw new ArithmeticException();
        }

        public static Monomial operator -(Monomial m1, Monomial m2)
        {
            //On teste les coeff et sinon on leve une exception
            if (HasSameDegree(m1, m2))
            {
                if (HasSameCoeff(m1, m2)) return new Monomial(0, -1);
                return new Monomial(m1.Coef - m2.Coef, m1.Degree);
            }
           
            if (m1.IsZero)
                return new Monomial( -m2.Coef, m2.Degree);
            if(m2.IsZero) 
                return new Monomial(m1.Coef, m1.Degree);
            
            throw new ArithmeticException();
        }
        
        public static Monomial operator *(Monomial m1, Monomial m2)
        {
            //Produit des coefs et somme des degs
            return new Monomial(m1.Coef*m2.Coef, m1.Degree + m2.Degree);
        }

        public static Monomial operator /(Monomial m1, Monomial m2)
        {
            if (m2._coef == 0)
                throw new ArithmeticException();
            
            if (m1._coef == 0)
                return new Monomial(0);
            
            return new Monomial(m1.Coef/m2.Coef, m1.Degree - m2.Degree);
          
        }
    }
}