using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Cliente
    {
        public int id { get; set; }
        public string razonsocial { get; set; }
        public string telefono { get; set; }
        public string email { get; set; }
        public string domicilio { get; set; }

        public Vendedor vendedor { get; set; }

    }
}
