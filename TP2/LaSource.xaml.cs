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
using System.Windows.Shapes;
using TP2.Classes;

namespace TP2
{
    
    // LIEN POUR LE SITE : https://www.thesource.ca/fr-ca/produits-en-vedette/c/featured-deals?q=%3Arelevance%3AproductOffers%3AOnSale&view=grid&categoryCode=featured-deals&page=0&sort=relevance&gclid=Cj0KCQiA14WdBhD8ARIsANao07gUUsK65w3W0K7_GHg6Ihq46VeUOOwSW_TvCIw5IVyfsdMcobpd83MaAtC-EALw_wcB&gclsrc=aw.ds

    public partial class LaSource : Window
    {
        public static readonly string ApplicationBaseUri = "pack://application:,,,/TP2;component/";
        public Article ArticleComboxBox => (Article)Tri.SelectedItem;
        public UsersSource LesUsersComboBox => (UsersSource)LesUsers.SelectedItem;
        
        public LaSource()
        {
            InitializeComponent();
            Execution();
        }
        // -------------------------------------------------------------------------------------------------------------
        // -------------------------------------------------------------------------------------------------------------
        public void Execution()
        {
            AfficherLogo();
            DisplayProductOnPage();
            InsererUser();
            Tri.SelectedIndex = 0;
            Tri.Items.Add("Par Avis (Desc)");
            Tri.Items.Add("Par Avis (Asc)");
            Tri.Items.Add("Par Prix (Desc)");
            Tri.Items.Add("Par Prix (Asc)");



        }
        // -------------------------------------------------------------------------------------------------------------
        // -------------------------------------------------------------------------------------------------------------
        public void InsererUser()
        {
            foreach (var user in App.Current.UsersSource.Values)
            {
                LesUsers.Items.Add(user);
            }
        }
        public void DisplayInfoUser()
        {
            var foundUser = App.Current.UsersSource.Values.Where(x => x.Id == LesUsersComboBox.Id);
            foreach (var user in foundUser)
            {
                UserConnected.Text = user.FirstName + " " + user.LastName;
                Courriel.Text = user.Courriel;
            }

        }
        // -------------------------------------------------------------------------------------------------------------
        // -------------------------------------------------------------------------------------------------------------
        public void AfficherLogo()
        {
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(ApplicationBaseUri + "/Assets/LaSource/Logo.png");
            bitmap.EndInit();

            leLogo.Source = bitmap;
        }
        // -------------------------------------------------------------------------------------------------------------
        // -------------------------------------------------------------------------------------------------------------

        public void DisplayProductOnPage()
        {
            StackPanelProduct.Children.Clear();
            foreach (var product in App.Current.Articles)
            {
                var article = new DisplayProductsControl(product.Value);
                StackPanelProduct.Children.Add(article);

            }
            var total = App.Current.Articles.Count;
            Total.Text = total.ToString();
        }
        // -------------------------------------------------------------------------------------------------------------
        // -------------------------------------------------------------------------------------------------------------

        public void DisplayByTri()
        {

            switch (Tri.SelectedIndex)
            {
                case 0:
                    StackPanelProduct.Children.Clear();
                    var AvisDesc = App.Current.Articles.Values.OrderByDescending(x => x.Avis);
                    foreach (var product in AvisDesc)
                    {
                        var article = new DisplayProductsControl(product);
                        StackPanelProduct.Children.Add(article);
                    }
                    break;
                case 1:
                    StackPanelProduct.Children.Clear();
                    var AvisAsc = App.Current.Articles.Values.OrderBy(x => x.Avis);
                    foreach (var product in AvisAsc)
                    {
                        var article = new DisplayProductsControl(product);
                        StackPanelProduct.Children.Add(article);
                    }
                    break;
                case 2:
                    StackPanelProduct.Children.Clear();
                    var PrixDesc = App.Current.Articles.Values.OrderByDescending(x => x.prix);
                    foreach (var product in PrixDesc)
                    {
                        var article = new DisplayProductsControl(product);
                        StackPanelProduct.Children.Add(article);
                    }
                    break;
                case 3:
                    StackPanelProduct.Children.Clear();
                    var PrixAsc = App.Current.Articles.Values.OrderBy(x => x.prix);
                    foreach (var product in PrixAsc)
                    {
                        var article = new DisplayProductsControl(product);
                        StackPanelProduct.Children.Add(article);
                    }
                    break;
            }


        }



        private void Tri_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Samsung.IsChecked = false;
            Asus.IsChecked = false;
            Apple.IsChecked = false;
            DisplayByTri();
        }

        // -------------------------------------------------------------------------------------------------------------
        // -------------------------------------------------------------------------------------------------------------'

        public void DisplayByCategory(IEnumerable<Article> article)
        {
            var trouver = article;
            if (Utilitaire.IsChecked == true)
            {
                trouver = trouver.Where(x => x.Categorie == "Utilitaire").OrderBy(x => x.nom);
            }
            else if (Accessoire.IsChecked == true)
            {
                trouver = trouver.Where(x => x.Categorie == "Accessoire").OrderBy(x => x.nom);
            }
            else if (Ecran.IsChecked == true)
            {
                trouver = trouver.Where(x => x.Categorie == "Ecran").OrderBy(x => x.nom);
            }

            foreach (var product in trouver)
            {
                var add = new DisplayProductsControl(product);
                StackPanelProduct.Children.Add(add);
            }

        }

        public void DisplayByBrand()
        {
            if (Samsung.IsChecked == true)
            {
                StackPanelProduct.Children.Clear();
                var samsungArticle = App.Current.Articles.Values.Where(x => x.Marque == "Samsung");
                DisplayByCategory(samsungArticle);
            }
            else if (Apple.IsChecked == true)
            {
                StackPanelProduct.Children.Clear();
                var samsungArticle = App.Current.Articles.Values.Where(x => x.Marque == "Apple");
                DisplayByCategory(samsungArticle);
            }
            else if (Asus.IsChecked == true)
            {
                StackPanelProduct.Children.Clear();
                var samsungArticle = App.Current.Articles.Values.Where(x => x.Marque == "Asus");
                DisplayByCategory(samsungArticle);
            }
        }
        // -------------------------------------------------------------------------------------------------------------
        // -------------------------------------------------------------------------------------------------------------

        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            DisplayByBrand();
        }

        private void RadioButton_Click_1(object sender, RoutedEventArgs e)
        {
            DisplayByBrand();

        }

        private void RadioButton_Click_2(object sender, RoutedEventArgs e)
        {
            DisplayByBrand();
        }

        private void Utilitaire_Checked(object sender, RoutedEventArgs e)
        {
            DisplayByBrand();
        }

        private void Accessoire_Checked(object sender, RoutedEventArgs e)
        {
            DisplayByBrand();
        }

        private void Ecran_Checked(object sender, RoutedEventArgs e)
        {
            DisplayByBrand();
        }
        // -------------------------------------------------------------------------------------------------------------
        // -------------------------------------------------------------------------------------------------------------


        private void LesUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DisplayInfoUser();
        }
        // -------------------------------------------------------------------------------------------------------------
        // -------------------------------------------------------------------------------------------------------------
        public void LeCart()
        {
            var total = (App.Current.Cart.Count + 1);
            leTotal.Text = total.ToString();
        }

        public void SupprimerArticle()
        {

        }
    }
}
