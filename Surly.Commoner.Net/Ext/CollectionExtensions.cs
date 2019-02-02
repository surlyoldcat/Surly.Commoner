using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Surly.Commoner.Ext
{
    public static class CollectionExtensions
    {
        public static IEnumerable<T[]> Chunkify<T>(this IEnumerable<T> source, int chunkSize)
        {
            T[] chunk = new T[chunkSize];
            int i = 0;
            foreach(var item in source)
            {
                chunk[i++] = item;
                if (i == chunkSize)
                {
                    yield return chunk;
                    i = 0;
                }
            }

            // any items left over?
            if (i > 0) 
            {
                Array.Resize(ref chunk, i);
                yield return chunk;
            }
        }
    }
}
