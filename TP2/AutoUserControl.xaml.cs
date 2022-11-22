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
    /// Logique d'interaction pour AutoUserControl.xaml
    /// </summary>
    public partial class AutoUserControl : UserControl
    {
        private Auto Auto;
        public static readonly string ApplicationBaseUri = "pack://application:,,,/TP2;component";

        public AutoUserControl() { InitializeComponent(); }

        public AutoUserControl(Auto auto)
        {
            InitializeComponent();
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(ApplicationBaseUri + "/Assets/Offers/Cars/" + auto.Image);
            bitmap.EndInit();

            Auto = auto;
            AutoImage.Source = bitmap;
            AutoPrice.Text = Convert.ToString(auto.Price) + "$";
            AutoPublishDate.Text = auto.Date.ToString("yyyy-MM-dd");
            AutoBrand.Text = auto.Maker;
            AutoModel.Text = auto.Brand;

            // ProductId.Text = product.Id.ToString();
            // ProductName.Text = product.Name;
        }
    }
}
