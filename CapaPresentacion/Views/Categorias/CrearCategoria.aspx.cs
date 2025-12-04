using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Proyecto2_Noticias.CapaNegocio;
using Proyecto2_Noticias.CapaDatos.Entidades;

namespace Proyecto2_Noticias.CapaPresentacion.Views.Categorias
{
    public partial class CrearCategoria : System.Web.UI.Page
    {
        private readonly CategoryService servicio = new CategoryService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            CargarCategoria(); // si no es una recarga de la página, se cargan los datos de la categoría si se está editando una existente
        }
        private void CargarCategoria()
        {
            if (Request.QueryString["id"] != null) //si hay un id en la cadena de consulta, significa que se está editando una categoría existente
            {
                if (int.TryParse(Request.QueryString["id"], out int id)) //se intenta convertir el id de la cadena de consulta a un entero
                {
                    var categoria = servicio.BuscarPorId(id); //se busca la categoría por su id utilizando el servicio
                    if (categoria != null) //si se encuentra la categoría
                    {
                        txtNombre.Text = categoria.Nombre; 
                        txtDescripcion.Text = categoria.Descripcion;
                        //se cargan los datos de la categoría en los campos de texto correspondientes
                    }
                }
            }
            ;
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            // se crea un nuevo objeto Categoria con los datos ingresados en los campos de texto
            Categoria categoria = new Categoria 
            {
                IdCategoria = Request.QueryString["id"] == null ? 0 : int.Parse(Request.QueryString["id"]), //si no hay id en la cadena de consulta, se asigna 0 (nueva categoría)
                Nombre = txtNombre.Text.Trim(), 
                Descripcion = txtDescripcion.Text.Trim()
                // se asignan los valores de los campos de texto a las propiedades del objeto Categoria
            };

            if (categoria.IdCategoria == 0) //si el id de la categoría es 0, significa que es una nueva categoría y se inserta utilizando el servicio
                servicio.Insertar(categoria);
            else
                servicio.Actualizar(categoria);//si no, se actualiza la categoría existente

            // Regresamos al listado
            Response.Redirect("VistaGeneralCategoria.aspx"); 
        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            // Si el usuario cancela, lo devolvemos al listado
            Response.Redirect("VistaGeneralCategoria.aspx");
        }
    }
}