using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto2_Noticias.CapaDatos.Entidades
{
    // entidad Autor que representa a los autores de las noticias utilizando anotaciones de datos para mapear a la tabla Autores en la base de datos
    [Table("Autores")]
    public class Autor
    {
        [Key]
        [Column("IdAutor")]
        public int IdAutor { get; set; }

        [Column("Nombre")]
        public string Nombre { get; set; }

        [Column("Correo")]
        public string Correo { get; set; }

        public virtual ICollection<Noticia> Noticias { get; set; } // Relación uno a muchos con Noticias
    }
}