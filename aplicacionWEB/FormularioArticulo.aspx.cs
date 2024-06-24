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
			txtId.Enabled = false;
			try
			{
				//configuracion inicial, aqui se carga la pantalla con los combobox
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
				//configuracion si estamos MODIFICANDO articulo
				string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";


                if (id != "" && !IsPostBack)
				{
					articuloNegocio negocio = new articuloNegocio();
					Articulo seleccionado = (negocio.listar(id))[0];

					//pre cargar todos los campos de un id existente
					txtId.Text = id;
					txtCodigo.Text = seleccionado.codigo;
					txtNombre.Text = seleccionado.nombre;
					txtDescripcion.Text = seleccionado.descripcion;

					ddMarca.SelectedValue = seleccionado.marca.id.ToString();
					ddCategoria.SelectedValue = seleccionado.categoria.id.ToString();

					txtPrecio.Text = seleccionado.precio.ToString();
					txtUrl.Text = seleccionado.imagenurl;
					 
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

				if (decimal.TryParse(txtPrecio.Text, out decimal precio))
				{
					nuevo.precio = precio;
				}
				else
				{
					throw new Exception("El precio ingresado no es valido.");
				}
				nuevo.imagenurl = txtUrl.Text;

				//Agregar o modificar,  dependiendo si existe el articulo o no 
				if (Request.QueryString["id"] != null)
				{
					nuevo.id = int.Parse(txtId.Text);	
					negocio.modificarConSP(nuevo);
				}
				else
				{
					negocio.agregarConSP(nuevo);	
				}
				negocio.agregarConSP(nuevo);


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