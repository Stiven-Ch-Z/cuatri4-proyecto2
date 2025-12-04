<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VistaGeneralCategoria.aspx.cs" Inherits="Proyecto2_Noticias.CapaPresentacion.Views.Categorias.VistaGeneralCategoria" MasterPageFile="~/CapaPresentacion/Views/Shared/Site.master" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <h2>Categorías</h2>
    <asp:GridView ID="gvCategorias" runat="server" AutoGenerateColumns="False" CssClass="tabla" OnRowCommand="gvCategorias_RowCommand">
        <Columns>
            <asp:BoundField DataField="IdCategoria" HeaderText="ID" />
            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
            <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
            <asp:TemplateField HeaderText="Noticias">
        <ItemTemplate>
            <%# Eval("Noticias.Count") %>
        </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Acciones">
            <ItemTemplate>
                <asp:Button runat="server" Text="Editar"  CommandName="Editar" CommandArgument='<%# Eval("IdCategoria") %>' CssClass="btn btn-sm btn-warning"  />
                <asp:Button runat="server" Text="Eliminar"  CommandName="Eliminar" CommandArgument='<%# Eval("IdCategoria") %>' CssClass="btn btn-sm btn-danger" OnClientClick="return confirm('¿Eliminar categoría?');" />
            </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <br />
    <asp:Button ID="btnNueva" runat="server" Text="Nueva Categoría" CssClass="btn" OnClick="btnNueva_Click" />
</asp:Content>
