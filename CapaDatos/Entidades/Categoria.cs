using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto2_Noticias.CapaDatos.Entidades
{
    [Table("Categoria")]
    public class Categoria
    {
        [Key]
        [Column("IdCategoria")]
        public int IdCategoria { get; set; }


        [Required]
        [Column("Nombre")]
        public string Nombre { get; set; }


        [Required]
        [Column("Descripcion")]
        public string Descripcion { get; set; }


        public virtual ICollection<Noticia> Noticias { get; set; }
    }
}