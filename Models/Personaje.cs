namespace AlkemyChallenge.Models
{
    //using System;
    //using System.Collections.Generic;
    public class Personaje
    {   
        public Personaje(string image, string nameCharacter)
        {
            this.Image = image;
            this.NameCharacter = nameCharacter;

        }

        public Personaje(string image, string nameCharacter, int age, int weigth, string history)
        {
            this.Image=image;
            this.NameCharacter = nameCharacter;
            this.Age = age;
            this.Weigth = weigth;
            this.History = history;
        }

        public int IdPersonaje { get; }
        //the image would be a URL link to the character image.
        public string Image { get; set; }
        public string NameCharacter { get; set; }
        public int Age { get; set; }
        public int Weigth { get; set; }
        public string History { get; set; }

    }
}
