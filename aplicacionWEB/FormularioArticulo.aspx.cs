﻿using negocio;
using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.SessionState;

namespace aplicacionWEB
{
    public partial class FormularioArticulo : System.Web.UI.Page
    {

        public bool ConfirmaEliminacion { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
			txtId.Enabled = false;
			ConfirmaEliminacion = false;

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

					//guardo articulo seleccionado en session
					Session.Add("articuloSeleccionado", seleccionado);


					//pre cargar todos los campos de un id existente
					txtId.Text = id;
					txtCodigo.Text = seleccionado.codigo;
					txtNombre.Text = seleccionado.nombre;
					txtDescripcion.Text = seleccionado.descripcion;

					ddMarca.SelectedValue = seleccionado.marca.id.ToString();
					ddCategoria.SelectedValue = seleccionado.categoria.id.ToString();

					txtPrecio.Text = seleccionado.precio.ToString();
					txtUrl.Text = seleccionado.imagenurl;

					//Configurar acciones
					if (!seleccionado.activo)
					{
						BtnInactivar.Text = "Activar"; 
					}

					 
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


				Response.Redirect("ArticulosLista.aspx", false);
					
			}
			catch (Exception ex)
			{
                Session.Add("error", ex);
                throw;
			}
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
			ConfirmaEliminacion = true;
        }

        protected void btnConfirmarEliminar_Click(object sender, EventArgs e)
        {
			try
			{
				if (chkConfirmaEliminacion.Checked)
				{
					articuloNegocio negocio = new articuloNegocio();
					negocio.eliminar(int.Parse(txtId.Text));
					Response.Redirect("ArticulosLista.aspx");

				}
			}
			catch (Exception ex)
			{

				Session.Add("error", ex);
			}
        }

        protected void BtnInactivar_Click(object sender, EventArgs e)
        {
			try
			{
				articuloNegocio negocio = new articuloNegocio();
				Articulo seleccionado = (Articulo)Session["articuloSeleccionado"];	


				negocio.eliminarLogico(seleccionado.id, !seleccionado.activo);
                lblErrorMessage.Visible = false; // Oculta el mensaje de error si la operación es exitosa.
                Response.Redirect("ArticulosLista.aspx"); 
			}
			catch (Exception ex)
			{
                lblErrorMessage.Text = "Ocurrió un error al inhabilitar el artículo: " + ex.Message;
                lblErrorMessage.Visible = true; // Muestra el mensaje de error.

                Session.Add("error", ex);
			}
        }
    }
}