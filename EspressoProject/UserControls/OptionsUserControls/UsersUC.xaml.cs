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
                
            }
            catch (Exception ex) { MessageBox.Show("Greška kod povezivanja sa tabelom.\nRazlog: " + ex.Message); }

            ListView.ItemsSource = UserList;

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
                   
                UsersStatusBar.    
            }
            CollectionViewSource.GetDefaultView(UserList).Refresh();
            
        }
    }
}
