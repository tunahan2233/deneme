using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Collections;

namespace YieldKeywordu
{
    class Program
    {
        static void Main(string[] args)
        {
            //yield return 1;
            //yield break;

            foreach (var item in Metod())
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("---------");
            // Display powers of 2 up to the exponent of 8:
            foreach (int i in Power(2, 8))
            {
                Console.Write("{0} ", i);
            }
            Console.WriteLine("----------");
            foreach (var item in Faktoriyel(4))
            {
                Console.Write(item);
                
            }
        }
        static IEnumerable Metod()
        {
            yield return 1;
            yield return 2;
            yield return 3;
            yield return 4;
        }
        public static IEnumerable<int> Power(int number, int exponent)
        {
            int result = 1;

            for (int i = 0; i < exponent; i++)
            {
                result = result * number;
                yield return result;
            }
        }

        public static IEnumerable<int> Faktoriyel(int deger)
        {
            //4! = 1x2x3x4=24
            int result = 1;
            for (int i = 1; i <= deger; i++)
            {
                result = result * i;
                yield return i;
            }
            Console.Write("=");
            yield return result;
        }
        // Output: 2 4 8 16 32 64 128 256
    }
}
