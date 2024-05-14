using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;

namespace aplicacionWEB
{
    public partial class ArticulosLista : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            articuloNegocio negocio = new articuloNegocio();
            dgvArticulos.DataSource = negocio.ListarConSP();
            dgvArticulos.DataBind();
        }   
    }
}