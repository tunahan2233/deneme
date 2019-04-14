using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaKullanma
{
    class Program
    {
        static void Main(string[] args)
        {
            //Lamda ifadesi kullanım şekilleri.

            Func<int, int> d1 = x => x + 1; //implicit = ustu kapali
            int deger1 = d1.Invoke(5);
            Console.WriteLine(deger1); //6

            //Action<int> a = x => x + 1;  //implicit = ustu kapali

            Func<int, int> d2 = x => { return x + 1; }; //explicitly = acikca belirtildi
            Console.WriteLine("Sonuc:" + d2.Invoke(10));//11

            Action<string> action = x => { Console.WriteLine(x); };
            action.Invoke("selam"); //selam

            Func<int, int> d3 = (int x) => x * x;
            Console.WriteLine("Sonuc:" + d3.Invoke(10));//Sonuc:100

            Func<int, int, int> d4 = (x, y) => { return x + y; };
            Console.WriteLine("Sonuc="+d4.Invoke(3,4)); //7

            Func<int, int, int,int> d5 = (int x, int y, int z) => x + y + z;
            Console.WriteLine("Sonuc="+d5.Invoke(10,10,10));//30

            Action<string,int> action2 = (string x,int y) => { Console.WriteLine(x+y.ToString()); };
            action2.Invoke("mustafa", 23); //mustafa23

            Func<string, string> fdele = x => x.ToUpper();
            //OrtalmaHesaplayi lambda ifadesiyle cagirin.

            Func<Student, int> orthesapla = x => x.OrtalamaHesapla(10, 10);
            Console.WriteLine(orthesapla.Invoke(new Student()));
            Func<Student, int> aaa = (Student x) => { return x.OrtalamaHesapla(10, 10); };
            Console.WriteLine(aaa.Invoke(new Student()));

            //Func<Func<int>,string> mm= 
            Console.WriteLine("----");
            //string m = "ali";
            //foreach (var item in m)
            //{
            //    Console.WriteLine((int)item);
            //}

            Student a = new Student();
            a.StudentName = "mustafa";
           var sonuc= a.AsciiKarakterDondur(x => x.ToCharArray());
            foreach (var item in sonuc)
            {
                Console.WriteLine(item);
            }
        }
    }

    public class Student
    {
        
        public string StudentName { get; set; }
        public int[] AsciiKarakterDondur(Func<string, char[]> arg)
        {
            return arg.Invoke(StudentName).Select(x => (int)x).ToArray();
        }
        public int OrtalamaHesapla(int not1,int not2)
        {
            return not1 + not2 / 2;
        }
    }
}
