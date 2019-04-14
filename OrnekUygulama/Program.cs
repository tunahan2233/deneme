using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrnekUygulama
{
    class Program
    {
        static void Main(string[] args)
        {
            //Bir tane sinif.
            Koleksiyon<int> liste = new Koleksiyon<int>();
            liste.Ekle(10); //Add
            liste.Ekle(100);
            liste.Ekle(1000);
            liste.Ekle(10000);
            liste.Ekle(100000);
            liste.Ekle(100);
            liste.Ekle(100);

            //liste.Ekle("Koleksiyon1");
            //liste.Ekle("Koleksiyon2");
            //liste.Ekle("Koleksiyon3");

            Console.WriteLine(liste[0]);

            List<int> netlist = new List<int>() { 1, 2, 3, 4 };
            Console.WriteLine(netlist.Count);

            Console.WriteLine("Koleksiyon Eleman Sayisi:"+liste.ElemanSayisi);

            IEnumerable<int> donen = netlist.Where(x => { return x==2; });

            foreach (var item in donen)
            {
                Console.WriteLine(item);
            }
            //Bizim koleksiyon foreach olmuyor!
            //Bizim koleksiyon da where gibi bir metod yok!
            //Where=>nerede

            IEnumerable<int> donen2 = liste.Nerede(x => { return x == 100; });
            //var t = liste.Nerede(x => { return x == "Koleksiyon1"; });

        }
    }
   
}
