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


namespace EspressoProject.UserControls
{
    /// <summary>
    /// Interaction logic for OptionsUC.xaml
    /// </summary>
    public partial class OptionsUC : UserControl
    {
        public static UsersUC UsersPage = new UsersUC();
        public OptionsUC()
        {
            InitializeComponent();
        }

        private void UsersButtonClick(object sender, RoutedEventArgs e)
        {
          
                OptionsGrid.Children.Clear();
            OptionsGrid.Children.Add(UsersPage);
            
        }
    }
}
