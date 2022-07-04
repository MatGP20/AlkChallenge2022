namespace AlkemyChallenge.Models
{
    //using System;
    //using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class Personaje
    {   
        //public Personaje(string image, string nameCharacter)
        //{
        //    this.Image = image;
        //    this.NameCharacter = nameCharacter;

        //}

        //public Personaje(string image, string nameCharacter, int age, int weigth, string history)
        //{
        //    this.Image=image;
        //    this.NameCharacter = nameCharacter;
        //    this.Age = age;
        //    this.Weigth = weigth;
        //    this.History = history;
        //}

        [Key]
        public int Id { get; set; }
        //the image would be a URL link to the character image.
        [Required]
        public string Image { get; set; }
        [Required, StringLength(64)]
        public string NameCharacter { get; set; }
        [Range(0,1000000)]
        public int? Age { get; set; }
        [Range(0, 1000000)]
        public int Weigth { get; set; }
        public string History { get; set; }

    }
}
