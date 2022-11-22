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

            //View.Items.Add("All Users");
            //View.Items.Add("Friends");
            //foreach (var view in App.Current.Users.Values)
            //{

            //    View.Items.Add(view);
            //}


        }

        public void FindFriends()
        {
            //foreach (var user in App.Current.Users.Values)
            //{
            //    foreach (var friends in App.Current.Friend.Values)
            //    {
            //        if (friends.FirstNameUser == user.FirstName)
            //        {
            //            View.Items.Add(friends);
            //        }
            //    }
            //}
            View.Items.Clear();

           
                var friends = App.Current.Friend.Values.Where(x => x.UserId == LesUsers.Id); // JE PEUX FAIRE DES &&
                foreach ( var reponse in friends)
                {
                    View.Items.Add(reponse.FirstNameFriend);
                }



            
        }

        public void AfficherUser()
        {

            NomUser.Text = LesUsers.FirstName + " " + LesUsers.LastName;

            
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
