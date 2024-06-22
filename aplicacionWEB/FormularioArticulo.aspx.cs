using negocio;
using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace aplicacionWEB
{
    public partial class FormularioArticulo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
			try
			{
				txtId.Enabled = false;
				if (!IsPostBack)
				{
					articuloNegocio negocio = new articuloNegocio();
					List<Marca> lista = negocio.ListarMarca();
					List<Categoria> listacategoria = negocio.ListarCategorias();

				

					ddMarca.DataSource = lista;
					ddMarca.DataValueField = "id";
					ddMarca.DataTextField = "marca";
					ddMarca.DataBind();

                    ddCategoria.DataSource = lista;
                    ddCategoria.DataValueField = "id";
                    ddCategoria.DataTextField = "categoria";
                    ddCategoria.DataBind();


                }
			}
			catch (Exception ex)
			{

				Session.Add("error", ex);
			}
        }
    }
}