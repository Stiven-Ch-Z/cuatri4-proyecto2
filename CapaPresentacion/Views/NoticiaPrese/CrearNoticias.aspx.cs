using Proyecto2_Noticias.CapaDatos.Entidades;
using Proyecto2_Noticias.CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto2_Noticias.CapaPresentacion.Views.NoticiaPrese
{
    public partial class CrearNoticias : System.Web.UI.Page
    {
        private readonly NoticiaService noticiasService = new NoticiaService(); // servicio de noticias para interactuar con la lógica de negocio
        private readonly AutorService autorService = new AutorService(); // servicio de autores para cargar la lista de autores
        private readonly CategoryService categoriaService = new CategoryService(); // servicio de categorías para cargar la lista de categorías
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarAutores(); // se cargan los autores en el DropDownList
                CargarCategorias(); // se cargan las categorías en el DropDownList

                if (Request.QueryString["id"] != null) // si hay un id en la cadena de consulta, significa que se está editando una noticia existente
                {
                    int idNoticia = int.Parse(Request.QueryString["id"]); // se obtiene el id de la noticia de la cadena de consulta
                    CargarNoticia(idNoticia); // se cargan los datos de la noticia en los campos correspondientes
                }
            }
        }
        private void CargarAutores() // método para cargar los autores en el DropDownList
        {
            ddlAutor.DataSource = autorService.Listar(); // se obtiene la lista de autores desde el servicio
            ddlAutor.DataTextField = "Nombre"; // se establece el campo de texto que se mostrará en el DropDownList
            ddlAutor.DataValueField = "IdAutor"; // se establece el campo de valor que se utilizará en el DropDownList
            ddlAutor.DataBind(); // se enlazan los datos al DropDownList para que se muestren en la interfaz de usuario

            ddlAutor.Items.Insert(0, new System.Web.UI.WebControls.ListItem("  Seleccione Aqui  ", "0")); // mensaje por defecto del DropDownList que vale 0
        }
        private void CargarCategorias() // método para cargar las categorías en el DropDownList
        {
            ddlCategoria.DataSource = categoriaService.Listar();// se obtiene la lista de categorías desde el servicio
            ddlCategoria.DataTextField = "Nombre"; // se establece el campo de texto que se mostrará en el DropDownList
            ddlCategoria.DataValueField = "IdCategoria"; // se establece el campo de valor que se utilizará en el DropDownList
            ddlCategoria.DataBind(); // se enlazan los datos al DropDownList para que se muestren en la interfaz de usuario

            ddlCategoria.Items.Insert(0, new System.Web.UI.WebControls.ListItem("  Seleccione Aqui  ", "0"));// mensaje por defecto del DropDownList que vale 0
        }
        private void CargarNoticia(int id) // método para cargar los datos de la noticia en los campos correspondientes para edición
        {
            var n = noticiasService.BuscarPorId(id); // se busca la noticia por su id utilizando el servicio
            if (n == null) return; // si no se encuentra la noticia, se sale del método

            txtTitulo.Text = n.Titulo;
            txtContenido.Text = n.Contenido;
            ddlAutor.SelectedValue = n.IdAutor.ToString();
            ddlCategoria.SelectedValue = n.IdCategoria.ToString();
            rbEstado.SelectedValue = n.Estado;
            //se cargan todos los datos de la noticia en los campos correspondientes mediante su id
            ViewState["IdNoticia"] = id; // se guarda el id de la noticia en el ViewState para saber que estamos editando
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid) return;

            Noticia noticia = new Noticia // se crea un nuevo objeto Noticia con los datos ingresados en los campos correspondientes
            {
                Titulo = txtTitulo.Text.Trim(),
                Contenido = txtContenido.Text.Trim(),
                IdAutor = int.Parse(ddlAutor.SelectedValue),
                IdCategoria = int.Parse(ddlCategoria.SelectedValue),
                Estado = rbEstado.SelectedValue,
                FechaPublicacion = DateTime.Now
                // se asignan los valores de los campos a las propiedades del objeto Noticia
            };

            if (ViewState["IdNoticia"] != null) //si estamos editando una noticia existente
            {
                noticia.IdNoticia = (int)ViewState["IdNoticia"]; // se asigna el id de la noticia al objeto Noticia
                noticiasService.Actualizar(noticia); // y se actualiza utilizando el servicio
            }
            else
            {
                noticiasService.Insertar(noticia);// si no, se inserta como una nueva noticia utilizando el servicio
            }

            Response.Redirect("VistaGeneralNoticia.aspx");// y nos redirecciona a la vista general de noticias
        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("VistaGeneralNoticia.aspx");// redirecciona a la vista general de noticias sin guardar cambios
        }
    }
}
