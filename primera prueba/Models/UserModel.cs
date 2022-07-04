//  User Model for set Database

namespace AlkemyChallenge.Models
{
    //using System;
    //using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class UserModel
    {
        //constructor for the Data because their can't be null
        public UserModel(string userName, string password, string email)
        {
            this.UserName = userName;
            this.Password = password;
            this.Email = email;

        }


        public UserModel(string email)
        {
            this.Email = email;
        }
        [Key]
        public int IdUser { get; set; }
        [Required,StringLength(50)]
        public string UserName { get; set; }
        [Required, StringLength(16)]
        public string Password { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }

    }
}
