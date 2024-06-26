using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Articulo
    {

        public int id { get; set; }
        public string codigo { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public int idmarca { get; set; }
        public int idcategoria { get; set; } 
        public string imagenurl { get; set; }
        public decimal precio { get; set; }
        public bool activo { get; set; }

        public Marca marca { get; set; }

        public Categoria categoria { get; set; }

    }
}
