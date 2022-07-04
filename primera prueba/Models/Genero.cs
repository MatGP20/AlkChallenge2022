namespace AlkemyChallenge.Models
{
    using System.ComponentModel.DataAnnotations;
    public class Genero
    {
        public Genero(string name, string image)
        {
            this.Name = name;
            this.Image = image;
        }

        [Key]
        public int IdGenero { get; set; }
        [Required, StringLength(25)]
        public string Name { get; set; }
        //the image would be a URL link to the character image.
        [Required]
        public string Image { get; set; }
    }
}
