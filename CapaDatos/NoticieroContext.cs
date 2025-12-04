using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Proyecto2_Noticias.CapaDatos.Entidades;

namespace Proyecto2_Noticias.CapaDatos
{
    public class NoticieroContext : DbContext // Contexto de base de datos para el noticiero
    {
        public NoticieroContext() : base("name=NoticieroContext")// constructor que llama al constructor base de DbContext con el nombre de la cadena de conexión
        {
        }
        public virtual DbSet<Autor> Autores { get; set; } // conección del proyecto a la tabla Autores dentro de la base de datos
        public DbSet<Categoria> Categorias { get; set; } // conección del proyecto a la tabla Categorias dentro de la base de datos
        public DbSet<Noticia> Noticias { get; set; } // conección del proyecto a la tabla Noticias dentro de la base de datos
    }
}