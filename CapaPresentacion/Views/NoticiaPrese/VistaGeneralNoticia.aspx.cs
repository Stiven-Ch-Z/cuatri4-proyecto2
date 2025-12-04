using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Proyecto2_Noticias.CapaDatos.Entidades;
using Proyecto2_Noticias.CapaNegocio;

namespace Proyecto2_Noticias.CapaPresentacion.Views.NoticiaPrese
{
    public partial class VistaGeneralNoticia : System.Web.UI.Page
    {
        private readonly NoticiaService noticiasService = new NoticiaService();
        private readonly AutorService autorService = new AutorService();
        private readonly CategoryService categoriaService = new CategoryService();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                CargarNoticias();// si no es una recarga de la página, se cargan las noticias en el GridView
        }

        private void CargarNoticias() //método para cargar las noticias en el GridView
        {
            var autores = autorService.Listar(); //se obtiene la lista de autores desde el servicio
            var categorias = categoriaService.Listar(); //se obtiene la lista de categorías desde el servicio
            var noticias = noticiasService.Listar(); //se obtiene la lista de noticias desde el servicio

            var datos = noticias.Select(n => new //objeto anónimo con los datos necesarios
            {
                n.IdNoticia, //ID de la noticia
                n.Titulo, //título de la noticia
                AutorNombre = autores.FirstOrDefault(a => a.IdAutor == n.IdAutor)?.Nombre ?? "No encontrado", //nombre del autor correspondiente o "No encontrado" si no se encuentra
                CategoriaNombre = categorias.FirstOrDefault(c => c.IdCategoria == n.IdCategoria)?.Nombre ?? "No encontrado", //nombre de la categoría correspondiente o "No encontrado" si no se encuentra
                n.FechaPublicacion, //fecha de publicación de la noticia
                n.Estado //estado de la noticia
            }).ToList(); //se convierte en una lista

            gvNoticias.DataSource = datos; //se asigna como fuente de datos del GridView
            gvNoticias.DataBind(); // se enlazan los datos al GridView para que se muestren en la interfaz de usuario
        }

        protected void gvNoticias_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument); //el id de la noticia se obtiene del argumento del comando

            if (e.CommandName == "editar") //si el comando es "editar"
                Response.Redirect("CrearNoticias.aspx?id=" + id); // redirecciona a la página de creación con el id de la noticia seleccionada para editarla

            if (e.CommandName == "eliminar") //si el comando es "eliminar"
            {
                noticiasService.Eliminar(id); //se llama al servicio para eliminar la noticia con el id especificado
                CargarNoticias(); // y se recarga la lista de noticias en el GridView si el id eliminado
            }
        }
        protected void btnNueva_Click(object sender, EventArgs e)
        {
            Response.Redirect("CrearNoticias.aspx"); //redirecciona a la página para crear una nueva noticia limpia
        }
    }
}