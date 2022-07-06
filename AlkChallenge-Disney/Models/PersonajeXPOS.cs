using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlkemyChallenge.Models
{
    public class PersonajeXPOS
    {
        [Key]
        public int Id { get; set; }


        [Required, ForeignKey("PersonajeId")]
        public Personaje Personaje { get; set; }
        public int PersonajeId { get; set; }


        [Required, ForeignKey("PeliculaSerieId")]
        public PeliculaSerie Pelicula { get; set; }
        public int PeliculaSerieId { get; set; }
    }
}
