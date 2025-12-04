<%@ Page Language="C#" Title="Autores" AutoEventWireup="true" CodeBehind="VistaGeneral.aspx.cs" Inherits="Proyecto2_Noticias.CapaPresentacion.Views.Autores.VistaGeneral" MasterPageFile="~/CapaPresentacion/Views/Shared/Site.master" %>


<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <h2>Autores</h2>

    <asp:GridView ID="gvAutores" runat="server" AutoGenerateColumns="False" CssClass="tabla" OnRowCommand="gvAutores_RowCommand">
        <Columns>
            <asp:BoundField DataField="IdAutor" HeaderText="ID" />
            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
            <asp:BoundField DataField="Correo" HeaderText="Correo" />


            <asp:TemplateField HeaderText="Acciones">
                <ItemTemplate>
                    <asp:Button runat="server" Text="Editar" CommandName="Editar" CommandArgument='<%# Eval("IdAutor") %>' CssClass="btn btn-sm btn-warning"/>
                    <asp:Button runat="server" Text="Eliminar" CommandName="Eliminar" CommandArgument='<%# Eval("IdAutor") %>' CssClass="btn btn-sm btn-danger" OnClientClick="return confirm('¿Eliminar autor?');" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <br />
    <asp:Button ID="btnNuevo" runat="server" Text="Nuevo Autor" CssClass="btn" OnClick="btnNuevo_Click" />
</asp:Content>