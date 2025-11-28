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
        private readonly AutorService servicio = new AutorService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                CargarDatos();
        }
        private void CargarDatos()
        {
            if (Request.QueryString["id"] != null)
            {
                if (int.TryParse(Request.QueryString["id"], out int id))
                {
                    var autor = servicio.BuscarPorId(id);
                    if (autor != null)
                    {
                        txtNombre.Text = autor.Nombre;
                        txtCorreo.Text = autor.Correo;
                    }
                }
            }
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid) return;


            var autor = new Autor
            {
                IdAutor = Request.QueryString["id"] == null ? 0 : int.Parse(Request.QueryString["id"]),
                Nombre = txtNombre.Text.Trim(),
                Correo = txtCorreo.Text.Trim()
            };

            try
            {
                if (autor.IdAutor == 0)
                    servicio.Insertar(autor);
                else
                    servicio.Actualizar(autor);


                Response.Redirect("VistaGeneral.aspx");
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("VistaGeneral.aspx");
        }
    }
}