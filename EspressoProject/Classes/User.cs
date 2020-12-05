using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EspressoProject.Classes
{
    class User
    {
        public String Username { get; set; }
        public String Password { get; set; }
        public String Privilege { get; set; }

        public User(String Username, String Password, String Privilege)
        {
            this.Username = Username;
            this.Password = Password;
            this.Privilege = Privilege;
        }


        #region Database
        public ObservableCollection<User> Load()
        {
            ObservableCollection<User> ResultCollection = new ObservableCollection<User>();

            try
            {
                String query = "SELECT * FROM nalozi;";
                MySqlCommand cmd = new MySqlCommand(query, Database.dbConn);
                Database.dbConn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    String Username = reader["korisnicko_ime"].ToString();
                    String Password = reader["sifra"].ToString();
                    String Privilege = reader["tip_naloga"].ToString();
                    User user = new User(Username, Password, Privilege);
                    ResultCollection.Add(user);
                }
            }
            catch (Exception ex) { MessageBox.Show("Greška prilikom preuzimanja naloga.\nRazlog: " + ex.Message); }

            return ResultCollection;
        }


        public ObservableCollection<User> Add()
        {
            ObservableCollection<User> ResultCollection = new ObservableCollection<User>();
            try
            {
                String query = string.Format("INSERT INTO nalozi" +
              "(korisnicko_ime, sifra, tip_naloga) VALUES ('{0}', '{1}', '{2}')", Username, Password, Privilege);

                MySqlCommand cmd = new MySqlCommand(query, Database.dbConn);
                Database.dbConn.Open();
                cmd.ExecuteNonQuery();
                int id = (int)cmd.LastInsertedId;
                Database.dbConn.Close();

                User NewUser = new User(Username, Password, Privilege);
                // UsersCollection.Add(NewUser);
            }
            catch (Exception ex) { MessageBox.Show("Greška prilikom kreiranja naloga.\nRazlog: " + ex.Message); }


            return ResultCollection;
        }


        #endregion

     

        override public string ToString()
        {
            string Result = "Korisničko ime: [" + Username + "]"
                            + "Lozinka: [" + Password + "]"
                            + "Tip naloga: [" + Privilege + "]";
            return Result;
        }
    }
}
