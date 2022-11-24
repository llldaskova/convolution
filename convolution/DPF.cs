using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace dpf
{
    public class DPF
    {
        public static ComplexNumber[] DirectDPF (ComplexNumber[] Array, ref int C)
        {
            //int C = 0;
            ComplexNumber[] resultArray = new ComplexNumber[Array.Length];
            for(int i=0;i<resultArray.Length;i++)
            {
                resultArray[i] = new ComplexNumber(0);
            }
            for(int i=0;i<resultArray.Length;i++)
            {
                for(int j=0;j<resultArray.Length;j++)
                {
                    double arg = 2 * Math.PI * i * j / resultArray.Length;
                    double r = Math.Cos(arg);
                    double im = Math.Sin(arg);
                    var a = new ComplexNumber(r, -1 * im);
                    var a2 = Array[j] * a;
                    resultArray[i] += a2;
                    C+=5;
                  
                }
                resultArray[i].Real=Math.Round(resultArray[i].Real, 4);
                resultArray[i].Imaginary=Math.Round(resultArray[i].Imaginary, 4);
            }
            // Console.WriteLine("Количество операций " + C);
            return resultArray;
            
        }

        public static ComplexNumber[] ReverseDirectDPF(ComplexNumber[] Array,ref int C)
        {
            //int C = 0;
            ComplexNumber[] resultArray = new ComplexNumber[Array.Length];
            for (int i = 0; i < resultArray.Length; i++)
            {
                resultArray[i] = new ComplexNumber(0);
            }
            for (int i = 0; i < resultArray.Length; i++)
            {
                for (int j = 0; j < resultArray.Length; j++)
                {
                    double arg = 2 * Math.PI * i * j / resultArray.Length;
                    double r = Math.Cos(arg);
                    double im = Math.Sin(arg);
                    resultArray[i] += Array[j] * (new ComplexNumber(r,  im));
                    C+=5;

                }
                
                resultArray[i].Real = resultArray[i].Real / resultArray.Length;
                resultArray[i].Imaginary =resultArray[i].Imaginary / resultArray.Length;
                resultArray[i].Real = Math.Round(resultArray[i].Real, 4);
                resultArray[i].Imaginary = Math.Round(resultArray[i].Imaginary, 4);
            }
           
           // Console.WriteLine("Количество операций " + C);
            return resultArray;
        }

        public static ComplexNumber[] HFDPF (ComplexNumber[] Array, ref int C)
        {
            int p1=0, p2=0;
            //int C = 0;
            for (int i= (int)Math.Ceiling(Math.Sqrt(Array.Length)); i>0;i--)
            {
                if(Array.Length % i == 0)
                {
                    p1 = i;
                    p2 = (int)Array.Length / i;
                    break;
                }
            }


            ComplexNumber[] resultArray = new ComplexNumber[Array.Length];
            ComplexNumber[,] A1 = new ComplexNumber[p1,p2];
            ComplexNumber[,] A2 = new ComplexNumber[p1, p2];
            
            for (int i = 0; i < p1; i++)
            {
                resultArray[i] = new ComplexNumber(0);
                for (int j = 0; j < p2; j++)
                {
                    A1[i,j]= new ComplexNumber(0);
                    A2[i,j] = new ComplexNumber(0);
                }
            }
           
            for (int k1 = 0; k1 < p1; k1++)
            {
                for (int j2 = 0; j2 < p2; j2++)
                {
                    for(int j1 = 0; j1 < p1; j1++)
                    {
                        C+=5;
                        double arg =- 2 * Math.PI * k1 * j1 / p1; 
                        double r = Math.Cos(arg);
                        double im = Math.Sin(arg);
                        A1[k1,j2] += Array[j2 + p2 * j1] * (new ComplexNumber(r, im));
                    }
                    A1[k1, j2].Real = Math.Round(A1[k1, j2].Real/*/p1*/, 4);
                    A1[k1, j2].Imaginary = Math.Round(A1[k1, j2].Imaginary/*/p1*/, 4);

                }
            }


            for (int k1 = 0; k1 < p1; k1++)
            {
                for (int k2 = 0; k2 < p2; k2++)
                {
                    for (int j2 = 0; j2 < p2; j2++)
                    {
                        C += 5;
                        double arg = -2 * Math.PI * (k1 + p1 * k2) * j2 / (p1*p2);
                        double r = Math.Cos(arg);
                        double im = Math.Sin(arg);
                        A2[k1, k2] += A1[k1, j2] * (new ComplexNumber(r, im));
                    }
                    A2[k1, k2].Real = Math.Round(A2[k1, k2].Real /*/ p2*/, 4);
                    A2[k1, k2].Imaginary = Math.Round(A2[k1, k2].Imaginary /*/ p2*/, 4);

                }
            }
            int k = 0;
            for (int i = 0; i < p2; i++)
            {
                for (int j = 0; j < p1; j++)
                {
                    resultArray[k] = A2[j,i];
                    k++;
                }
            }

           // Console.WriteLine("Количество операций " + C);
            return resultArray;
        }

        public static ComplexNumber[] ReverseHFDPF(ComplexNumber[] Array, ref int C)
        {
            int p1 = 0, p2 = 0;
            //int C = 0;
            for (int i = (int)Math.Ceiling(Math.Sqrt(Array.Length)); i > 0; i--)
            {
                if (Array.Length % i == 0)
                {
                    p1 = i;
                    p2 = (int)Array.Length / i;
                    break;
                }
            }


            ComplexNumber[] resultArray = new ComplexNumber[Array.Length];
            ComplexNumber[,] A1 = new ComplexNumber[p1, p2];
            ComplexNumber[,] A2 = new ComplexNumber[p1, p2];

            for (int i = 0; i < p1; i++)
            {
                resultArray[i] = new ComplexNumber(0);
                for (int j = 0; j < p2; j++)
                {
                    A1[i, j] = new ComplexNumber(0);
                    A2[i, j] = new ComplexNumber(0);
                }
            }

            for (int k1 = 0; k1 < p1; k1++)
            {
                for (int j2 = 0; j2 < p2; j2++)
                {
                    for (int j1 = 0; j1 < p1; j1++)
                    {
                        C += 5;
                        double arg = 2 * Math.PI * k1 * j1 / p1;
                        double r = Math.Cos(arg);
                        double im = Math.Sin(arg);
                        A1[k1, j2] += Array[j2 + p2 * j1] * (new ComplexNumber(r, im));
                    }
                    A1[k1, j2].Real = Math.Round(A1[k1, j2].Real/p1, 4);
                    A1[k1, j2].Imaginary = Math.Round(A1[k1, j2].Imaginary/p1, 4);

                }
            }


            for (int k1 = 0; k1 < p1; k1++)
            {
                for (int k2 = 0; k2 < p2; k2++)
                {
                    for (int j2 = 0; j2 < p2; j2++)
                    {
                        C += 5;
                        double arg = 2 * Math.PI * (k1 + p1 * k2) * j2 / (p1 * p2);
                        double r = Math.Cos(arg);
                        double im = Math.Sin(arg);
                        A2[k1, k2] += A1[k1, j2] * (new ComplexNumber(r, im));
                    }
                    A2[k1, k2].Real = Math.Round(A2[k1, k2].Real / p2, 4);
                    A2[k1, k2].Imaginary = Math.Round(A2[k1, k2].Imaginary / p2, 4);

                }
            }
            int k = 0;
            for (int i = 0; i < p2; i++)
            {
                for (int j = 0; j < p1; j++)
                {
                    resultArray[k] = A2[j, i];
                    k++;
                }
            }

            // Console.WriteLine("Количество операций " + C);
            return resultArray;
        }


    }
}
