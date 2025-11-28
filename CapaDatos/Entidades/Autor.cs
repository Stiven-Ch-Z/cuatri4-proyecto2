using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto2_Noticias.CapaDatos.Entidades
{
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

    }
}