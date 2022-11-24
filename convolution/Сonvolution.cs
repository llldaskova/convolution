using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dpf;
namespace convolution
{
    public class Сonvolution
    {
         private static int[] preparationAr(int[] array,int n)
        {
            var ar = new int[n * 2 ];
            for (int i = 0; i < array.Length; i++)
            {
                ar[i] = array[i];
            }
            for (int i = array.Length; i < n * 2; i++)
            {
                ar[i] = 0;
            }
            return ar;
        }
        private static ComplexNumber[] preparationAr(ComplexNumber[] array, int n)
        {
            var ar = new ComplexNumber[n * 2];
            for (int i = 0; i < array.Length; i++)
            {
                ar[i] = array[i];
            }
            for (int i = array.Length; i < n * 2; i++)
            {
                ar[i] = new ComplexNumber(0);
            }
            return ar;
        }
        private static int whoIsBigger(int n1,int n2)
        {
            int n;
            if (n1 > n2)
                n = n1;
            else
                n = n2;
            return n;
        }
        public static int [] SimpleConvolution(int[] array1, int[] array2)
        {
            int C=0;
            int n = whoIsBigger(array1.Length, array2.Length);
            var ar1 = preparationAr(array1, n*2);
            var ar2 = preparationAr(array2, n*2);

            var resultArray = new int[n*2];

            /* for (int k=0;k< n * 2 ; k++)
             {
                 for(int i=0;i<=k/*&&i<n*2;i++)
                 {
                     resultArray[k] += ar1[i] * ar2[k - i];
                     C += 1;
                 }

             }*/
            for (int k = 0; k < n*2 ; k++)
            {
                for (int i = 0; i < array1.Length&&i<=k;i++)
                {
                   
                        if (k - i <=array2.Length)
                        {
                            resultArray[k] += ar1[i] * ar2[k-i];
                            C++;
                        }
                    
                }
                
            }
            Console.WriteLine("C="+C);
            return resultArray;
        }
       private static ComplexNumber[] Round(ComplexNumber[] array1)
        {
            for(int i=0;i< array1.Length;i++)
            {
                array1[i].Imaginary = Math.Round(array1[i].Imaginary);
                array1[i].Real = Math.Round(array1[i].Real);
            }
            return array1;
        }
        public static ComplexNumber[] FastConvolution(ComplexNumber[] array1, ComplexNumber[] array2)
        {
            int C = 0;
            int n = whoIsBigger(array1.Length, array2.Length);
            var ar1 = preparationAr(array1,n);
            var ar2 = preparationAr(array2,n);
            var resultArray = new ComplexNumber[2*n];
            ar1 = DPF.ReverseDirectDPF(ar1,ref C);
            ar2 = DPF.ReverseDirectDPF(ar2, ref C);
            for (int i=0;i<2*n;i++)
            {
                resultArray[i] = ar1[i] * ar2[i] * 2* n;
                C++;
                Console.WriteLine("A"+resultArray[i]);
            }
            resultArray = DPF.DirectDPF(resultArray, ref C);
            resultArray = Round(resultArray);
            Console.WriteLine("C=" + C);
            return resultArray;
        }

        public static ComplexNumber[] Fast2Convolution(ComplexNumber[] array1, ComplexNumber[] array2)
        {
            int C = 0;
            int n = whoIsBigger(array1.Length, array2.Length);
            var ar1 = preparationAr(array1, n );
            var ar2 = preparationAr(array2, n );

            var resultArray = new ComplexNumber[n * 2];

            ar1 = DPF.ReverseHFDPF(ar1, ref C);
            ar2 = DPF.ReverseHFDPF(ar2, ref C);

            for (int i = 0; i < n * 2; i++)
            {
                resultArray[i] = ar1[i] * ar2[i] * 2 * n;
            }
            resultArray = DPF.HFDPF(resultArray, ref C);
            resultArray = Round(resultArray);
            Console.WriteLine("C=" + C);
            return resultArray;
        }

    }
}
