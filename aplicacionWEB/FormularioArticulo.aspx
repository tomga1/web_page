<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="FormularioArticulo.aspx.cs" Inherits="aplicacionWEB.FormularioArticulo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <label for="txtId" class="form-label">Id </label>
                <asp:TextBox runat="server" ID="txtId" CssClass="form-control" />
            </div>

            <div class="mb-3">
                <label for="txtNombre" class="form-label">Codigo: </label>
                <asp:TextBox runat="server" ID="txtCodigo" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="txtNombre" class="form-label">Nombre: </label>
                <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" />
            </div>


            <div class="mb-3">
                <label for="txtNombre" class="form-label">Descripcion: </label>
                <asp:TextBox runat="server" ID="txtDescripcion" CssClass="form-control" />
            </div>

            <asp:DropDownList class="form-select" aria-label="Default select example" ID="ddMarca" runat="server"></asp:DropDownList>

            <asp:DropDownList class="form-select" aria-label="Default select example" ID="ddCategoria" runat="server"></asp:DropDownList>

        </div>
        <div class="col-6">

            <div class="mb-3">
                <label for="txtPrecio" class="form-label">Precio: </label>
                <asp:TextBox runat="server" ID="txtPrecio" CssClass="form-control" />
            </div>

            <div class="mb-3">
                <label for="txtUrl" class="form-label">UrlImagen: </label>
                <asp:TextBox runat="server" ID="txtUrl" CssClass="form-control" />
            </div>

        </div>
        <div>
            <br />  
        </div>

        <div class="mb-3">
            <asp:Button Text="Aceptar" ID="BtnAceptar" CssClass="btn btn-primary" OnClick="BtnAceptar_Click" runat="server" />
        </div>


        <div class="row">
            <div class="col-6">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>

                        <div class="mb-3">
                            <asp:Button Text="Eliminar" ID="btnEliminar" OnClick="btnEliminar_Click" CssClass="btn btn-danger" runat="server" />
                        </div>
                        <% if (ConfirmaEliminacion)
                            { %>
                        <div class="mb-3">
                            <asp:CheckBox Text="Confirmar Eliminación" ID="ConfirmarEliminacion" runat="server" />
                            <asp:Button Text="Eliminar" ID="btnConfirmarEliminar" CssClass="btn btn-outline-danger" runat="server" />
                        </div>
                        <% } %>
                    </ContentTemplate>
                </asp:UpdatePanel>

            </div>
</asp:Content>

