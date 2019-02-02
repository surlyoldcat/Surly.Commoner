using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Surly.Commoner.Ext
{
    public static class StringExtensions
    {
        public static bool EqualsCI(this string s1, string s2)
        {
            return s1.Equals(s2, StringComparison.OrdinalIgnoreCase);
        }

        
    }
}
