namespace AlkemyChallenge.Models
{
    using System.Data.SqlClient;
    public class GestorPersonajes
    {
        //first of all i open a conection with the DB.
        readonly string conection = System.Configuration.ConfigurationManager.ConnectionStrings["AlkChalDisney"].ToString();

        //this first method is to make a quick POST of a character with only the name and an image.
        public string RegisterCharacterShort(Personaje nuevo)
        {
            Personaje characterSearch = new Personaje(" ", " ");
            string mensaje;
            //Before doing the INSERT into the DB, this method search if there any character with the same name in the DB.
            characterSearch = CharacterSearch(nuevo.NameCharacter);
            
            //If the method did not find any character with the exact name, then proceed to INSERT, else the character is already in the DB.
            if (characterSearch.NameCharacter == " ")
            {
                SqlConnection cx = new SqlConnection(conection);
                cx.Open();
                SqlCommand cm = cx.CreateCommand();
                cm = cx.CreateCommand();
                cm.CommandText = "INSERT INTO Personajes (nombre, imagen) VALUES (@NameCharacter, @Image)";
                cm.Parameters.Add(new SqlParameter("@NameCharacter", nuevo.NameCharacter));
                cm.Parameters.Add(new SqlParameter("@Image", nuevo.Image));

                cm.ExecuteNonQuery();

                cx.Close();

                mensaje = "Personaje Registrado";
            }
            else
            {
                mensaje = "Personaje ya se encuentra registrado";
            }
            return mensaje;
        }

        //this method is to make a complete POST of the Character in the DB. It proceed in the same way than the first method but INSERT all the information of the Character in the DB.
        public string RegisterCharacterLong(Personaje nuevo)
        {
            Personaje characterSearch = new Personaje(" ", " ", 0, 0, " ");
            string mensaje;

            characterSearch = CharacterSearch(nuevo.NameCharacter);

            if (characterSearch.NameCharacter == " ")
            {
                SqlConnection cx = new SqlConnection(conection);
                cx.Open();
                SqlCommand cm = cx.CreateCommand();
                cm = cx.CreateCommand();
                cm.CommandText = "INSERT INTO Personajes (imagen, nombre, edad, peso, historia) VALUES ( @Image, @NameCharacter, @Age, @Weigth, @History)";
                cm.Parameters.Add(new SqlParameter("@NameCharacter", nuevo.NameCharacter));
                cm.Parameters.Add(new SqlParameter("@Image", nuevo.Image));
                cm.Parameters.Add(new SqlParameter("@Age", nuevo.Age));
                cm.Parameters.Add(new SqlParameter("@Weigth", nuevo.Weigth));
                cm.Parameters.Add(new SqlParameter("@History", nuevo.History));

                cm.ExecuteNonQuery();

                cx.Close();

                mensaje = "Personaje Registrado";
            }
            else
            {
                mensaje = "Personaje ya se encuentra registrado";
            }
            return mensaje;
        }

        //Method to search for a Character based on its name.
        public Personaje CharacterSearch(string nameSearch)
        {
            SqlConnection cx = new SqlConnection(conection);
            cx.Open();

            SqlCommand cm = cx.CreateCommand();
            cm.CommandText = "SELECT * FROM Personajes WHERE nombre = @NameCharacter";
            cm.Parameters.Add(new SqlParameter("@NameCharacter", nameSearch));

            SqlDataReader dr = cm.ExecuteReader();

            //if the data reader doesn't find error return the character information, else return a empty character.
            if (dr.Read())
            {
                string name = dr.GetString(2).Trim();
                string image = dr.GetString(1).Trim();

                Personaje character = new Personaje(name, image);
                dr.Close();
                cx.Close();
                return character;
            }
            else
            {
                cx.Close();
                Personaje characterNotFound = new Personaje(" "," ");
                return characterNotFound;
            }
                        
        }
    }
}
