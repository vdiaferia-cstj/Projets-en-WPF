using System;
using System.Collections.Generic;
using System.Configuration;
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

namespace TP2
{
    /// <summary>
    /// Logique d'interaction pour Wall.xaml
    /// </summary>
    public partial class Wall : Window
    {
        
        public User LesUsers => (User)LesUtilisateurs.SelectedItem;
        public User ModeView => (User)View.SelectedItem;

        public static readonly string ApplicationBaseUri = "pack://application:,,,/TP2;component";
    

        public Wall()
        {
            InitializeComponent();
            FindUser();
          
        }

        public void FindUser()
        {
            foreach (var user in App.Current.Users.Values)
            {

                LesUtilisateurs.Items.Add(user);

            }

            View.Items.Add("All Users");
            View.Items.Add("Friends");
            foreach (var view in App.Current.Users.Values)
            {

                View.Items.Add(view);
            }


        }

        public void FindFriends()
        {

            laComboBox.Items.Clear();


            var friends = App.Current.Friend.Values.Where(x => x.UserId == LesUsers.Id); 
            foreach (var reponse in friends)
            {
                laComboBox.Items.Add(reponse.FirstNameFriend); // remplacer VIEW par le nom de la liste 
            }
            var friendsAgain = App.Current.Friend.Values.Where(x => x.FriendId == LesUsers.Id);
            foreach (var reponse in friendsAgain)
            {
                laComboBox.Items.Add(reponse.FirstNameUser);  // remplacer VIEW par le nom de la liste

            }


        }

        public void AfficherUser()
        {
            var TrouverImage = App.Current.Users.Values.Where(x => x.Id == LesUsers.Id);
            foreach (var found in TrouverImage)
            {

                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(ApplicationBaseUri + "/Assets/Users/" + found.Image);
                bitmap.EndInit();

                taFace.Source = bitmap;
                NomUser.Text = LesUsers.FirstName + " " + LesUsers.LastName;
            }



            
        }

        private void LesUtilisateurs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            AfficherUser();
            FindFriends();

            
        }

        private void View_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
          
        }
    }
}
