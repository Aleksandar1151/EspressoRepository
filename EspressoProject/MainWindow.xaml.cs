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
        public static LoginUC LoginPage = new LoginUC();

        public static MySqlConnection dbConn;
        public MainWindow()
        {
            try { InitializeDB(); }
            catch (Exception ex) { MessageBox.Show("Greška prilikom pokretanja baze podataka\nGreška:" + ex.Message); this.Close(); }

            InitializeComponent();

            // GridMain.Children.Clear();
            //GridMain.Children.Add(LoginPage);

            //Test1

            List<string> names = User.GetNames();
            
            foreach(String name in names)
            {
                Console.WriteLine(name);
            }
           

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }


       
        public static void InitializeDB()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["myDatabaseConnection"].ConnectionString;
            dbConn = new MySqlConnection(connectionString);

        }
    }
}
