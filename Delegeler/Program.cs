using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegeler
{
    class Program
    {
        delegate void Yazdir(string mesaj);
        delegate void BenimDelegem(string isim); //metod imzası
        delegate void Hesaplayici(int a, int b);
        static void Main(string[] args)
        {
            BenimDelegem delegem = Metod; //delege orneklendi
            int degisken = 10;

            Console.WriteLine(degisken.ToString());
            Foo(degisken);

            delegem("mustafa");

            Metod2(delegem);

            delegem.Invoke("universite"); //kimi orneklendirdiysen

            //Anonymous metod
            Hesaplayici hesapla = HesapMetod;
            hesapla.Invoke(1, 2);

            Hesaplayici hesap = delegate(int arg,int arg2) 
            {
                Console.WriteLine(arg/arg2);
            };

            hesap.Invoke(6, 6);

            //Action deger dondurmeyen delege
            Action action = ArgumansizMetod;
            action();
            action.Invoke();

            Action<int, int> actionhesap = HesapMetod;
            actionhesap(3, 3); //6
            actionhesap.Invoke(4, 4); //8
            
            actionhesap= delegate (int arg, int arg2)
            {
                Console.WriteLine(arg / arg2);
            };
            actionhesap(8, 2); //4
            actionhesap.Invoke(9, 3); //3

            //Func delege
            Func<int, int,int> func = Carpma;
            int deger = func.Invoke(4, 10); //deger = 40

            //Lambda.
            //Lamda nedir?
            //Lamda expresssion.
            //Lambda bir daha kısa ve okunabilir metoddur
            //      =>
            //sol => sag (soldaki sagdakine uygulansin)
            // x => sag
            // x => metod
            // x => metoda uygula
            // x => metod (islemi)

            //Lambda ifadesi bir delegeye atanmalıdır.
            //Yazdir orn = Metod;
            //orn("selam"); //Metod cagrildi=selam
            Yazdir orn = (a) => Metod(a);
            orn("ayvansaray"); //Metod cagrildi=ayvansaray

            Func<int, int, int> fun = (a, b) => Carpma(a, b);
            Console.WriteLine("Sonuc:" + fun.Invoke(10, 10));

        }

        static void Metod(string parametre)
        {
            Console.WriteLine($"Metod cagrildi={parametre}");
        }
        static int Carpma(int parametre,int parametre2)
        {
            return parametre * parametre2;
        }
        static void Foo(int arg)
        {
            //arg=10
        }
        static void Metod2(BenimDelegem arg)
        {
            //arg => delegem
            arg("ayvansaray"); //Metod cagrildi=ayvansaray"
        }
        static void HesapMetod(int arg1,int arg2)
        {
            Console.WriteLine(arg1+arg2);
        }

        static void ArgumansizMetod()
        {
            Console.WriteLine("hello");
        }
    }
}
