<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CrearNoticias.aspx.cs"
    Inherits="Proyecto2_Noticias.CapaPresentacion.Views.NoticiaPrese.CrearNoticias"
    MasterPageFile="~/CapaPresentacion/Views/Shared/Site.master" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">

    <h2>Gestión de Noticias</h2>
    <hr />
    <br />

    <div>
        <label>Título:</label><br />
        <asp:TextBox runat="server" ID="txtTitulo" CssClass="form-control"></asp:TextBox>
        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtTitulo"
            CssClass="text-danger" ErrorMessage="Debe ingresar un título."
            ValidationGroup="vgNoticia" />
    </div>
    <br />
    <div>
        <label>Contenido:</label><br />
        <asp:TextBox runat="server" ID="txtContenido"
            CssClass="form-control"></asp:TextBox>
        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtContenido"
            CssClass="text-danger" ErrorMessage="Debe ingresar contenido."
            ValidationGroup="vgNoticia" />
    </div>
    <br />
    <div>
        <label>Autor:</label><br />
        <asp:DropDownList runat="server" ID="ddlAutor" CssClass="form-control"></asp:DropDownList>
        <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlAutor"
            CssClass="text-danger" InitialValue="0" ErrorMessage="Debe seleccionar un autor."
            ValidationGroup="vgNoticia" />
    </div>
    <br />
    <div>
        <label>Categoría:</label><br />
        <asp:DropDownList runat="server" ID="ddlCategoria" CssClass="form-control"></asp:DropDownList>
        <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlCategoria"
            CssClass="text-danger" InitialValue="0" ErrorMessage="Debe seleccionar una categoría."
            ValidationGroup="vgNoticia" />
    </div>
    <br />
    <div>
        <label>Estado:</label><br />
        <asp:RadioButtonList runat="server" ID="rbEstado" CssClass="form-control">
            <asp:ListItem Value="Publicada">Publicada</asp:ListItem>
            <asp:ListItem Value="Borrador">Borrador</asp:ListItem>
            <asp:ListItem Value="Archivada">Archivada</asp:ListItem>
        </asp:RadioButtonList>
        <asp:RequiredFieldValidator runat="server" ControlToValidate="rbEstado"
    CssClass="text-danger" InitialValue="" ErrorMessage="Debe seleccionar un Estado." ValidationGroup="vgNoticia" />

    </div>
    <br />
    <hr />
    <br />
    <asp:Button runat="server" ID="btnGuardar" Text="Guardar"
        CssClass="btn btn-primary" OnClick="btnGuardar_Click"
        ValidationGroup="vgNoticia" />

    <asp:Button runat="server" ID="btnCancelar" Text="Cancelar"
        CssClass="btn btn-secondary" OnClick="btnCancelar_Click" />

</asp:Content>

