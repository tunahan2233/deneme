using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrnekUygulama
{
    public static class Extension
    {
        public static IEnumerable<T> Nerede<T>(this Koleksiyon<T> listem,Func<T,bool> predicate)
        {
            foreach (var item in listem)
            {
                var kosulSonucu = predicate.Invoke(item);
                if (kosulSonucu)
                    yield return item;
            }
        }
    }
}
