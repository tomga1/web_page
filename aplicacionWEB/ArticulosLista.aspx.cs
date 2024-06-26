﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace aplicacionWEB
{
    public partial class ArticulosLista : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            articuloNegocio negocio = new articuloNegocio();
            Session.Add("listaArticulos", negocio.ListarConSP());
            dgvArticulos.DataSource = Session["listaArticulos"]; 
            dgvArticulos.DataBind();

            
        }


        protected void dgvArticulos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvArticulos.PageIndex = e.NewPageIndex;
            dgvArticulos.DataBind();
        }

        protected void dgvArticulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id= dgvArticulos.SelectedDataKey.Value.ToString();
            Response.Redirect("FormularioArticulo.aspx?id=" + id);
        }

        protected void filtro_TextChanged(object sender, EventArgs e)
        {
            List<Articulo> lista = (List<Articulo>)Session["listaArticulos"];
            List<Articulo> listaFiltrada = lista.FindAll(x =>
            x.nombre.ToUpper().Contains(txtFiltro.Text.ToUpper()) ||
            x.codigo.ToUpper().Contains(txtFiltro.Text.ToUpper()));

            dgvArticulos.DataSource = listaFiltrada;
            dgvArticulos.DataBind();
        }
    }


}