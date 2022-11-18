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
    /// Logique d'interaction pour Marketplace.xaml
    /// </summary>
    public partial class Marketplace : Window
    {
        public Marketplace()
        {
            InitializeComponent();
            AfficherAutos();
        }

        private void AfficherAutos()
        {
            WrapPanelAutos.Children.Clear();
            foreach (var auto in App.Current.Autos)
            {
                var productUserControl = new AutoUserControl(auto.Value);
                WrapPanelAutos.Children.Add(productUserControl);
            }
        }
    }
}
