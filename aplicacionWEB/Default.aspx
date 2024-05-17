<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="aplicacionWEB.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Gestion Web</h1>

    <div class="row row-cols-1 row-cols-md-3 g-4">

        <%--           -/////////FOREACH //////////////-
        <%  
            foreach (dominio.Articulo articulo in ListaArticulo)
            {
        %>

        <div class="col">
            <div class="card">
                <img src="..." class="card-img-top" alt="...">
                <div class="card-body">
                    <h5 class="card-title"><%=articulo.nombre %></h5>
                    <p class="card-text"><%=articulo.descripcion %></p>
                    <a href="DetalleArticulo.aspx?id=<%= articulo.id %>">Ver detalle</a>
                </div>
            </div>
        </div>
        <% } %>--%>




        <asp:Repeater runat="server" ID="repRepetidor">
            <ItemTemplate>
                <div class="col">
                    <div class="card"> 
                        <img src="..." class="card-img-top" alt="...">
                        <div class="card-body">
                            <h5 class="card-title"><%#Eval("nombre") %></h5>
                            <p class="card-text"><%#Eval("descripcion") %></p>
                            <a href="DetalleArticulo.aspx?id=<%#Eval("id")%>">Ver detalle</a>
                            <asp:Button Text="Ejemplo" CssClass="btn btn-primary" runat="server" id="btnEjemplo" CommandArgument='<%#Eval("id") %>' CommandName="ArticuloId" OnClick="btnEjemplo_Click" />
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
