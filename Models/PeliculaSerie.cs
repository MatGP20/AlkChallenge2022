namespace AlkemyChallenge.Models
{
    //using System;
    //using System.Collections.Generic;
    public class PeliculaSerie
    {
        public PeliculaSerie(string image, string title, DateOnly creationDate)
        {
            this.Image = image;
            this.Title = title;
            this.CreationDate = creationDate;

        }

        public PeliculaSerie(string image, string title, DateOnly creationDate, int rate)
        {
            this.Image = image;
            this.Title = title;
            this.CreationDate = creationDate;
            this.Rate = rate;
        }

        public int IdPOS { get; }
        public string Image { get; set; }
        public string Title { get; set; }
        public DateOnly CreationDate { get; set; }
        public int Rate { get; set; }


    }
}
