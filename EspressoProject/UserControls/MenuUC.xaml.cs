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
using EspressoProject.Classes;
using System.Collections.ObjectModel;

namespace EspressoProject.UserControls
{
    /// <summary>
    /// Interaction logic for MenuUC.xaml
    /// </summary>
    public partial class MenuUC : UserControl
    {
        public static ObservableCollection<Merchandise> MerchandiseList { get; set; }
        public MenuUC()
        {
            InitializeComponent();


            Database.InitializeDB();
            try
            {

                MerchandiseList = new ObservableCollection<Merchandise>(Merchandise.Load());
                foreach (var m in MerchandiseList)
                {
                    Console.WriteLine("nase" + m);
                }
                ListView.ItemsSource = MerchandiseList;

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
                /*SelectedUser = selectedObject;

                UsernameTextBox.Text = selectedObject.Username;
                PasswordTextBox.Text = selectedObject.Password;
                if (selectedObject.Privilege == "Administrator") PrivilegeComboBox.SelectedIndex = 0;
                else PrivilegeComboBox.SelectedIndex = 1;

    */
            }



        }
    }
}
