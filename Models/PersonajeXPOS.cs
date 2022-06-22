namespace AlkemyChallenge.Models
{
    public class PersonajeXPOS
    {
        public PersonajeXPOS(int idPersonaje, int idPOS)
        {
            this.IdPersonaje = idPersonaje;
            this.IdPOS = idPOS;
        }
        public int IdPersonaje { get; set; }
        public int IdPOS { get; set; }
    }
}
