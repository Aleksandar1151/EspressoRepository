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
    public class User
    {
        
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Privilege { get; set; }
        public User() { }
        public User(int Id, String Username, String Password, String Privilege)
        {
            this.Id = Id;
            this.Username = Username;
            this.Password = Password;
            this.Privilege = Privilege;
        }


        #region Database
        public static ObservableCollection<User> Load()
        {
            ObservableCollection<User> ResultCollection = new ObservableCollection<User>();
            Database.InitializeDB();

            try
            {
                
                String query = "SELECT * FROM nalozi;";
                
                MySqlCommand cmd = new MySqlCommand(query, Database.dbConn);
                
                
                Database.dbConn.Open();
                
                MySqlDataReader reader = cmd.ExecuteReader();
                

                while (reader.Read())
                {
                    Console.WriteLine("2");
                    int Id = Convert.ToInt32(reader["id"]);
                    String Username = reader["korisnicko_ime"].ToString();
                    String Password = reader["sifra"].ToString();
                    String Privilege = reader["tip_naloga"].ToString();
                    User user = new User(Id, Username, Password, Privilege);
                    ResultCollection.Add(user);
                    Console.WriteLine("3");
                }

                Database.dbConn.Close();
            }
            catch (Exception ex) { MessageBox.Show("Greška prilikom preuzimanja naloga iz baze!!!!!\nRazlog: " + ex.Message); }

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
                Id = (int)cmd.LastInsertedId;
                Database.dbConn.Close();

                
            }
            catch (Exception ex) { MessageBox.Show("Greška prilikom kreiranja naloga u bazi.\nRazlog: " + ex.Message); }


            return ResultCollection;
        }

        public void Update()
        {
            try
            {
                String query = string.Format("UPDATE nalozi SET " +
               "korisnicko_ime='{0}', sifra='{1}', tip_naloga='{2}' WHERE (`id` = '{3}')"
               , Username, Password, Privilege, Id);

                MySqlCommand cmd = new MySqlCommand(query, Database.dbConn);
                Database.dbConn.Open();
                cmd.ExecuteNonQuery();
                Database.dbConn.Close();            
            }
            catch (Exception ex) { MessageBox.Show("Greška prilikom mijenjanja naloga u bazi.\nRazlog: " + ex.Message); }
        }

        public void Delete()
        {
            try
            {
                String query = string.Format("DELETE FROM nalozi WHERE id = '{0}'", Id);
                MySqlCommand cmd = new MySqlCommand(query, Database.dbConn);
                Database.dbConn.Open();
                cmd.ExecuteNonQuery();
                Database.dbConn.Close();

            }
            catch (Exception ex) { MessageBox.Show("Greška prilikom brisanja naloga.\nRazlog: " + ex.Message); }

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
