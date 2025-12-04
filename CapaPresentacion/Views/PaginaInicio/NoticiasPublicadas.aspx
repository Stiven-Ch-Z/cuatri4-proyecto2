<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="NoticiasPublicadas.aspx.cs"
    Inherits="Proyecto2_Noticias.CapaPresentacion.Views.PaginaInicio.NoticiasPublicadas"
    MasterPageFile="~/CapaPresentacion/Views/Shared/Site.master" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">

    <h2>Noticias Publicadas</h2>

    <div class="row">

        <div class="col-md-4">
            <asp:Label runat="server" Text="Filtrar por Autor:" AssociatedControlID="ddlAutor" />
            <asp:DropDownList ID="ddlAutor" runat="server" CssClass="form-control"
                AutoPostBack="true" OnSelectedIndexChanged="Filtros_Changed" />
        </div>

        <div class="col-md-4">
            <asp:Label runat="server" Text="Filtrar por Categoría:" AssociatedControlID="ddlCategoria" />
            <asp:DropDownList ID="ddlCategoria" runat="server" CssClass="form-control"
                AutoPostBack="true" OnSelectedIndexChanged="Filtros_Changed" />
        </div>

    </div>

    <br />

    <asp:GridView runat="server" ID="gvNoticias"
        AutoGenerateColumns="False"
        CssClass="tabla">

        <Columns>

            <asp:BoundField DataField="Titulo" HeaderText="Título" />

            <asp:BoundField DataField="AutorNombre" HeaderText="Autor" />

            <asp:BoundField DataField="CategoriaNombre" HeaderText="Categoría" />

            <asp:BoundField DataField="FechaPublicacion" HeaderText="Fecha"
                DataFormatString="{0:yyyy-MM-dd}" />

        </Columns>

    </asp:GridView>

</asp:Content>
