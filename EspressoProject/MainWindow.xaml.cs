using EspressoProject.UserControls;
using System;
using System.Collections.Generic;
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
using MySql.Data.MySqlClient;
using System.Configuration;
using EspressoProject.Classes;

namespace EspressoProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Stranice
        public static MainUC MainPage = new MainUC();

        //Konekcija sa bazom
        public static MySqlConnection dbConn;
        public MainWindow()
        {
            //Pokretanje baze
            try { InitializeDB(); }
            catch (Exception ex) { MessageBox.Show("Greška prilikom pokretanja baze podataka\nGreška:" + ex.Message); this.Close(); }

            InitializeComponent();

            
            //Provjera da baza radi
            List<string> names = User.GetNames();            
            foreach(String name in names)
            {
                Console.WriteLine(name);
            }
           

        }



       /// <summary>
       /// Povezivanje Baze "espresso" sa projektom
       /// </summary>
        public static void InitializeDB()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["myDatabaseConnection"].ConnectionString;
            dbConn = new MySqlConnection(connectionString);

        }

        /// <summary>
        /// Dugme "Prijava"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoginButtonClick(object sender, RoutedEventArgs e)
        {
            GridMain.Children.Clear();
            GridMain.Children.Add(MainPage);
        }

        private void ShutDownButton(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
