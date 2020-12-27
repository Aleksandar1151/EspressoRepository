using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EspressoProject.UserControls
{
    /// <summary>
    /// Interaction logic for StorageUC.xaml
    /// </summary>
    public partial class StorageUC : UserControl
    {

        MySqlCommand cmd;
        public StorageUC()
        {
            try { InitializeDB(); }
            catch (Exception ex) { MessageBox.Show("Greška prilikom pokretanja baze podataka\nGreška:" + ex.Message); }
            InitializeComponent();
        }

        public static MySqlConnection dbConn;

        public static void InitializeDB()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["myDatabaseConnection"].ConnectionString;
            dbConn = new MySqlConnection(connectionString);

        }

        // Buttons that will control items

        private void btnItems_Click(object sender, RoutedEventArgs e)
        {
            retrieveItems();
        }
        private void btnDeleteItems_click(object sender, RoutedEventArgs e)
        {
            clearItems();
        }

        private void btnRefreshItems_click(object sender, RoutedEventArgs e)
        {
            retrieveItems();
        }

        private void retrieveItems()
        {
            cmd = dbConn.CreateCommand();
            cmd.CommandText = "SELECT * FROM espresso.roba";

            try
            {
                dbConn.Open();
                MySqlDataReader mySqlDataReader = cmd.ExecuteReader();

                //clear listbox with items
                clearItems();

                // retrieve items
                while (mySqlDataReader.Read())
                {
                    lbItems.Items.Add("ID: " + mySqlDataReader["id"]).ToString();
                    lbItems.Items.Add("Naziv robe: " + mySqlDataReader["naziv_robe"]).ToString();
                    lbItems.Items.Add("Cijena: " + mySqlDataReader["cijena"]).ToString();
                    lbItems.Items.Add("Kolicina: " + mySqlDataReader["kolicina"]).ToString();
                    lbItems.Items.Add("-----------------------------------------");
                }

                dbConn.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void clearItems()
        {
            lbItems.Items.Clear();
        }

        // Buttons that will be control sold items

        private void btnSoldItems_click(object sender, RoutedEventArgs e)
        {
            retriveSoldItems();
        }

        private void btnRefreshSoldItems_click(object sender, RoutedEventArgs e)
        {
            retriveSoldItems();
        }

        private void btnDeleteSoldItems_click(object sender, RoutedEventArgs e)
        {
            clearSoldItems();
        }

        private void retriveSoldItems()
        {
            cmd = dbConn.CreateCommand();
            cmd.CommandText = "SELECT * FROM espresso.prodana_roba";

            try
            {
                dbConn.Open();
                MySqlDataReader mySqlDataReader = cmd.ExecuteReader();

                // clear listbox with sold items
                clearSoldItems();

                while (mySqlDataReader.Read())
                {
                    lbSoldItems.Items.Add("ID: " + mySqlDataReader["id"]).ToString();
                    lbSoldItems.Items.Add("ID_racuna: " + mySqlDataReader["id_racuna"]).ToString();
                    lbSoldItems.Items.Add("Naziv: " + mySqlDataReader["naziv"]).ToString();
                    lbSoldItems.Items.Add("Cijena: " + mySqlDataReader["cijena"]).ToString();
                    lbSoldItems.Items.Add("Kolicina: " + mySqlDataReader["kolicina"]).ToString();
                    lbSoldItems.Items.Add("Datum: " + mySqlDataReader["datum"]).ToString();
                    lbSoldItems.Items.Add("---------------------------------------");
                }

                dbConn.Close();

            } catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void clearSoldItems()
        {
            lbSoldItems.Items.Clear();
        }

        // Buttons that will be control bills

    }
}
