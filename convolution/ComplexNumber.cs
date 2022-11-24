using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dpf
{
    public class ComplexNumber
    {
        public double Real { get; set; }
        public double Imaginary { get; set; }
        public ComplexNumber(double real,double imaginary=0)
        {
            Real = real;
            Imaginary = imaginary;
        }
        public static ComplexNumber operator +(ComplexNumber n1, ComplexNumber n2)
        {
            return new ComplexNumber(n1.Real + n2.Real,n1.Imaginary+n2.Imaginary);
        }
        public static ComplexNumber operator -(ComplexNumber n1, ComplexNumber n2)
        {
            return new ComplexNumber(n1.Real - n2.Real, n1.Imaginary - n2.Imaginary);
        }
        public static ComplexNumber operator *(ComplexNumber n1, ComplexNumber n2)
        {
            return new ComplexNumber(n1.Real*n2.Real-n1.Imaginary*n2.Imaginary, n1.Real *n2.Imaginary+n1.Imaginary*n2.Real);
        }
        public static ComplexNumber operator *(double n1, ComplexNumber n2)
        {
            ComplexNumber k1 = new ComplexNumber(n1);
            return k1 * n2;
        }
        public static ComplexNumber operator *(ComplexNumber n1, double n2)
        {
            ComplexNumber k2 = new ComplexNumber(n2);
            return n1 * k2;
        }
        public override string ToString()
        {
            if (Imaginary == 0)
                return Real.ToString();
            else if (Real == 0&&Imaginary==1)
                return "i";
            else if (Real == 0 && Imaginary == -1)
                return "-i";
            else if (Real == 0)
                return Imaginary.ToString() + "i";
            else if(Imaginary==1)
                return Real.ToString() + "+i";
            else if (Imaginary == -1)
                return Real.ToString() + "-i";
            else if(Imaginary>=0)
                return Real.ToString() + "+"+ Imaginary.ToString() + "i";
            else
                return Real.ToString()  +  Imaginary.ToString() + "i";
        }
        }
}
