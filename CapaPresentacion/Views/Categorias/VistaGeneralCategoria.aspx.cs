using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Proyecto2_Noticias.CapaNegocio;

namespace Proyecto2_Noticias.CapaPresentacion.Views.Categorias
{
    public partial class VistaGeneralCategoria : System.Web.UI.Page
    {
        private readonly CategoryService servicio = new CategoryService(); //se carga el servicio de categorías para interactuar con la lógica de negocio
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                CargarCategorias(); // si no es una recarga de la página, se cargan las categorías en el GridView
        }
        private void CargarCategorias()
        {
            gvCategorias.DataSource = servicio.Listar();
            gvCategorias.DataBind(); // se enlazan los datos al GridView para que se muestren en la interfaz de usuario
        }
        protected void btnNueva_Click(object sender, EventArgs e)
        {
            Response.Redirect("CrearCategoria.aspx"); //redirecciona a la página para crear una nueva categoría
        }
        protected void gvCategorias_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandArgument == null) return; //si no hay argumento de comando, se sale del método
            int id = Convert.ToInt32(e.CommandArgument); //el id de la categoría se obtiene del argumento del comando
            if (e.CommandName == "Editar") //si el comando es "Editar"
            {
                Response.Redirect("CrearCategoria.aspx?id=" + id); // redirecciona a la página de creación con el id de la categoría seleccionada para editarla
            }
            else if (e.CommandName == "Eliminar") //si el comando es "Eliminar"
            {
                servicio.Eliminar(id); //se llama al servicio para eliminar la categoría con el id especificado
                CargarCategorias(); // y se recarga la lista de categorías en el GridView si el id eliminado
            }
        }
    }
}