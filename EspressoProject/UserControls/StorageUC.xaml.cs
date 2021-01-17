using EspressoProject.Classes;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
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
    /// Interaction logic for StorageUC.xaml
    /// </summary>
    public partial class StorageUC : UserControl
    {
        public static ReceiptUC ReceiptPage = new ReceiptUC();
        public static ObservableCollection<Article> ArticleList { get; set; }
        public static ObservableCollection<Article> SoldArticleList { get; set; }
        public StorageUC()
        {
            try { InitializeDB(); }
            catch (Exception ex) { }
            InitializeComponent();
            Database.InitializeDB();
            try
            {
                ArticleList = new ObservableCollection<Article>(Article.Load());
                articleList.ItemsSource = ArticleList;
                SoldArticleList = new ObservableCollection<Article>(Article.LoadSoldArticles());
                soldArticlesList.ItemsSource = SoldArticleList;
            }
            catch (Exception ex) { MessageBox.Show("Greška kod povezivanja sa tabelom.\nRazlog: " + ex.Message); }
        }

        private void ReceiptButtonClick(object sender, RoutedEventArgs e)
        {
            StorageGrid.Children.Clear();
            StorageGrid.Children.Add(ReceiptPage);
        }
    }
}
