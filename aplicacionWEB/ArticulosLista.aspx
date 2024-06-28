<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ArticulosLista.aspx.cs" Inherits="aplicacionWEB.ArticulosLista" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="path_to_your_css_file.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Lista de artículos</h1>

    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <asp:Label Text="Filtrar" runat="server" />
                <asp:TextBox runat="server" ID="txtFiltro" CssClass="form-control" AutoPostBack="true" OnTextChanged="filtro_TextChanged" />
            </div>
        </div>
    </div>

    <div class="col-6" style="display: flex; flex-direction: column; justify-content: flex-end;">
    <div class="mb-3">
        <asp:CheckBox Text="Filtro Avanzado" CssClass="" ID="chkAvanzado" runat="server" AutoPostBack="true" OnCheckedChanged="chkAvanzado_CheckedChanged" />
    </div>
</div>




    <%if (FiltroAvanzado)
        {  %>

    <div class="row">
        <div class="col-3">
            <div class="mb-3">
                <asp:Label Text="Campo" ID="lblCampo" runat="server" />
                <asp:DropDownList runat="server" CssClass="form-control" AutoPostBack="true" ID="ddlCampo" OnSelectedIndexChanged="ddlCampo_SelectedIndexChanged">
                    <asp:ListItem Text="Código" />
                    <asp:ListItem Text="Nombre" />
                </asp:DropDownList>
            </div>
        </div>

        <div class="col-3">
            <div class="mb-3">
                <asp:Label Text="Criterio" runat="server" />
                <asp:DropDownList runat="server" ID="ddlCriterio" CssClass="form-control">
                </asp:DropDownList>
            </div>
        </div>

        <div class="col-3">
            <div class="mb-3">
                <asp:Label Text="Filtro" runat="server" /> 
                <asp:TextBox runat="server" ID="txtFiltroAvanzado" CssClass="form-control" />
            </div>
        </div>

        <div class="col-3">
            <div class="mb-3">
                <asp:Label Text="Estado" runat="server" />
                <asp:DropDownList runat="server" ID="ddlEstado" CssClass="form-control">
                    <asp:ListItem Text="Todos" />
                    <asp:ListItem Text="Activo" />
                    <asp:ListItem Text="Inactivo" />
                </asp:DropDownList>
            </div>
        </div>
        <div class="row">
            <div class="col-3">
                <div class="mb-3">
                    <asp:Button Text="Buscar" runat="server" CssClass="btn btn-primary" ID="btnBuscar" />
                </div>
            </div>
        </div>


    </div>

    <% } %>
    

    
    
    <asp:GridView ID="dgvArticulos" runat="server" DataKeyNames="Id"
        CssClass="table" AutoGenerateColumns="false"
        OnSelectedIndexChanged="dgvArticulos_SelectedIndexChanged"
        OnPageIndexChanging="dgvArticulos_PageIndexChanging"
        AllowPaging="true" PageSize="5">

        <Columns>
            <asp:BoundField HeaderText="Código" DataField="codigo" />
            <asp:BoundField HeaderText="Nombre" DataField="nombre" />
            <asp:BoundField HeaderText="Descripción" DataField="descripcion" />
            <asp:BoundField HeaderText="Precio" DataField="precio" />
            <asp:CheckBoxField HeaderText="Activo" DataField="Activo" />
            <asp:CommandField HeaderText="Editar" ShowSelectButton="true" SelectText="✍" />
            <asp:TemplateField HeaderText="Marca">
                <ItemTemplate>
                    <%# Eval("marca.marca") %>
                </ItemTemplate>
            </asp:TemplateField>

        </Columns>


    </asp:GridView>
    <a href="FormularioArticulo.aspx" class="btn btn-primary">Agregar</a>
</asp:Content>
