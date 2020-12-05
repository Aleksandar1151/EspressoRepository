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
using System.Collections.ObjectModel;

namespace EspressoProject
{
    // Dusan dusan
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// sani
    public partial class MainWindow : Window
    {
        //Stranice
        public static MainUC MainPage = new MainUC();
        public static StorageUC StoragePage = new StorageUC();
        public static LoginUC LoginPage = new LoginUC();
        public static UsersUC UsersPage = new UsersUC();
        public static OptionsUC OptionsPage = new OptionsUC();

        //Konekcija sa bazom
        //public static MySqlConnection dbConn;
        public MainWindow()
        {
            //Pokretanje baze
            try { Database.InitializeDB(); }
            catch (Exception ex) { MessageBox.Show("Greška prilikom pokretanja baze podataka\nGreška:" + ex.Message); this.Close(); }

            //sObservableCollection<User> Collection = new ObservableCollection<User>();


            InitializeComponent();


            GridMain.Children.Clear();
            GridMain.Children.Add(OptionsPage);

            
            //Provjera da baza radi
            /*
             * Collection = User.Load();
            foreach (User name in Collection)
            {
                Console.WriteLine(name);
            }
            */
            ////Bla bla
        }



        /// <summary>
        /// Povezivanje Baze "espresso" sa projektom
        /// </summary>
       

        #region Login/Logout

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
            //await Task.Delay(1000);
            Thread.Sleep(700);

            GridMain.Children.Add(MainPage);
            StorageButton.Visibility = Visibility.Visible;
            PopupBoxName.Visibility = Visibility.Visible;

            pbStatus.Value = 0;
            NameBox.Text = "";
            PasswordBox.Text = "";
            LostFocusHelper(NameBox, "Korisničko ime");
            LostFocusHelper(PasswordBox, "Lozinka");

        }

        private async void LogOutButtonClick(object sender, RoutedEventArgs e)
        {
            StorageButton.Visibility = Visibility.Hidden;
            PopupBoxName.Visibility = Visibility.Hidden;
            await Task.Delay(1000);
            GridMain.Children.RemoveAt(GridMain.Children.Count - 1);
            await Task.Delay(1000);
            CoffeeImage.BringIntoView();
            CoffeeImage.IsEnabled = true;
            CoffeeImage.Focus();


        }

        #endregion

        #region Transitions
       
        private void StorageButtonClick(object sender, RoutedEventArgs e)
        {
            GridMain.Children.RemoveAt(GridMain.Children.Count - 1);
            GridMain.Children.Add(StoragePage);
        }

        private void OptionsButtonClick(object sender, RoutedEventArgs e)
        {
            GridMain.Children.RemoveAt(GridMain.Children.Count - 1);
            GridMain.Children.Add(OptionsPage);
        }
        private void ShutDownButton(object sender, RoutedEventArgs e)
        {
            Close();
        }
        #endregion


        #region TextBox Animations

        private void GotFocusHelper(TextBox name, string text)
        {

            if (name.Text == text)
            {
                name.Text = "";
                var bc = new BrushConverter();
                name.Foreground = (Brush)bc.ConvertFrom("#424242");
                name.FontWeight = FontWeights.Bold;
            }

        }

        private void LostFocusHelper(TextBox name, string text)
        {
            if (name.Text == "")
            {
                name.Text = text;
                var bc = new BrushConverter();
                name.Foreground = (Brush)bc.ConvertFrom("#616161");
                name.FontWeight = FontWeights.Normal;
            }
        }

        private void NameBoxGotFocus(object sender, RoutedEventArgs e)
        {
            GotFocusHelper(NameBox, "Korisničko ime");
        }

        private void NameBoxLostFocus(object sender, RoutedEventArgs e)
        {
            LostFocusHelper(NameBox, "Korisničko ime");
        }

        

        private void PasswordBoxGotFocus(object sender, RoutedEventArgs e)
        {
            GotFocusHelper(PasswordBox, "Lozinka");
        }

        private void PasswordBoxLostFocus(object sender, RoutedEventArgs e)
        {
            LostFocusHelper(PasswordBox, "Lozinka");
        }
        #endregion

       
    }
}
