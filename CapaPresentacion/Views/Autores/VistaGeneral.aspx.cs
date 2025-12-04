using Proyecto2_Noticias.CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto2_Noticias.CapaPresentacion.Views.Autores
{
    public partial class VistaGeneral : System.Web.UI.Page
    {
        
            private readonly AutorService servicio = new AutorService(); //se carga el servicio de autores para interactuar con la lógica de negocio


        protected void Page_Load(object sender, EventArgs e) //método que se ejecuta cuando se carga la página
        {
                if (!IsPostBack) 
                CargarAutores();// si no es una recarga de la página, se cargan los autores en el GridView
        }


            private void CargarAutores() //método para cargar los autores en el GridView
        {
                gvAutores.DataSource = servicio.Listar(); //se obtiene la lista de autores desde el servicio y se asigna como fuente de datos del GridView
            gvAutores.DataBind(); // se enlazan los datos al GridView para que se muestren en la interfaz de usuario
        }


            protected void btnNuevo_Click(object sender, EventArgs e)
            {
                Response.Redirect("Crear.aspx"); //redirecciona a la página para crear un nuevo autor
        }


            protected void gvAutores_RowCommand(object sender, GridViewCommandEventArgs e) //método que maneja los comandos de fila en el GridView
        {
                if (e.CommandArgument == null) return; //si no hay argumento de comando, se sale del método


                int id = Convert.ToInt32(e.CommandArgument); //el id del autor se obtiene del argumento del comando


            if (e.CommandName == "Editar") //si el comando es "Editar"
            {
                    Response.Redirect("Crear.aspx?id=" + id); // redirecciona a la página de creación con el id del autor seleccionado para editarlo
            }
                else if (e.CommandName == "Eliminar") //si el comando es "Eliminar"
            {
                    servicio.Eliminar(id); //se llama al servicio para eliminar el autor con el id especificado
                    CargarAutores();//y se recarga la lista de autores en el GridView si el id eliminado
            }
            }
        
    }
}