<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Crear.aspx.cs" Inherits="Proyecto2_Noticias.CapaPresentacion.Views.Autores.Crear" MasterPageFile="~/CapaPresentacion/Views/Shared/Site.master" %>

    <asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <h2>Edicion y creacion de Autor</h2>


    <asp:Label runat="server" Text="Nombre:" AssociatedControlID="txtNombre" />
    <asp:TextBox ID="txtNombre" runat="server" CssClass="input" />
    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtNombre" ErrorMessage="*" Display="Dynamic" />


    <br /><br />


<asp:Label runat="server" Text="Correo:" AssociatedControlID="txtCorreo" />
<asp:TextBox ID="txtCorreo" runat="server" CssClass="input" Height="22px" />
<asp:RequiredFieldValidator runat="server" ControlToValidate="txtCorreo" ErrorMessage="*" Display="Dynamic" />
<asp:RegularExpressionValidator runat="server" ControlToValidate="txtCorreo"
ValidationExpression="^\S+@\S+\.\S+$" ErrorMessage="Correo inválido" Display="Dynamic" />


<br /><br />


<asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn" OnClick="btnGuardar_Click" />
<asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn" OnClick="btnCancelar_Click" Width="90px" />


<asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="false" ShowSummary="true" />
</asp:Content>