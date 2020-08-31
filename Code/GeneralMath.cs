using System;
using System.Collections.Generic;

namespace Competitive.MathFundamentals
{
    public class GeneralMath
    {
        public static void Test(){
            List<ulong> testCases = new List<ulong>()
            {
                2,5,10,13,15,20,30
            };
            foreach(var t in testCases)
                System.Console.WriteLine($"{2}^{t}={FastModularExponentiation_Recursive(2,t)}|{FastModularExponentiation_Iterative(2,t)}");
        }
        /*
            The exponentiation of a number can be reduced to the multiplication of its exponents
            2^10 = (2^5)^2 = (2^4 * 2^1)^2 = [(2^2)^2 * 2^1]^2
        */
        // Log n
        public static ulong FastModularExponentiation_Recursive(ulong a, ulong n){
            if(n <= 2)
                return n*n;
            if(n % 2 == 0){
                ulong r = FastModularExponentiation_Recursive(a, n/2);
                return r*r;
            }
            return a * FastModularExponentiation_Recursive(a, n-1);
        }
        public static ulong FastModularExponentiation_Iterative(ulong a, ulong n){
            ulong ret = 1;
            while(n >= 1){
                if(n % 2 == 0){
                    a *= a;
                    n /= 2;
                }
                else{
                    ret = ret * a;
                    n--;
                }
            }
            return ret;
        }
        private static string Pidgeonhole(int n){
            //no entendi para que sirve o q sentido tiene, la teoria es sencilla.
            return string.Empty; 
        }
    }
}