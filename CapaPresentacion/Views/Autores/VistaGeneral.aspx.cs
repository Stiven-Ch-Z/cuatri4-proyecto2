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
        
            private readonly AutorService servicio = new AutorService();


            protected void Page_Load(object sender, EventArgs e)
            {
                if (!IsPostBack)
                    CargarAutores();
            }


            private void CargarAutores()
            {
                gvAutores.DataSource = servicio.Listar();
                gvAutores.DataBind();
            }


            protected void btnNuevo_Click(object sender, EventArgs e)
            {
                Response.Redirect("Crear.aspx");
            }


            protected void gvAutores_RowCommand(object sender, GridViewCommandEventArgs e)
            {
                if (e.CommandArgument == null) return;


                int id = Convert.ToInt32(e.CommandArgument);


                if (e.CommandName == "Editar")
                {
                    Response.Redirect("Autores_Form.aspx?id=" + id);
                }
                else if (e.CommandName == "Eliminar")
                {
                    servicio.Eliminar(id);
                    CargarAutores();
                }
            }
        
    }
}