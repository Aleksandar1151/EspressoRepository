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

        public int IDSoldArticle { get; set; }
        public int IDReceipt { get; set; }
        public String nameOfSoldArticle { get; set; }
        public String priceOfSoldArticle { get; set; }
        public String quantityOfSoldArticle { get; set; }
        public String dateOfSoldArticle { get; set; }
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

        public Article(int IDSoldArticle, int IDReceipt, String nameOfSoldArticle, String priceOfSoldArticle, String quantityOfSoldArticle, String dateOfSoldArticle)
        {
            this.IDSoldArticle = IDSoldArticle;
            this.IDSoldArticle = IDReceipt;
            this.nameOfSoldArticle = nameOfSoldArticle;
            this.priceOfSoldArticle = priceOfSoldArticle;
            this.quantityOfSoldArticle = quantityOfSoldArticle;
            this.dateOfSoldArticle = dateOfSoldArticle;
        }


        public static ObservableCollection<Article> Load()
        {
            ObservableCollection<Article> ResultCollection = new ObservableCollection<Article>();
            Database.InitializeDB();

            try
            {

                String query = "SELECT * FROM roba";

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
            catch (Exception ex) { MessageBox.Show("Greška prilikom preuzimanja robe iz baze!!!!!\nRazlog: " + ex.Message); }

            return ResultCollection;
        }

        public static ObservableCollection<Article> LoadSoldArticles()
        {
            ObservableCollection<Article> ResultArticles = new ObservableCollection<Article>();
            Database.InitializeDB();
            try
            {
                String query = "SELECT * FROM prodana_roba";
                MySqlCommand cmd = new MySqlCommand(query, Database.dbConn);


                Database.dbConn.Open();

                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int IDSoldArticle = Convert.ToInt32(reader["id"]);
                    int IDReceipt = Convert.ToInt32(reader["id_racuna"]);
                    String nameOfSoldArticle = reader["naziv"].ToString();
                    String priceOfSoldArticle = reader["cijena"].ToString();
                    String quantityOfSoldArticle = reader["kolicina"].ToString();
                    String dateOfSoldArticle = reader["datum"].ToString();
                    Article article = new Article(IDSoldArticle, IDReceipt, nameOfSoldArticle, priceOfSoldArticle, quantityOfSoldArticle, dateOfSoldArticle);
                    ResultArticles.Add(article);
                }
                Database.dbConn.Close();
            }
            catch (Exception ex) { MessageBox.Show("Greška prilikom preuzimanja prodane robe iz baze!!!!!\nRazlog: " + ex.Message); }
            return ResultArticles;
        }
    }
}