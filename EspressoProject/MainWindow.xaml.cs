﻿using EspressoProject.UserControls;
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

namespace EspressoProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static LoginUC LoginPage = new LoginUC();
        public MainWindow()
        {
            InitializeComponent();

           // GridMain.Children.Clear();
            //GridMain.Children.Add(LoginPage);

            //Test1
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
