using System.Windows;
using System.Windows.Controls;

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
            OptionsGrid.Children.Add(UsersPage);
        }

        private void UsersButtonClick(object sender, RoutedEventArgs e)
        {

            OptionsGrid.Children.Clear();
            OptionsGrid.Children.Add(UsersPage);

        }

       
    }
}
