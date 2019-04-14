using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrnekUygulama
{
    /// <summary>
    /// Koleksiyon sınıfımız.
    /// </summary>
    public class Koleksiyon<T>
    {
        int boyut = 0;
        int sayac = 0;
        T[] localDizi = new T[0];

        /// <summary>
        /// Koleksiyonun eleman sayısını döndürür.
        /// </summary>
        public int ElemanSayisi
        {
            get { return sayac; }
        }
        public T this[int index]
        {
            get
            {
                return localDizi[index];
            }
            set
            {
                localDizi[index] = value;
            }
        }

        /// <summary>
        /// Koleksiyona eleman ekler.
        /// </summary>
        /// <param name="arg">Eleman integer tipde olmalidir.</param>
        public void Ekle(T arg)
        {

            if (boyut==sayac)
            {   
                if (boyut == 0)//eger zaten 0 sa boyut = 2
                    boyut = 2;
                else
                    boyut = boyut * 2; //boyutu 2 katina cikar

                //bir tane temp dizi yap
                T[] tempDizi = new T[boyut];
                //once localDizi deki elemanlari kopyalamamiz lazim scopedizi
                Array.Copy(localDizi, tempDizi, sayac);
                localDizi = tempDizi;
            }

            localDizi[sayac] = arg;
            sayac++;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < ElemanSayisi; i++)
            {
                yield return localDizi[i];
            }    
        }
    }
}
