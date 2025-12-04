<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CrearCategoria.aspx.cs" Inherits="Proyecto2_Noticias.CapaPresentacion.Views.Categorias.CrearCategoria" MasterPageFile="~/CapaPresentacion/Views/Shared/Site.master" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <h2>Categoría</h2>
    <hr />
    <br />

        <asp:Label Text="Nombre:" runat="server" />
        <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"> </asp:TextBox>
        <asp:RequiredFieldValidator ControlToValidate="txtNombre" runat="server" ErrorMessage="Se necesita un titulo para la categoria" ValidationGroup="vgCategoria" />
          <br />


        <asp:Label Text="Descripción:" runat="server" />
        <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control"></asp:TextBox>
        <asp:RequiredFieldValidator ControlToValidate="txtDescripcion" runat="server" ErrorMessage="Se necesita una descripcion de la categoria" ValidationGroup="vgCategoria"/>
        <br />

        <hr />
        <br />
        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" ValidationGroup="vgCategoria" />
        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
        <br />
        <asp:Label ID="lblMensaje" runat="server"></asp:Label>
</asp:Content>