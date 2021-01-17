using EspressoProject.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for UsersUC.xaml
    /// </summary>
    public partial class UsersUC : UserControl
    {
        public static ObservableCollection<User> UserList { get; set; }
        public static User SelectedUser = new User(0,"","","");
        public UsersUC()
        {
            

            InitializeComponent();


            Database.InitializeDB();
            try
            {
                
                UserList = new ObservableCollection<User>(User.Load());
                ListView.ItemsSource = UserList;

            }
            catch (Exception ex) { MessageBox.Show("Greška kod povezivanja sa tabelom.\nRazlog: " + ex.Message); }

            

        }

        private void SelectListCell(object sender, MouseButtonEventArgs e)
        {
            var item = (sender as ListView).SelectedItem;
            if (item != null)
            {
                System.Windows.Controls.ListView list = (System.Windows.Controls.ListView)sender;
                
                User selectedObject = (User)list.SelectedItem;
                SelectedUser = selectedObject;

                UsernameTextBox.Text = selectedObject.Username;
                PasswordTextBox.Text = selectedObject.Password;
                if (selectedObject.Privilege == "Administrator") PrivilegeComboBox.SelectedIndex = 0;
                else PrivilegeComboBox.SelectedIndex = 1;

        
            }



        }

        private void SaveButtonClick(object sender, RoutedEventArgs e)
        {

            var item = UserList.FirstOrDefault(i => i.Id == SelectedUser.Id);
            if (item != null)
            {
                item.Username = UsernameTextBox.Text;
                item.Password = PasswordTextBox.Text;
                if (PrivilegeComboBox.SelectedIndex == 0)
                    item.Privilege = "Administrator";
                else item.Privilege = "Konobar";

                item.Update();
                   
                  
            }


            CollectionViewSource.GetDefaultView(UserList).Refresh();
            RefreshTextBoxes();
        }

        private void CreateButtonClick(object sender, RoutedEventArgs e)
        {
            
            User NewUser = new User(0,UsernameTextBox.Text, PasswordTextBox.Text, PrivilegeComboBox.Text);
            NewUser.Add();
            UserList.Add(NewUser);
            CollectionViewSource.GetDefaultView(UserList).Refresh();
            RefreshTextBoxes();



        }

        private void DeleteButtonClick(object sender, RoutedEventArgs e)
        {
            
            UserList.Remove(UserList.Where(i => i.Id == SelectedUser.Id).Single());
            SelectedUser.Delete();
            CollectionViewSource.GetDefaultView(UserList).Refresh();
            RefreshTextBoxes();
        }

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
            GotFocusHelper(UsernameTextBox, "Korisničko ime");
        }

        private void NameBoxLostFocus(object sender, RoutedEventArgs e)
        {
            LostFocusHelper(UsernameTextBox, "Korisničko ime");
        }



        private void PasswordBoxGotFocus(object sender, RoutedEventArgs e)
        {
            GotFocusHelper(PasswordTextBox, "Lozinka");
        }

        private void PasswordBoxLostFocus(object sender, RoutedEventArgs e)
        {
            LostFocusHelper(PasswordTextBox, "Lozinka");
        }

        public void RefreshTextBoxes()
        {
            UsernameTextBox.Text = "Korisničko ime";
            PasswordTextBox.Text = "Lozinka";
            PrivilegeComboBox.SelectedIndex = -1;
            LostFocusHelper(UsernameTextBox, "Korisničko ime");
            LostFocusHelper(PasswordTextBox, "Lozinka");
        }
        #endregion
    }
}
