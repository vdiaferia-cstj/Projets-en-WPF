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
using TP2.Classes;

namespace TP2
{
    /// <summary>
    /// Interaction logic for Magasin.xaml
    /// </summary>
    public partial class Magasin : Window
    {
        IEnumerable<Product> AllProducts = App.Current.Products;
        public Magasin()
        {
            InitializeComponent();
            AfficherProducts(AllProducts);
        }

        public void AfficherProducts(IEnumerable<Product> products)
        {
            StackPanelProducts.Children.Clear();
            foreach (var product in products)
            {
                var productUserControl = new ProductUserControl(product,this,products);
                StackPanelProducts.Children.Add(productUserControl);
            }
        }

        private void Nouveaute_Click(object sender, RoutedEventArgs e)
        {
            var products = AllProducts.Where(x => x is NewProduct);
            AfficherProducts(products);
        }

        private void MeilleurVentes_Click(object sender, RoutedEventArgs e)
        {
            var products = AllProducts.OfType<PopularProduct>().OrderByDescending(x=> x.NbSales);
            AfficherProducts(products);
        }

        private void Attendu_Click(object sender, RoutedEventArgs e)
        {
            var products = AllProducts.OfType<ComingSoonProduct>().OrderBy(x=> x.DatePreOrderSortie);
            AfficherProducts(products);

        }

        private void Offres_Click(object sender, RoutedEventArgs e)
        {
            var products = AllProducts.OfType<ProductOnSale>().OrderBy(x => x.SalePrice);
            AfficherProducts(products);
        }
    }
}
