//using AlkemyChallenge.Models;
//using System;
//using System.Collections.Generic;
//using System.Configuration;
//using System.Data.SqlClient;
//using System.Linq;
//using System.Web;

//namespace AlkChallenge_Disney.Gestor
//{
//    public class UserGestor
//    {
//        readonly string conection = System.Configuration.ConfigurationManager.ConnectionStrings["AlkChalDisney"].ToString();

//        public string RegisterUser(UserModel nuevo)
//        {
//            UserModel userSearch = new UserModel(" ", " ", " ");
//            string mensaje;
//            userSearch = SearchUser(nuevo.Email);
//            SqlConnection cx = new SqlConnection(conection);
//            cx.Open();

//            if (userSearch.Email == " ")
//            {
//                cx.Open();
//                SqlCommand cm = cx.CreateCommand();
//                cm.CommandText = "INSERT INTO Usuarios (name, password, email) VALUES (@UserName, @Password, @Email)";
//                cm.Parameters.Add(new SqlParameter("@UserName", nuevo.UserName));
//                cm.Parameters.Add(new SqlParameter("@Password", nuevo.Password));
//                cm.Parameters.Add(new SqlParameter("@Email", nuevo.Email));

//                cm.ExecuteNonQuery();

//                cx.Close();

//                mensaje = "Usuario registrado con éxito";
//            }
//            else
//            {
//                mensaje = "Usuario ya registrado";
//            }
//            return mensaje;
//        }

//        public UserModel SearchUser(string email)
//        {
//            SqlConnection cx = new SqlConnection(conection);
//            cx.Open();

//            SqlCommand cm = cx.CreateCommand();
//            cm.CommandText = "SELECT * FROM Usuarios WHERE email = @Email";
//            cm.Parameters.Add(new SqlParameter("@Email", email));

//            SqlDataReader dr = cm.ExecuteReader();

//            if (dr.Read())
//            {
//                string Name = dr.GetString(1).Trim();
//                string Password = dr.GetString(3).Trim();
//                string Mail = dr.GetString(2).Trim();

//                UserModel clienteBuscado = new UserModel(Name, Password, Mail);

//                dr.Close();
//                cx.Close();

//                return clienteBuscado;
//            }
//            else
//            {
//                UserModel userNotFound = new UserModel(" ", " ", " ");
//                cx.Close();
//                return userNotFound;

//            }
//        }

//        public string ModifyUser(UserModel u)
//        {
//            string mensaje;
//            UserModel userSearch = new UserModel(u.Email, u.UserName, u.Password);
//            userSearch = SearchUser(u.Email);

//            if (userSearch != null)
//            {
//                SqlConnection cx = new SqlConnection(conection);
//                cx.Open();

//                SqlCommand cm = cx.CreateCommand();
//                cm.CommandText = "UPDATE Usuarios SET name=@Name, password=@Password WHERE email = @Email";
//                cm.Parameters.Add(new SqlParameter("@Name", u.UserName));
//                cm.Parameters.Add(new SqlParameter("@Password", u.Password));
//                cm.Parameters.Add(new SqlParameter("@Email", u.Email));

//                cm.ExecuteNonQuery();

//                cx.Close();
//                mensaje = "Datos modificados con éxito";
//            }
//            else
//            {
//                mensaje = "Email incorrecto";
//            }

//            return mensaje;

//        }
//    }
//}
