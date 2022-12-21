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
using TP2.Classes;

namespace TP2
{
    /// <summary>
    /// Logique d'interaction pour DisplayProductsControl.xaml
    /// </summary>
    public partial class DisplayProductsControl : UserControl
    {
        public static readonly string ApplicationBaseUri = "pack://application:,,,/TP2_Window_David;component";
        private Article miniArticle;
        
        public DisplayProductsControl(Article article)
        {
            InitializeComponent();
            DisplayProduct(article);
        }

        private void DisplayProduct(Article article)
        {
            var FoundProduct = App.Current.Articles.Values.Where(x => x.id == article.id);

            foreach (var item in FoundProduct)
            {
                Nom.Text = item.nom;
                imageProduct.Source = new BitmapImage(App.getUri(item.image));
                // Manquue le rating
                Price.Text = (item.prix).ToString() + " $";
                Rating.Text = item.Avis + "/5";
                DispoLigne.Text = item.disponibiliteEnLigne;
                DispoMag.Text = item.disponibiliteEnMagasin;


                //var message = MessageBox.Show($"Voulez-vous vraiment masquer {item.nom} ?", "Masquer", MessageBoxButton.YesNo, MessageBoxImage.Question);
                //if (message == MessageBoxResult.Yes)
                //{
                //    App.Current.Articles.Remove(item.id);
                //}
            }
        }

        private void Masquer_Click(object sender, RoutedEventArgs e)
        {


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
         

        }
    }
}

