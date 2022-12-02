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
            InitialiserMaker();
            InitialiserBrand();

            comboMaker.SelectionChanged += ComboMaker_SelectionChanged;
        }

        private void ComboMaker_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           

           var cars = App.Current.Autos.Values.Where(x => x.Maker == comboMaker.SelectedItem.ToString());
            var brands = cars.Select(x => x.Brand).Distinct();
            comboBrand.Items.Clear();
             foreach (var brand in brands)
             {
                 comboBrand.Items.Add(brand);
             }
             
        }

        private void InitialiserMaker()
        {
            IEnumerable<string> makers;
            makers = App.Current.Autos.Values.Select(x => x.Maker);
            makers = makers.Distinct();

            foreach (var maker in makers)
            {
                comboMaker.Items.Add(maker); 
            }
        }
        private void InitialiserBrand()
        {
            IEnumerable<string> brands;
            brands = App.Current.Autos.Values.Select(x => x.Brand);
            brands = brands.Distinct();
            foreach (var brand in brands)
            {
                comboBrand.Items.Add(brand);
            }


            
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
                autos = App.Current.Autos.Values;
                //radio button
                if (SortDate.IsChecked == true)
                {    
                     autos = autos.OrderByDescending(x => x.Date);
                }
                if (SortPrice.IsChecked == true)
                {
                     autos = autos.OrderBy(x => x.Price);
                }
                //price
                if (Min.Text != "" && Max.Text != "")
                {
                    autos = autos.Where(x => x.Price >= Convert.ToDouble( Min.Text) && x.Price <= Convert.ToDouble(Max.Text));                   
                }
                else if (Min.Text != "")
                {
                    autos = autos.Where(x => x.Price >= Convert.ToDouble(Min.Text));
                }
                else if (Max.Text != "")
                {
                    autos = autos.Where(x => x.Price <= Convert.ToDouble(Max.Text));
                }
                //maker
                if (comboMaker.SelectedIndex != -1)
                {
                    autos = autos.Where(x => x.Maker == comboMaker.SelectedItem.ToString());
                }
                //brand
                if (comboBrand.SelectedIndex != -1)
                {
                    autos = autos.Where(x => x.Brand == comboBrand.SelectedItem.ToString());
                }
                //year
                if (yearMin.Text != "" && yearMax.Text != "")
                {
                    autos = autos.Where(x => x.Year >= Convert.ToInt32(yearMin.Text) && x.Year <= Convert.ToInt32(yearMax.Text));
                }
                else if (yearMin.Text != "")
                {
                    autos = autos.Where(x => x.Year >= Convert.ToInt32(yearMin.Text));
                }
                else if (yearMax.Text != "")
                {
                    autos = autos.Where(x => x.Year <= Convert.ToInt32(yearMax.Text));
                }
                //mileage
                if (mileageMin.Text != "" && mileageMax.Text != "")
                {
                    autos = autos.Where(x => x.Odometer >= Convert.ToInt32(mileageMin.Text) && x.Odometer <= Convert.ToInt32(mileageMax.Text));
                }
                else if (mileageMin.Text != "")
                {
                    autos = autos.Where(x => x.Odometer >= Convert.ToInt32(mileageMin.Text));
                }
                else if (mileageMax.Text != "")
                {
                    autos = autos.Where(x => x.Odometer <= Convert.ToInt32(mileageMax.Text));
                }

                foreach (var auto in autos)
                {
                    var productUserControl = new AutoUserControl(auto);
                    WrapPanelAutos.Children.Add(productUserControl);
                }
            }
            
        }

      
    }
}
