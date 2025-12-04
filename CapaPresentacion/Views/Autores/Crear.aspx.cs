using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Proyecto2_Noticias.CapaDatos.Entidades;
using Proyecto2_Noticias.CapaNegocio;


namespace Proyecto2_Noticias.CapaPresentacion.Views.Autores
{
    public partial class Crear : System.Web.UI.Page
    {
       
        private readonly AutorService servicio = new AutorService();  //instancia del servicio de autores para interactuar con la lógica de negocio
        protected void Page_Load(object sender, EventArgs e) //cuando se carga la página
        {
            if (!IsPostBack)
                CargarDatos();// si no es una recarga de la página, se cargan los datos del autor si se está editando uno existente
        }
        private void CargarDatos()
        {
            if (Request.QueryString["id"] != null) //si hay un id en la cadena de consulta, significa que se está editando un autor existente
            {
                if (int.TryParse(Request.QueryString["id"], out int id)) //se intenta convertir el id de la cadena de consulta a un entero
                {
                    var autor = servicio.BuscarPorId(id); //se busca el autor por su id utilizando el servicio
                    if (autor != null) //si se encuentra el autor
                    {
                        txtNombre.Text = autor.Nombre; //se cargan los datos del autor en los campos de texto correspondientes
                        txtCorreo.Text = autor.Correo;
                    }
                }
            }
        }
        protected void btnGuardar_Click(object sender, EventArgs e) //cuando se hace clic en el botón Guardar
        {


            Autor autor = new Autor //se crea un nuevo objeto Autor
            {
                IdAutor = Request.QueryString["id"] == null ? 0 : int.Parse(Request.QueryString["id"]), //si no hay id en la cadena de consulta, se asigna 0 (nuevo autor)
                Nombre = txtNombre.Text.Trim(),
                Correo = txtCorreo.Text.Trim()
                //con los datos ingresados en los campos de texto
            };
                if (autor.IdAutor == 0) //si el id del autor es 0, significa que es un nuevo autor
                    servicio.Insertar(autor);// y se inserta utilizando el servicio
                else
                    servicio.Actualizar(autor); //si no, se actualiza el autor existente
                Response.Redirect("VistaGeneral.aspx");// y nos redirecciona a la vista general de autores
        }
        protected void btnCancelar_Click(object sender, EventArgs e)//cuando se hace clic en el botón Cancelar
        {
            Response.Redirect("VistaGeneral.aspx");// redirecciona a la vista general de autores sin guardar cambios
        }
    }
}