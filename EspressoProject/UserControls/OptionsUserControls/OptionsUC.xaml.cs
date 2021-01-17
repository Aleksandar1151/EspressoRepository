using EspressoProject.UserControls.OptionsUserControls;
using System.Windows;
using System.Windows.Controls;

namespace EspressoProject.UserControls
{
    /// <summary>
    /// Interaction logic for OptionsUC.xaml
    /// </summary>
    public partial class OptionsUC : UserControl
    {       
        
        public OptionsUC()
        {
            
            InitializeComponent();
            UserControl usc;
            usc = new UsersUC();
            OptionsGrid.Children.Add(usc);
        }
        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Visible;
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
            ButtonOpenMenu.Visibility = Visibility.Visible;
        }

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UserControl usc = null;
            OptionsGrid.Children.Clear();

            switch (((ListViewItem)((ListView)sender).SelectedItem).Name)
            {
                case "UsersItem":
                    usc = new UsersUC();
                    OptionsGrid.Children.Add(usc);
                    break;
                case "ReportsItem":

                   
                    usc = new ReportsUC();
                     OptionsGrid.Children.Add(usc);
                    break;

                case "ThemesItem":
                    usc = new ThemesUC();
                    OptionsGrid.Children.Add(usc);
                    break;
                default:
                    break;
            }
        }

    }
}
