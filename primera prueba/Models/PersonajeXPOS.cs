using System.ComponentModel.DataAnnotations;

namespace AlkemyChallenge.Models
{
    public class PersonajeXPOS
    {
        public PersonajeXPOS(int idPersonaje, int idPOS)
        {
            this.IdPersonaje = idPersonaje;
            this.IdPOS = idPOS;
        }

        [Key]
        public int IdPerXPOS { get; set; }
        [Required]
        public int IdPersonaje { get; set; }
        [Required]
        public int IdPOS { get; set; }
    }
}
