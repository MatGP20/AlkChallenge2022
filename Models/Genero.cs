namespace AlkemyChallenge.Models
{
    public class Genero
    {
        public Genero(string name, string image)
        {
            this.Name = name;
            this.Image = image;
        }   

        public int IdGenero { get; }
        public string Name { get; set; }
        public string Image { get; set; }
    }
}
