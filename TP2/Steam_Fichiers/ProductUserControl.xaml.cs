using System;
using System.Collections;
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
    /// Logique d'interaction pour ProductUserControl.xaml
    /// </summary>
    public partial class ProductUserControl : UserControl
    {
        private Magasin Magasin;
        private Product Product;
        IEnumerable<Product> Products;
        public static readonly string ApplicationBaseUri = "pack://application:,,,/TP2;component";

        public ProductUserControl() { InitializeComponent(); }

        public ProductUserControl(Product product, Magasin magasin, IEnumerable<Product> products)
        {
            InitializeComponent();
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(ApplicationBaseUri + "/Assets/Steam/Jeux/" + product.Image);
            bitmap.EndInit();

            BitmapImage bitmap1 = new BitmapImage();
            bitmap1.BeginInit();
            bitmap1.UriSource = new Uri(ApplicationBaseUri + "/Assets/Steam/Logos/" + product.OS + ".png");
            bitmap1.EndInit();

            Magasin = magasin;
            Product = product;
            Products = products;

            Image.Source = bitmap;
            Logo.Source = bitmap1;
            Price.Text = Convert.ToString(product.BasePrice);
            Name.Text = product.Name;
            var last = product.Tags.Last();
            foreach (var tag in product.Tags)
            {
                if (tag == last)
                {
                    Tags.Text += Convert.ToString(tag);
                }
                else
                Tags.Text += Convert.ToString(tag + ", ");
            }
           
               
           

        }

        private void UserControl_MouseEnter(object sender, MouseEventArgs e)
        {
            Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#aacee3");
            Name.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#120b09");
            Price.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#120b09");
            Currency.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#120b09");
            Magasin.StackPanelProductInfo.Children.Clear();
           
                var productUserControl = new ProductInfoUserControl(Product);
                Magasin.StackPanelProductInfo.Children.Add(productUserControl);
            
        }

        private void UserControl_MouseLeave(object sender, MouseEventArgs e)
        {
            Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#1f3446");
            Name.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#FFE4E0DA");
            Price.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#FFE4E0DA");
            Currency.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#FFE4E0DA");
        }

        private void UserControl_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var Result = MessageBox.Show("Voulez-vous supprimer cet élément?", "Supprimer", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (Result == MessageBoxResult.Yes)
            {
                var item = App.Current.Products.Find(x => x.Name == Product.Name);
                App.Current.Products.Remove(item);
                Magasin.AfficherProducts(Products);
            }
            
        }
    }
}
