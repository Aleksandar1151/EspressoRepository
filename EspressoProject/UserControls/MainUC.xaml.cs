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
    /// Interaction logic for MainUC.xaml
    /// </summary>
    public partial class MainUC : UserControl
    {
        public MainUC()
        {
            InitializeComponent();
        }

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

        private void NameSearchBoxGotFocus(object sender, RoutedEventArgs e)
        {
            GotFocusHelper(NameSearchBox, "Naziv artikla");
        }

        private void NameSearchBoxLostFocus(object sender, RoutedEventArgs e)
        {
            LostFocusHelper(NameSearchBox, "Naziv artikla");
        }



        private void BarcodeSearchBoxGotFocus(object sender, RoutedEventArgs e)
        {
            GotFocusHelper(BarcodeSearchBox, "Barcode");
        }

        private void BarcodeSearchBoxLostFocus(object sender, RoutedEventArgs e)
        {
            LostFocusHelper(BarcodeSearchBox, "Barcode");
        }

        private void getAllBeaverages(object sender, RoutedEventArgs e)
        {
            ObservableCollection<Article> drinks = Article.Load();
            int k = 0;
            //napravi velicinu grida gridDrinks
            gridDrinks.RowDefinitions.Add(new RowDefinition());
            foreach (Article a in drinks)
            {

                button1.Visibility = Visibility.Visible;
                button1.Content = a.Name;
                k++;
            }
        }
    }
}

