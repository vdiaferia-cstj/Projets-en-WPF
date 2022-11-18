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

        public AutoUserControl() { InitializeComponent(); }

        public AutoUserControl(Auto auto)
        {
            InitializeComponent();

            Auto = auto;
            AutoImage.Text = auto.Image;
            AutoPrice.Text = Convert.ToString(auto.Price) + "$";
            AutoPublishDate.Text = Convert.ToString(auto.Date);
            AutoBrand.Text = auto.Maker;
            AutoModel.Text = auto.Brand;

            // ProductId.Text = product.Id.ToString();
            // ProductName.Text = product.Name;
        }
    }
}
