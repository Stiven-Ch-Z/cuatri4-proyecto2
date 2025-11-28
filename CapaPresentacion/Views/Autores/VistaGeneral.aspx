<%@ Page Language="C#" Page Title="Autores" AutoEventWireup="true" CodeBehind="VistaGeneral.aspx.cs" Inherits="Proyecto2_Noticias.CapaPresentacion.Views.Autores.VistaGeneral" MasterPageFile="~/CapaPresentacion/Views/Shared/Site.master" %>


<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <h2>Autores</h2>


    <asp:Button ID="btnNuevo" runat="server" Text="Nuevo Autor" CssClass="btn" OnClick="btnNuevo_Click" />


    <asp:GridView ID="gvAutores" runat="server" AutoGenerateColumns="False" CssClass="tabla" OnRowCommand="gvAutores_RowCommand">
        <Columns>
            <asp:BoundField DataField="IdAutor" HeaderText="ID" />
            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
            <asp:BoundField DataField="Correo" HeaderText="Correo" />


            <asp:TemplateField HeaderText="Acciones">
                <ItemTemplate>
                    <asp:LinkButton runat="server" Text="Editar" CommandName="Editar" CommandArgument='<%# Eval("IdAutor") %>' />
                    <asp:LinkButton runat="server" Text="Eliminar" CommandName="Eliminar" CommandArgument='<%# Eval("IdAutor") %>' OnClientClick="return confirm('¿Eliminar autor?');" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>