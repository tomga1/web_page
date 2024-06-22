<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="FormularioArticulo.aspx.cs" Inherits="aplicacionWEB.FormularioArticulo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <label for="txtId" class="form-label">Id </label>
                <asp:TextBox runat="server" ID="txtId" CssClass="form-control" />
            </div>

            <div class="mb-3">
                <label for="txtNombre" class="form-label">Nombre: </label>
                <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" />
            </div>

            <div class="mb-3">
                <label for="txtNombre" class="form-label">Codigo: </label>
                <asp:TextBox runat="server" ID="txtCodigo" CssClass="form-control" />
            </div>

            <div class="mb-3">
                <label for="txtNombre" class="form-label">Descripcion: </label>
                <asp:TextBox runat="server" ID="txtDescripcion" CssClass="form-control" />
            </div>

            <asp:DropDownList CssClass="btn btn-secondary btn-sm dropdown-toggle" ID="ddMarca" runat="server"> </asp:DropDownList>

            <asp:DropDownList CssClass="btn btn-secondary btn-sm dropdown-toggle" ID="ddCategoria" runat="server"> </asp:DropDownList>


            <div> <br />  </div>

            <div class="mb-3">
                <asp:Button Text="Aceptar" ID="BtnAceptar" CssClass="btn btn-primary" OnClick="" />
                <a href="ArticulosLista.aspx">Cancelar</a>
            </div>

            



            
</asp:Content>

