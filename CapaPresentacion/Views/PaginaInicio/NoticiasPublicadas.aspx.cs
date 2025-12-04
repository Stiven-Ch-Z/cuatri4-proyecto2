using Proyecto2_Noticias.CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto2_Noticias.CapaPresentacion.Views.PaginaInicio
{
    public partial class NoticiasPublicadas : System.Web.UI.Page
    {
        private readonly NoticiaService noticiaService = new NoticiaService(); // servicio de noticias para interactuar con la lógica de negocio
        private readonly AutorService autorService = new AutorService(); // servicio de autores para cargar la lista de autores
        private readonly CategoryService categoriaService = new CategoryService(); // servicio de categorías para cargar la lista de categorías

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarFiltros(); // se cargan los filtros de autores y categorías
                CargarNoticias();// se cargan las noticias publicadas en el GridView
            }
        }

        private void CargarFiltros()
        {
            
            ddlAutor.DataSource = autorService.Listar(); // se obtiene la lista de autores desde el servicio
            ddlAutor.DataTextField = "Nombre"; // se establece el campo de texto que se mostrará en el DropDownList
            ddlAutor.DataValueField = "IdAutor"; // se establece el campo de valor que se utilizará en el DropDownList
            ddlAutor.DataBind(); // se enlazan los datos al DropDownList para que se muestren en la interfaz de usuario
            ddlAutor.Items.Insert(0, new ListItem("Todos", "0")); // mensaje por defecto del DropDownList que vale 0

           
            ddlCategoria.DataSource = categoriaService.Listar(); // se obtiene la lista de categorías desde el servicio
            ddlCategoria.DataTextField = "Nombre"; // se establece el campo de texto que se mostrará en el DropDownList
            ddlCategoria.DataValueField = "IdCategoria"; // se establece el campo de valor que se utilizará en el DropDownList
            ddlCategoria.DataBind(); // se enlazan los datos al DropDownList para que se muestren en la interfaz de usuario
            ddlCategoria.Items.Insert(0, new ListItem("Todas", "0")); // mensaje por defecto del DropDownList que vale 0
        }

        private void CargarNoticias() //método para cargar las noticias publicadas en el GridView
        {
            var autores = autorService.Listar(); //se obtiene la lista de autores desde el servicio
            var categorias = categoriaService.Listar(); //se obtiene la lista de categorías desde el servicio

            var noticias = noticiaService.Listar() // se obtiene la lista de noticias desde el servicio
                .Where(n => n.Estado == "Publicada"); // solo se muestran las noticias publicadas

            if (ddlAutor.SelectedValue != "0") //si se ha seleccionado un autor específico
            {
                int idAutor = int.Parse(ddlAutor.SelectedValue); // se obtiene el id del autor seleccionado
                noticias = noticias.Where(n => n.IdAutor == idAutor); // se filtran las noticias por el autor seleccionado
            }

            if (ddlCategoria.SelectedValue != "0")//si se ha seleccionado una categoría específica
            {
                int idCat = int.Parse(ddlCategoria.SelectedValue); // se obtiene el id de la categoría seleccionada
                noticias = noticias.Where(n => n.IdCategoria == idCat); // se filtran las noticias por la categoría seleccionada
            }

            var datos = noticias.Select(n => new //objeto anónimo con los datos necesarios
            {
                n.Titulo,// //título de la noticia
                AutorNombre = autores.First(a => a.IdAutor == n.IdAutor).Nombre, //nombre del autor correspondiente
                CategoriaNombre = categorias.First(c => c.IdCategoria == n.IdCategoria).Nombre, //nombre de la categoría correspondiente
                n.FechaPublicacion //fecha de publicación de la noticia
            }).ToList(); //se convierte en una lista

            gvNoticias.DataSource = datos; //se asigna como fuente de datos del GridView
            gvNoticias.DataBind(); // se enlazan los datos al GridView para que se muestren en la interfaz de usuario
        }

        protected void Filtros_Changed(object sender, EventArgs e) // cuando se cambia un filtro
        {
            CargarNoticias(); //se recargan las noticias con los filtros aplicados
        }
    }
}