using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethodlar
{
    class Program
    {
        static void Main(string[] args)
        {
            //Genişletilmiş metodlar.
            //Yani bir tipe uygulanan o tipi genişleten yani özellik kazandıran metodlara extension metod denir.
            //Örneğin:
            string deger = "Mustafa";
            var ch = deger.First();
            Console.WriteLine(ch);
            List<string> list = new List<string>();
            list.Add("ali");
            list.Add("veli");
            Console.WriteLine(list.Contains("ali") ? "Item Mevcut" : "Mevcut Degil");
            //Bu extension metodlar sistemde var olan extension metodlardir. Biz kendi extension metodlarımızı da yazabilir.
            //Bunun için belli kurallara uymamız gerekir.
            //1- Extension isimli bir class yaratmaliyız
            //2- Bu class static tipli tanımlanmalıdır.
            //3- Extension metodlarimizi bu class icine yazariz.
            //4- Extension metodlarimiz mantikli bir isimle yazariz.
            //5- Extension metodlarin hangi tipe uygulanacağı tanımını, extension metodun argumanına this ile belirtiriz.
            int a = 100;
            Console.WriteLine("Karesi="+a.Karesi()); //10000
            int b = 2;
            Console.WriteLine("Karesi=" + b.Karesi()); //4
            int c = 4;
            Console.WriteLine("Karesi="+c.Karesi());
            Console.WriteLine("--------");
            var sonuc =deger.AsciiKarakter();
            foreach (var item in sonuc)
            {
                Console.WriteLine(item);
            }
            double mydouble = 10;
            Console.WriteLine(mydouble.Karekoku());


            //Math.Sqrt()

            int m = 100;
            bool sifirmi = m.ModAl(2);
        }
    }
    static class Extension
    {
        public static int Karesi(this int arg)
        {
            return arg * arg;
        }

        public static bool ModAl(this int arguman,int kati)
        {
            return arguman % kati == 0;
        }

        public static int[] AsciiKarakter(this string arg)
        {
            return arg.Select(x => (int)x).ToArray();
        }

        public static double Karekoku(this double arg)
        {
            return Math.Sqrt(arg);
        }
    }
}
