using System.ComponentModel.DataAnnotations;

namespace AlkemyChallenge.Models
{
    public class GeneroXPOS
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int PeliculaSerieId { get; set; }
        [Required]
        public int GeneroId { get; set; }
    }
}
