<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ArticulosLista.aspx.cs" Inherits="aplicacionWEB.ArticulosLista" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1> Lista de articulos </h1> 
    <asp:GridView ID="dgvArticulos" runat="server" CssClass="table" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField HeaderText="Codigo" Datafield="codigo" />
            <asp:BoundField HeaderText="Nombre" Datafield="nombre" />
            <asp:BoundField HeaderText="Descripcion" Datafield="descripcion" />
            <asp:BoundField HeaderText="Precio" Datafield="precio" />
            <%--<asp:BoundField HeaderText="Marca" Datafield="marca.marca" />       FALTA MOSTRAR LA MARCA ! --%>

        </Columns>
    
        </asp:GridView>
</asp:Content>
