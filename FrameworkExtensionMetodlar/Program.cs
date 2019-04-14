using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkExtensionMetodlar
{
    class Program
    {
        static void Main(string[] args)
        {
            //WHERE
            List<string> liste = new List<string>() { "Levent", "Tugce", "Ziya", "Irem", "Ercan", "Murat", "Bayram", "Gulsum", "Merve", "Tunahan", "IboCan", "Herdem" };
            //Framework deki Where metodu bir generic extension metodtur, arguman olarak func delege alir. (lambda kullanarak)
            //Koleksiyon ve diziyi filtreleme yarar. Ve geriye IEnumable tipi döndürür. Kosul yapmamiza yarar
            //Bu metod  System.Linq namespacinde yer alır.
            //Linq yu sorguda kısalastırmaya yarar. Linqu sorgusunu uzun uzun yazmayız.

            //Ornek. Listede Karatker sayisi 3 den büyük olanları ekrana yazalım.

            var sonuc = liste.Where(x => x.Length > 5);
            foreach (var item in sonuc)
            {
                Console.WriteLine(item);
            }

            //uzun yol
            List<string> sonuc2 = new List<string>();
            foreach (var item in liste)
            {
                if (item.Length > 5)
                    sonuc2.Add(item);
            }
            foreach (var item in sonuc2)
            {
                Console.WriteLine(item);
            }

            //IEnumerable bir interface dir.
            //Ve dizi ve koleksiyonlara uygulanmıştır.
            string[] dizi = new string[3];
            dizi[0] = "ali"; //=>index = 0, 3
            dizi[1] = "veli";// 1 , 4
            dizi[2] = "selim";//2 ,5
            IEnumerable<string> son = dizi.Where(x => x.Length > 2);

            //IEnumerable bir veri listeye ToList() metoduyla cevirilir.
           List<string> listeCevir= son.ToList();
            listeCevir[0] = "aa";

            //IEnurable bir array (diziye) ToArray() metoduyla cevirilir.
            string[] stringdizi = son.ToArray();

            Func<string, bool> pre = x => { return x =="A"; };
            Func<string, int, bool> pre2 = (x, y) => { return x.Length > y; };
            bool kosulsonucu = pre2.Invoke("ali", 4);
            Console.WriteLine(kosulsonucu);


            Console.WriteLine("----------------------------");

            IEnumerable<string> filtereSonucu= liste.Where((eleman, ahmet) => { return eleman.Length < ahmet; });
            foreach (var item in filtereSonucu)
            {
                Console.WriteLine(item);
            }


            //SELECT
            //Koleksiyon ve dizideki her bir elemani secer.Ve bunlari yeni bir formda gosterir.
            var t = liste.Select(x => x.Length > 5).First();

            //liste.Select(x => x.Length > 5).Where(y => y == true);
            List<Ogrenci> ogrenciList = new List<Ogrenci>();
            ogrenciList.Add(new Ogrenci() { Adi = "Tugce", Not=10 });
            ogrenciList.Add(new Ogrenci() { Adi = "Iremm", Not = 11 });
            Console.WriteLine("------------");
            IEnumerable<Ogrenci> ogsonuc = ogrenciList.Where(x => x.Adi.Length > 4 && x.Adi[0] == 'I');
            foreach (var item in ogsonuc)
            {
                Console.WriteLine(item.Adi+item.Not);
            }
            //Listede isim uzunlugu 4 den buyuk ve ismin ilk karakteri I olan elemanin isim ozelliginin buyuklugunu baska bir nesnenin ozelligine atayiniz.
            var d1 = ogrenciList.Where(x => x.Adi.Length > 4 && x.Adi[0] == 'I').Select(y => new OgrenciSeviyesi() {   AdUzunlugu = y.Adi.Length });
            
            
         
        }
    }

    class Ogrenci
    {
        public string Adi { get; set; }
        public int Not { get; set; }
     
    }
    class OgrenciSeviyesi
    {
        public int AdUzunlugu { get; set; }
    }
}
