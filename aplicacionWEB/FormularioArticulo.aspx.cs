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
					List<Marca> listaMarcas = negocio.ListarMarca();
					List<Categoria> listaCategorias = negocio.ListarCategorias();


				

					ddMarca.DataSource = listaMarcas;
					ddMarca.DataValueField = "id";
					ddMarca.DataTextField = "marca";
					ddMarca.DataBind();
                    
					ddCategoria.DataSource = listaCategorias;
                    ddCategoria.DataValueField = "id";
                    ddCategoria.DataTextField = "categoria";
                    ddCategoria.DataBind();


                }
			}
			catch (Exception ex)
			{

				Session.Add("error", ex);
				throw;
			}
        }

        protected void BtnAceptar_Click(object sender, EventArgs e)
        {
			try
			{
				Articulo nuevo = new Articulo();
				articuloNegocio negocio = new articuloNegocio();

				nuevo.codigo = txtCodigo.Text;
				nuevo.nombre = txtNombre.Text;
				nuevo.descripcion = txtDescripcion.Text;	
				
				nuevo.marca = new Marca();
				nuevo.marca.id = int.Parse(ddMarca.SelectedValue);
				
				nuevo.categoria = new Categoria();
				nuevo.categoria.id = int.Parse(ddCategoria.SelectedValue);

				nuevo.precio = int.Parse(txtPrecio.Text);
				nuevo.imagenurl = txtUrl.Text;

				negocio.agregar(nuevo);
				Response.Redirect("ArticulosLista.aspx", false);
					
			}
			catch (Exception ex)
			{
                Session.Add("error", ex);
                throw;
			}
        }
    }
}