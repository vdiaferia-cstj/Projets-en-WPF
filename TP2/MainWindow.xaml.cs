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

namespace TP2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            Marketplace windowMarketplace = new Marketplace();
            windowMarketplace.Show();
            mainWindow.Close();
        }

        private void Wall_Button(object sender, RoutedEventArgs e)
        {
            Wall window = new Wall();
            window.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Magasin steam = new Magasin();
            steam.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            LaSource window = new LaSource();
            window.Show();
        }
    }
}
