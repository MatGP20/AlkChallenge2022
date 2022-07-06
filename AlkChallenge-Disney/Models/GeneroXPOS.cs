using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlkemyChallenge.Models
{
    public class GeneroXPOS
    {
        [Key]
        public int Id { get; set; }


        [Required, ForeignKey("PeliculaSerieId")]
        public PeliculaSerie Pelicula { get; set; }
        public int PeliculaSerieId { get; set; }


        [Required, ForeignKey("GeneroId")]
        public Genero Genero { get; set; }
        public int GeneroId { get; set; }
    }
}
