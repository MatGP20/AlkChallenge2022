﻿namespace AlkemyChallenge.Models
{
    using System.ComponentModel.DataAnnotations;
    public class Genero
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(25)]
        public string Name { get; set; }
        //the image would be a URL link to the character image.
        [Required]
        public string Image { get; set; }
    }
}
