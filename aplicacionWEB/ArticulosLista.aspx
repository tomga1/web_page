﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ArticulosLista.aspx.cs" Inherits="aplicacionWEB.ArticulosLista" %>

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
