<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Crear.aspx.cs" Inherits="Proyecto2_Noticias.CapaPresentacion.Views.Autores.Crear" MasterPageFile="~/CapaPresentacion/Views/Shared/Site.master" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <h2>Edicion y creacion de Autor</h2>
    <hr />
    <br />

        <asp:Label runat="server" Text="Nombre:" AssociatedControlID="txtNombre" />
        <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" />
        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtNombre" ErrorMessage="Escriba el nombre del autor" ValidationGroup="vgAutor" />

    <br /><br />


        <asp:Label runat="server" Text="Correo:" AssociatedControlID="txtCorreo" />
        <asp:TextBox ID="txtCorreo" runat="server" CssClass="form-control" />
        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtCorreo" ErrorMessage="Escriba el correo del autor" ValidationGroup="vgAutor" />
        <asp:RegularExpressionValidator runat="server" ControlToValidate="txtCorreo" ValidationExpression="^\S+@\S+\.\S+$" ErrorMessage="Correo inválido" ValidationGroup="vgAutor" />
    <br /><br />

    <hr />
    <br />
    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn" OnClick="btnGuardar_Click" ValidationGroup="vgAutor" />
    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn" OnClick="btnCancelar_Click" />


    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="false" ShowSummary="true" />
</asp:Content>