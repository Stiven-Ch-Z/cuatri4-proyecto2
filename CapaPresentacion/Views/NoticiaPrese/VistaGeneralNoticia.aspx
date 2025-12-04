<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="VistaGeneralNoticia.aspx.cs"
    Inherits="Proyecto2_Noticias.CapaPresentacion.Views.NoticiaPrese.VistaGeneralNoticia"
    MasterPageFile="~/CapaPresentacion/Views/Shared/Site.master" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">

    <h2>Listado de Noticias</h2>

    <asp:GridView runat="server" ID="gvNoticias"
        AutoGenerateColumns="False"
        CssClass="tabla"
        OnRowCommand="gvNoticias_RowCommand">

        <Columns>

            <asp:BoundField DataField="IdNoticia" HeaderText="ID" />
            <asp:BoundField DataField="Titulo" HeaderText="Título" />
            <asp:BoundField DataField="AutorNombre" HeaderText="Autor" />
            <asp:BoundField DataField="CategoriaNombre" HeaderText="Categoría" />
            <asp:BoundField DataField="FechaPublicacion" HeaderText="Fecha" 
                            DataFormatString="{0:yyyy-MM-dd}" />
            <asp:BoundField DataField="Estado" HeaderText="Estado" />

            <asp:TemplateField HeaderText="Acciones">
                <ItemTemplate>
                    <asp:Button runat="server" CommandName="editar" Text="Editar"
                        CommandArgument='<%# Eval("IdNoticia") %>'
                        CssClass="btn btn-sm btn-warning" />

                    <asp:Button runat="server" CommandName="eliminar" Text="Eliminar"
                        CommandArgument='<%# Eval("IdNoticia") %>'
                        CssClass="btn btn-sm btn-danger"
                        OnClientClick="return confirm('¿Desea eliminar esta noticia?');" />
                </ItemTemplate>
            </asp:TemplateField>

        </Columns>
    </asp:GridView>
    <br />
    <asp:Button runat="server" CssClass="btn" ID="btnNueva" Text="Nueva Noticia" Onclick="btnNueva_Click" />
</asp:Content>