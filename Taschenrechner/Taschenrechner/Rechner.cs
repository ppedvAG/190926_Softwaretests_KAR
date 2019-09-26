using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taschenrechner
{
    public class Rechner
    {
        public int Add(int z1, int z2) 
        {
            checked
            {
                var result = z1 + z2;
                return result;
            }
        }
    }
}
