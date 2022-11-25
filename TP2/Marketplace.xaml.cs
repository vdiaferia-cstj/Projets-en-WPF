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
            comboBoxCategory.SelectionChanged += comboBoxCategory_SelectionChanged;
            comboBoxCategory.SelectedIndex = 1;
        }      

        private void AfficherAppliances()
        {
            WrapPanelAutos.Children.Clear();
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
        private void AfficherRentals()
        {
            WrapPanelAutos.Children.Clear();
        }

        private void comboBoxCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (comboBoxCategory.SelectedIndex)
            {
                case 0:
                    AfficherAppliances();
                    break;
                case 1:
                    AfficherAutos();
                    break;
                case 2:
                    AfficherRentals();
                    break;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (comboBoxCategory.SelectedIndex == 1)
            {
                WrapPanelAutos.Children.Clear();
                IEnumerable<Auto> autos;
                if (SortDate.IsChecked == true)
                {
                    
                     autos = App.Current.Autos.Values.OrderBy(x => x.Date);
                    foreach (var auto in autos)
                    {
                        var productUserControl = new AutoUserControl(auto);
                        WrapPanelAutos.Children.Add(productUserControl);
                    }
                }
                if (SortPrice.IsChecked == true)
                {
                    
                     autos = App.Current.Autos.Values.OrderBy(x => x.Price);
                    foreach (var auto in autos)
                    {
                        var productUserControl = new AutoUserControl(auto);
                        WrapPanelAutos.Children.Add(productUserControl);
                    }
                }

                if (Min != null & Max != null)
                {

                }
                else if (Min != null  )
                {

                }
            }
            
        }
    }
}
