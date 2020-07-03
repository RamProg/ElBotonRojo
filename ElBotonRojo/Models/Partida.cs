using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ElBotonRojo.Models
{
    public class Partida
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Clicks { get; set; }

        [ForeignKey("Jugador")]
        [Required(ErrorMessage = "Debe seleccionar un jugador")]
        public int IdJugador { get; set; }

        public String Apodo { get; set; }
        public Jugador Jugador { get; set; }
        public DateTime Fecha { get; set; }
    }
}
