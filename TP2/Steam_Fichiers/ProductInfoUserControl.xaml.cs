using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Logique d'interaction pour ProductInfoUserControl.xaml
    /// </summary>
    public partial class ProductInfoUserControl : UserControl
    {
        private Product Product;
        public static readonly string ApplicationBaseUri = "pack://application:,,,/TP2;component";

        public ProductInfoUserControl() { InitializeComponent(); }

        public ProductInfoUserControl(Product product)
        {
            InitializeComponent();
            for (int i = 1; i < 4; i++)
            {
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(ApplicationBaseUri + "/Assets/Steam/Gameplay/" + product.Short + i + ".jpg");
                bitmap.EndInit();
                if (i == 1)
                {
                    Image1.Source = bitmap;
                }
                if (i == 2)
                {
                    Image2.Source = bitmap;
                }
                if (i == 3)
                {
                    Image3.Source = bitmap;
                }
            }

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

            Product = product;
            Name.Text = product.Name;
            
            if (product.Ratings > 1000)
            {
                Ratings.Text = ("très positives ("+product.Ratings.ToString()+")");

            }
            else
                Ratings.Text = ("positives (" + product.Ratings.ToString() + ")");
                   

        }

      
    }
}
