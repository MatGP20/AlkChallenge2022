using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AlkemyChallenge.Models
{
    public class UserGestor
    {
        readonly string conection = System.Configuration.ConfigurationManager.ConnectionStrings["AlkChalDisney"].ToString();

        public int RegisterUser(UserModel nuevo)
        {
            UserModel UserSearch = new UserModel(nuevo.Email,nuevo.UserName,nuevo.Password);
            int mensaje;
            
            SqlConnection cx = new SqlConnection(conection);
            cx.Open();

            SqlCommand cm = cx.CreateCommand();
            cm.CommandText = "SELECT email FROM Usuarios WHERE email = @Email";
            cm.Parameters.Add(new SqlParameter("@Email", nuevo.Email));

            SqlDataReader dr = cm.ExecuteReader();

            if (dr.Read())
            {
                string name = dr.GetString(1).Trim();
                string email = dr.GetString(2).Trim();                
                string password = dr.GetString(3).Trim();

                UserModel User = new UserModel(email, name, password);
                UserSearch = User;
            }

            dr.Close();
            cx.Close();

            cx.Close();

            if (UserSearch.Email == null)
            {
                cx.Open();
                cm = cx.CreateCommand();
                cm.CommandText = "INSERT INTO Usuarios (name, password, email) VALUES (@UserName, @Password, @Email)";
                cm.Parameters.Add(new SqlParameter("@UserName", nuevo.UserName));
                cm.Parameters.Add(new SqlParameter("@Password", nuevo.Password));
                cm.Parameters.Add(new SqlParameter("@Email", nuevo.Email));

                cm.ExecuteNonQuery();

                cx.Close();

                mensaje = 0;
            }
            else
            {
                mensaje = 1;
            }
            return mensaje;
        }

        public UserModel SearchUser(string email)
        {
            SqlConnection cx = new SqlConnection(conection);
            cx.Open();

            SqlCommand cm = cx.CreateCommand();
            cm.CommandText = "SELECT * FROM Usuarios WHERE email = @Email";
            cm.Parameters.Add(new SqlParameter("@Email", email));

            SqlDataReader dr = cm.ExecuteReader();

            dr.Read();

            string Name = dr.GetString(1).Trim();
            string Password = dr.GetString(3).Trim();
            string Mail = dr.GetString(2).Trim();

            UserModel clienteBuscado = new UserModel(Name, Password, Mail);

            dr.Close();
            cx.Close();

            return clienteBuscado;
        }

        public void ModifyUser(UserModel u)
        {
            SqlConnection cx = new SqlConnection(conection);
            cx.Open();

            SqlCommand cm = cx.CreateCommand();
            cm.CommandText = "UPDATE Usuarios SET name=@Name, password=@Password WHERE email = @Email";
            cm.Parameters.Add(new SqlParameter("@Name", u.UserName));
            cm.Parameters.Add(new SqlParameter("@Password", u.Password));
            cm.Parameters.Add(new SqlParameter("@Email", u.Email));

            cm.ExecuteNonQuery();

            cx.Close();
        }
    }
}
