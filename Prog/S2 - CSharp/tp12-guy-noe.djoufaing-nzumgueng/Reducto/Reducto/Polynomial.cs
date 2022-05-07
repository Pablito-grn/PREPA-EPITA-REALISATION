using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Reducto
{
    public class Polynomial
    {
        // List of monomials
        private List<Monomial> _monomials = new List<Monomial>();
        public ReadOnlyCollection<Monomial> Monomials => _monomials.AsReadOnly(); // Don't delete this line
        private bool IsZero => _monomials.Count == 0;

        
        // Constructor
        public Polynomial()
        {
            //initialisation de la liste
            //_monomials = new List<Monomial>();
        }

        public Polynomial(Monomial m)
        {

            //initialisation de la liste avec des arguments
            if(m.IsZero == false) _monomials.Add(m);

        }
        
        // ===== Operator overload =====
        
        // Unary -
        public static Polynomial operator -(Polynomial p)
        {
            for (var i = 0; i < p.Monomials.Count; i++)
            {
                p._monomials[i] = -p.Monomials[i];
            }

            return p;
        }


        public static Polynomial AddMonoList(List<Monomial> pl)
        {
            List<Monomial> l1 = new List<Monomial>(pl);
            Polynomial pRes = new Polynomial();

            Monomial tmp;
            for (var i = 0; i < l1.Count; i++)
            {
                tmp = l1[i];
                for (int j = i+1; j < l1.Count; j++)
                {
                    if (Monomial.HasSameDegree(l1[i], l1[j]))
                    {
                        tmp += l1[j];
                        l1.RemoveAt(j); // on supprime l'element sommé
                    }
                }
                
                if(!tmp.IsZero) pRes._monomials.Add(tmp);
            }

            return pRes;
        }
        // Binary +
        public static Polynomial operator +(Polynomial p1, Polynomial p2)
        {
            List<Monomial> l1 = new List<Monomial>(p1.Monomials);
            foreach (var mp2 in p2.Monomials)
                l1.Add(mp2);

            return AddMonoList(l1);
        }
        
        
        
        // Binary -
        public static Polynomial operator -(Polynomial p1, Polynomial p2)
        {
            p2 = - p2;
            return p1 + p2;
        }

        // Binary *
        public static Polynomial operator *(Polynomial p1, Polynomial p2)
        {
            List<Monomial> l1 = new List<Monomial>(p1.Monomials);
            List<Monomial> l2 = new List<Monomial>(p2.Monomials);

            List<Monomial> res = new List<Monomial>();
            for (int i = 0; i < l1.Count; i++)
            {
                for (int j = 0; j < l2.Count; j++)
                {
                    res.Add(l1[i] * l2[j]);
                }
            }

            return AddMonoList(res);
        }
        
        
        
        private static Monomial HighDegree(List<Monomial> lst)
        {
            Monomial d = lst[0];
            
            foreach (var m in lst)
                d = m.Degree > d.Degree ? m : d;

            return d;
        }
        // Binary /
        
        public static Polynomial operator /(Polynomial p1, Polynomial p2)
        {
            if(!p2.IsZero)
            {
                Monomial m1 = HighDegree(p1._monomials);
                Monomial m2 = HighDegree(p2._monomials);
                
                if (m2.Degree > m1.Degree) return new Polynomial(new Monomial(0, 0));
                
                Polynomial tmp = new Polynomial(m1 / m2);
                
                Polynomial quotien = new Polynomial(tmp._monomials[0]); // Un peu Bancale a corriger
                Polynomial reste = p1 - p2 * tmp;
                
                //while (HighDegree(reste._monomials).Degree >= m2.Degree)

                while (reste._monomials.Count > 0 && HighDegree(reste._monomials).Degree >= m2.Degree)
                {
                     m1 = HighDegree(reste._monomials);

                     tmp = new Polynomial(m1 / m2);
                
                     quotien += new Polynomial(tmp._monomials[0]); // Un peu Bancale a corriger
                     
                     reste = reste - p2 * tmp;
                }

                return quotien;
            }

            throw new ArithmeticException();

        }

        public static bool NegaticeCoeff(Polynomial p2)
        {
            foreach (var m in p2.Monomials)
                if (m.Coef < 0) return true;
            
            return false;
        }
        
        // Binary ^
        public static Polynomial operator ^(Polynomial p1, Polynomial p2)
        {
            if ((p2.IsZero || HighDegree(p2._monomials).Degree == 0) && !NegaticeCoeff(p2))
            {
                if (p2.IsZero) return new Polynomial(new Monomial(1, 0));
                
                
                Polynomial pRes = p1;
                for (int i = 1; i < p2._monomials[0].Coef; i++)
                {
                    pRes *= p1;
                }

                return pRes;
            }

            throw new ArithmeticException();
        }
    }
}