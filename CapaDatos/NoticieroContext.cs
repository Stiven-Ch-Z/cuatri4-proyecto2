using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Proyecto2_Noticias.CapaDatos.Entidades;

namespace Proyecto2_Noticias.CapaDatos
{
    public class NoticieroContext : DbContext
    {
        public NoticieroContext() : base("name=NoticieroContext")
        {
        }
        public virtual DbSet<Autor> Autores { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
    }
}