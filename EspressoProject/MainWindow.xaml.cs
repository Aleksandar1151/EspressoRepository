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
using System.Threading;

namespace EspressoProject
{
    // Dusan dusan
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Stranice
        public static MainUC MainPage = new MainUC();
        public static StorageUC StoragePage = new StorageUC();
        public static LoginUC LoginPage = new LoginUC();
        public static UsersUC UsersPage = new UsersUC();

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
            foreach (String name in names)
            {
                Console.WriteLine(name);
            }

            ////Bla bla
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
        private async void LoginButtonClick(object sender, RoutedEventArgs e)
        {
            
            var progress = new Progress<int>(value => pbStatus.Value = value);
            await Task.Run(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    ((IProgress<int>)progress).Report(i);
                    Thread.Sleep(10);
                }
            });

            GridMain.Children.Add(MainPage);
            pbStatus.Value = 0;
        }

        private void ShutDownButton(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void UsersButtonClick(object sender, RoutedEventArgs e)
        {
            GridMain.Children.RemoveAt(GridMain.Children.Count - 1);
            GridMain.Children.Add(UsersPage);
        }

        private void StorageButtonClick(object sender, RoutedEventArgs e)
        {
            GridMain.Children.RemoveAt(GridMain.Children.Count - 1);
            GridMain.Children.Add(StoragePage);
        }

        private async void   LogOutButtonClick(object sender, RoutedEventArgs e)
        {
            
            await Task.Delay(1000);
            GridMain.Children.RemoveAt(GridMain.Children.Count-1);
            await Task.Delay(1000);

        }
    }
}
