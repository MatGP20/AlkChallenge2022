namespace AlkemyChallenge.Models
{
    public class GeneroXPOS
    {
        public GeneroXPOS(int idPOS, int idGenero)
        {
            this.IdPOS = idPOS;
            this.IdGenero = idGenero;
        }

        public int IdPOS { get; set; }
        public int IdGenero { get; set; }
    }
}
