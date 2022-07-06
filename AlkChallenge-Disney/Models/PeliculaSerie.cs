

namespace AlkemyChallenge.Models
{
    //using System;
    //using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class PeliculaSerie
    {
        //public PeliculaSerie(string image, string title, DateOnly creationDate)
        //{
        //    this.Image = image;
        //    this.Title = title;
        //    this.CreationDate = creationDate;

        //}

        //public PeliculaSerie(string image, string title, DateOnly creationDate, int rate)
        //{
        //    this.Image = image;
        //    this.Title = title;
        //    this.CreationDate = creationDate;
        //    this.Rate = rate;
        //}
        [Key]
        public int Id { get; set; }
        //the image would be a URL link to the character image.
        [Required]
        public string Image { get; set; }
        [Required, StringLength(64)]
        public string Title { get; set; }        
        public DateTime? CreationDate { get; set; }        
        [Range(1, 5)]
        public int? Rate { get; set; }


    }
}
