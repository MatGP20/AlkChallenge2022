﻿namespace AlkemyChallenge.Models
{
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class UserModel
    {
        //all the commented code was for learning

        //constructor for the Data because their can't be null
        //public UserModel(string userName, string password, string email)
        //{
        //    this.UserName = userName;
        //    this.Password = password;
        //    this.Email = email;

        //}

        //public UserModel(string email)
        //{
        //    this.Email = email;
        //}

        [Key]
        public int Id { get; set; }

        [Required,StringLength(50)]
        public string UserName { get; set; }
        [Required, StringLength(16)]
        public string Password { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }

    }
}
