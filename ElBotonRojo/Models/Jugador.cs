using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ElBotonRojo.Models
{
    public class Jugador
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Debe ingresar su nombre.")]
        [StringLength(20, MinimumLength = 1)]
        public String Nombre { get; set; }

        [Required(ErrorMessage = "Debe ingresar su apodo.")]
        [StringLength(20, MinimumLength = 1)]
        public String Apodo { get; set; }

        [Required(ErrorMessage = "Debe ingresar su residencia.")]
        [StringLength(30, MinimumLength = 1)]
        public String Residencia { get; set; }

        [Range(1, 120, ErrorMessage = "Debe ingresar una edad válida")]
        [Required(ErrorMessage = "Debe ingresar su edad.")]
        public int Edad { get; set; }


        public List<Partida> Partidas { get; set; }


    }
}
