using System.ComponentModel.DataAnnotations;

namespace AlkemyChallenge.Models
{
    public class PersonajeXPOS
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int PersonajeId { get; set; }
        [Required]
        public int PeliculaSerieId { get; set; }
    }
}
