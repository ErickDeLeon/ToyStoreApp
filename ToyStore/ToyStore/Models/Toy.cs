using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ToyStore.Models
{
    public class Toy
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "*Campo requerido")]
        [Column(TypeName = "varchar(50)")]
        public string Nombre { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string Descripcion { get; set; }

        [Column(TypeName = "int")]
        public int? RestriccionEdad { get; set; }

        [Required(ErrorMessage = "*Campo requerido")]
        [Column(TypeName = "varchar(50)")]
        public string Compania { get; set; }

        [Required(ErrorMessage = "*Campo requerido")]
        [Column(TypeName = "float")]
        public float Precio { get; set; }
    }
}
