using System.ComponentModel.DataAnnotations;

namespace AlkemyChallenge.Models
{
    public class GeneroXPOS
    {
        public GeneroXPOS(int idPOS, int idGenero)
        {
            this.IdPOS = idPOS;
            this.IdGenero = idGenero;
        }
        [Key]
        public int IdGenPOS { get; set; }
        [Required]
        public int IdPOS { get; set; }
        [Required]
        public int IdGenero { get; set; }
    }
}
