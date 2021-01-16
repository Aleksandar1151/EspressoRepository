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
    public class Article
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string Quantity { get; set; }
        public Article() { }
        public Article(int Id, String Name, String Price, String Quantity)
        {
            this.Id = Id;
            this.Name = Name;
            this.Price = Price;
            this.Quantity = Quantity;
        }


        #region Database
        public static ObservableCollection<Article> Load()
        {
            ObservableCollection<Article> ResultCollection = new ObservableCollection<Article>();
            Database.InitializeDB();

            try
            {

                String query = "SELECT * FROM roba;";

                MySqlCommand cmd = new MySqlCommand(query, Database.dbConn);


                Database.dbConn.Open();

                MySqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    Console.WriteLine("2");
                    int Id = Convert.ToInt32(reader["id"]);
                    String Articlename = reader["naziv_robe"].ToString();
                    String Password = reader["cijena"].ToString();
                    String Privilege = reader["kolicina"].ToString();
                    Article Article = new Article(Id, Articlename, Password, Privilege);
                    ResultCollection.Add(Article);
                    Console.WriteLine("3");
                }

                Database.dbConn.Close();
            }
            catch (Exception ex) { MessageBox.Show("Greška prilikom preuzimanja naloga iz baze!!!!!\nRazlog: " + ex.Message); }

            return ResultCollection;
        }


        /*public ObservableCollection<Article> Add()
        {
            ObservableCollection<Article> ResultCollection = new ObservableCollection<Article>();
            try
            {
                String query = string.Format("INSERT INTO nalozi" +
              "(korisnicko_ime, sifra, tip_naloga) VALUES ('{0}', '{1}', '{2}')", Articlename, Password, Privilege);

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
               , Articlename, Password, Privilege, Id);

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
*/

        #endregion
        override public string ToString()
        {
            string Result = "Naziv: [" + Name + "]"
                            + "Cijena: [" + Price + "]"
                            + "Kolicina: [" + Quantity + "]";
            return Result;
        }
    }
}
