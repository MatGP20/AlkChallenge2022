//  User Model for set Database

namespace AlkemyChallenge.Models
{
    //using System;
    //using System.Collections.Generic;
    public class UserModel
    {
        //constructor for the Data because their can't be null
        public UserModel(string userName, string password, string email)
        {
            this.UserName = userName;
            this.Password = password;
            this.Email = email;

        }
        public int IdUser { get; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

    }
}
