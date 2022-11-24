using System;
using dpf;
namespace convolution
{
    class Program
    {
        static void Main(string[] args)
        {
              var ar1 = new int[] { 1,3,5};
              var ar2 = new int[] { 2,4 };
              var ar = Сonvolution.SimpleConvolution(ar1,ar2);

         foreach (var a in ar)
                  Console.WriteLine(a);
                   var ar3 = new ComplexNumber[ar1.Length];
                var ar4 = new ComplexNumber[ar2.Length];
                  for (int i = 0; i < ar1.Length; i++)
                      ar3[i] = new ComplexNumber(ar1[i]);
                  for (int i = 0; i < ar2.Length; i++)
                      ar4[i] = new ComplexNumber(ar2[i]);

                   var ar5 = Сonvolution.FastConvolution(ar3, ar4);

                    foreach (var a in ar5)
                        Console.WriteLine(a);
                    var ar6 = Сonvolution.Fast2Convolution(ar3, ar4);

                    foreach (var a in ar6)
                        Console.WriteLine(a);
             

              
        }
    }
}
