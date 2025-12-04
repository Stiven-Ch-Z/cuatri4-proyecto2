using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto2_Noticias.CapaDatos.Entidades
{
    // entidad Noticias que representa a las noticias en la base de datos
    [Table("Noticias")]
    public class Noticia
    {
        [Key]
        [Column("IdNoticia")]
        public int IdNoticia { get; set; }

        [Column("Titulo")]
        public string Titulo { get; set; }


        [Column("Contenido")]
        public string Contenido { get; set; }

        [Column("FechaPublicacion")]
        public DateTime FechaPublicacion { get; set; } = DateTime.Now;

        [Column("Estado")]
        public string Estado { get; set; }


        [Column("IdCategoria")]
        public int IdCategoria { get; set; }


        [ForeignKey("IdCategoria")]
        public virtual Categoria Categoria { get; set; }


        [Column("IdAutor")]
        public int IdAutor { get; set; }


        [ForeignKey("IdAutor")]
        public virtual Autor Autor { get; set; }
    }
}