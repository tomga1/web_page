using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Vendedor
    {
        public int id { get; set; }
        public string vendedor { get; set; }

        public override string ToString()
        {
            return vendedor;
        }
    }

    
}
