using System;
using System.Collections.Generic;

namespace Reducto
{
    public static class Reducto
    {
        public static Polynomial Parse(string expression)
        {
            Polynomial res = new Polynomial();
            
            //Partie 0
            List<Tokens> listToken = Lexer(expression).Item1;


            int lc = listToken.Count;
            
            // Partie 1
            List<char> signes = Lexer(expression).Item2;
            
            if(lc > 1)
            {
                res = new Polynomial(listToken[0].tokM);
                for (var i = 0; i < lc - 1; i++)
                {
                    

                    var t = listToken[i + 1];
                    if (signes[i] == '-')
                    {
                        res -= new Polynomial(t.tokM);
                    }
                    else if (signes[i] == '+')
                    {
                        res += new Polynomial(t.tokM);
                    }

                }
            }
            else
            {
                res = new Polynomial(listToken[0].tokM);
            }


            return res;
        }

        public static bool IsOperator(char c)
        {
            return c == '*' || c == '+' || c == '-' || c == '/' || c == '^';
        }
        public static bool IsNumber(char c)
        {
            return '0' <= c && '9'>= c  ;
        }
        

        




        public static (List<Tokens>, List<char>) Lexer(string exp)
        {
            string tmp = "";
            Tokens tokm;
            List<Tokens> listToken = new List<Tokens>();
            int l = exp.Length;
            List<char> signe = new List<char>();
            

            for (var i = 0; i < exp.Length; i++)
            {
                var c = exp[i];
                
                if (c != ' ' && c != '\t' && !IsOperator(c))
                {
                    if (c == 'x')
                        tmp += c;
                    

                    else if (IsNumber(c))
                        tmp += c;
                    
                    
                    else throw new ArgumentException();
                }
                
                if (IsOperator(c) || i == l-1)
                {
                    if (i == l-1)
                    {
                        if (IsOperator(exp[i])) throw new ArgumentException();
                    }
                    else if (IsOperator(c))
                    {
                        signe.Add(c);
                    }
                    
                    if (tmp != "")
                    {
                        if (tmp[0] == 'x')
                        {
                            if (tmp.Length == 1) tokm = new Tokens(tmp[0]);
                            else throw new ArgumentException();
                        }
                        else
                            tokm = new Tokens(tmp);
                        
                        listToken.Add(tokm);
                        tmp = "";
                    }
                }
            }

            if (listToken.Count == 0)
                throw new ArgumentException();



            return (listToken, signe);
        }
    }
    
    
        public class Tokens
        {
            public char _signe;
        

            public Monomial tokM;
        
            // Token de variable
            public Tokens(char value)
            {
                //_valueVar = value;
                tokM = new Monomial(1, 1);
            }
        
        
            // Token de nombre
            public Tokens ( string value)
            {
                if (ValidString(value))
                {
                    tokM = new Monomial(Int32.Parse(value), 0);
                }
                else
                {
                    throw new ArgumentException();
                }
            
            }
        
        
            public static bool ValidString(string str)
            {
                foreach (var s in str)
                {
                    if (s == ' ') return false;
                }

                return true;
            }
        }
}