using System;

namespace WWW
{
    public class Complex
    {
        public float real;
        public float img;

        /// <summary>
        /// Assigns the real and imaginary part of the complexe
        /// </summary>
        /// <param name="real"> Real part</param>
        /// <param name="filter"> Imaginary Part</param>
        public Complex(float real, float img)
        {
            this.real = real;
            this.img = img;
        }

        /// <summary>
        /// Returns a string representing the complex
        /// </summary>
        public override string ToString()
        {
            int imgT = (int) this.img;
            if (imgT < 0)
                return (this.real + "-i" + (-imgT));
            else
                return (this.real + "+i" + imgT);
        }

        /// <summary>
        /// Returns the addition between lhs and rhs
        /// </summary>
        /// <param name="lhs"> Complex on the left of the '+' symbol</param>
        /// <param name="rhs"> Complex on the right of the '+' symbol</param>
        public static Complex operator +(Complex lhs, Complex rhs)
        {
            Complex res = null;
            res.img = lhs.img + rhs.img;
            res.real = lhs.real + rhs.real;
            return res;
        }
        
        /// <summary>
        /// Returns the subtraction between lhs and rhs
        /// </summary>
        /// <param name="lhs"> Complex on the left of the '-' symbol</param>
        /// <param name="rhs"> Complex on the right of the '-' symbol</param>
        public static Complex operator -(Complex lhs, Complex rhs)
        {
            Complex res = null;
            res.img = lhs.img - rhs.img;
            res.real = lhs.real - rhs.real;
            return res;        
        }
        
        /// <summary>
        /// Returns the multiplication between lhs and rhs
        /// </summary>
        /// <param name="lhs"> Complex on the left of the '*' symbol</param>
        /// <param name="rhs"> Complex on the right of the '*' symbol</param>
        public static Complex operator *(Complex lhs, Complex rhs)
        {
            Complex res = null;
            res.img = lhs.img * rhs.img;
            res.real = lhs.real * rhs.real;
            return res;
        }
        
        /// <summary>
        /// Returns the division between lhs and rhs
        /// </summary>
        /// <param name="lhs"> Complex on the left of the '/' symbol</param>
        /// <param name="rhs"> Complex on the right of the '/' symbol</param>
        public static Complex operator /(Complex lhs, Complex rhs)
        {
            if (rhs.real == 0 || rhs.img == 0)
            {
                throw new DivideByZeroException();
            }
            
            Complex res = null;
            res.img = lhs.img / rhs.img;
            res.real = lhs.real / rhs.real;
            return res;
        }

        /// <summary>
        /// Returns true if lhs is equal to rhs
        /// </summary>
        /// <param name="lhs"> Complex on the left of the '==' symbol</param>
        /// <param name="rhs"> Complex on the right of the '==' symbol</param>
        public static bool operator ==(Complex lhs, Complex rhs)
        {
            if (lhs == null && rhs == null)
                return true;
            
            if (lhs != null && rhs != null)
                if (lhs.img == rhs.img && lhs.real == rhs.real)
                    return true;

            return false;
        }

        /// <summary>
        /// Returns true if lhs is not equal to rhs
        /// </summary>
        /// <param name="lhs"> Complex on the left of the '==' symbol</param>
        /// <param name="rhs"> Complex on the right of the '==' symbol</param>
        public static bool operator !=(Complex lhs, Complex rhs)
        {
            if (lhs == null ^ rhs == null)
                return true;
            
            if (lhs == null && rhs == null)
                return false;
            if (lhs.img == rhs.img && lhs.real == rhs.real)
                return false;
            
            return true;
        }
    }
}