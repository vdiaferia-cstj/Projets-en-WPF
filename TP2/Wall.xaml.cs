using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Printing;
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
        public User user = new User();
        public User LesUsers => (User)LesUtilisateurs.SelectedItem;
        public User ModeView => (User)View.SelectedItem;
        public User UserLoggedIn => App.Current.Users.Values.Where(x => x.Id == LesUsers.Id).First();

        public static readonly string ApplicationBaseUri = "pack://application:,,,/TP2;component";

        // -------------------------------------------------------------------------------------------------------------
        // -------------------------------------------------------------------------------------------------------------
        public Wall()
        {
           
            InitializeComponent();
            FindUser();
            DisplayPost();
            if (parDatePoto.IsChecked == true)
            {
                DisplayPostByDate();
            }
           
        }
        // -------------------------------------------------------------------------------------------------------------
        // -------------------------------------------------------------------------------------------------------------
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
        // -------------------------------------------------------------------------------------------------------------
        // -------------------------------------------------------------------------------------------------------------
        public void FindFriends()
        {

            laComboBox.Items.Clear();
            //View.Items.Clear();

            foreach (var userA in App.Current.Users.Values)
            {
                foreach (var userB in userA.Fr)
                {
                    if (LesUsers.Id == userB)
                    {
                        laComboBox.Items.Add(userA.FirstName + " " + userA.LastName);
                    }

                }
            }
        }
        // -------------------------------------------------------------------------------------------------------------
        // -------------------------------------------------------------------------------------------------------------
        public void AfficherUser()
        {
            var TrouverImage = App.Current.Users.Values.Where(x => x.Id == LesUsers.Id);
            foreach (var found in TrouverImage)
            {

                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(ApplicationBaseUri + found.Image);
                bitmap.EndInit();

                taFace.Source = bitmap;
                NomUser.Text = LesUsers.FirstName + " " + LesUsers.LastName;
            }          
        }
        // -------------------------------------------------------------------------------------------------------------
        // -------------------------------------------------------------------------------------------------------------
        public void DisplayPost() {
            StackPanelInfo.Children.Clear();
            foreach (var posts in App.Current.UnPost)
            {
              
                    var postOnTheWall = new PostWallUserControl(posts.Value,UserLoggedIn);
                    StackPanelInfo.Children.Add(postOnTheWall);
                
    
            }

        }
        // -------------------------------------------------------------------------------------------------------------
        // -------------------------------------------------------------------------------------------------------------
        private void DisplayPostByDate()
        {
            StackPanelInfo.Children.Clear();
            var date = App.Current.UnPost.Values.OrderBy(x => x.DateAndTime);
            foreach (var trie in date)
            {
                var postOnTheWall = new PostWallUserControl(trie, UserLoggedIn);
                StackPanelInfo.Children.Add(postOnTheWall);
            }
        }
        // -------------------------------------------------------------------------------------------------------------
        // -------------------------------------------------------------------------------------------------------------
        private void DisplayByUser()
        {
            User user =new User();
            if (View.SelectedItem == "Friends")
            {
                StackPanelInfo.Children.Clear();
                var qqch = LesUsers.UserPost;
                foreach (var postFriend in qqch)
                {
                    var post = new PostWallUserControl(postFriend, UserLoggedIn);
                    StackPanelInfo.Children.Add(post);
                }
            }

            if (View.SelectedItem == "All Users")
            {
                StackPanelInfo.Children.Clear();
                var postOnTheWall = App.Current.UnPost.Values;

                foreach (var postFriend in postOnTheWall)
                {
                    var post = new PostWallUserControl(postFriend,UserLoggedIn);
                    StackPanelInfo.Children.Add(post);
                }

            }

            if (View.SelectedItem!="Friends" && View.SelectedItem != "All Users")
            {
                var theUser = App.Current.UnPost.Values.Where(x => x.IdUser == ModeView.Id);
                
                StackPanelInfo.Children.Clear();

                foreach (var postOfTom in theUser)
                {
                    var postOnTheWall = new PostWallUserControl(postOfTom, UserLoggedIn);
                    StackPanelInfo.Children.Add(postOnTheWall);
                }

            }
        }

        // -------------------------------------------------------------------------------------------------------------
        // -------------------------------------------------------------------------------------------------------------

        private void ResetPostForUser()
        {
            StackPanelInfo.Children.Clear();

            //var theUser = App.Current.UnPost.Values.Where(x => x.IdUser == ModeView.Id);
            //var loggedInUser = App.Current.Users.Values.Where(x => x.Id == LesUsers.Id).FirstOrDefault();
            if (ModeView != null)
            {
                var posts = App.Current.UnPost.Values.Where(y => y.IdUser == ModeView.Id);
                foreach (var p in posts)
                {
                    var postOnTheWall = new PostWallUserControl(p, UserLoggedIn);
                    StackPanelInfo.Children.Add(postOnTheWall);
                }

            }


        }
        // -------------------------------------------------------------------------------------------------------------
        // -------------------------------------------------------------------------------------------------------------

        private void LesUtilisateurs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            AfficherUser();
            FindFriends();
            ResetPostForUser();
        }
        // -------------------------------------------------------------------------------------------------------------
        // -------------------------------------------------------------------------------------------------------------
        private void View_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            DisplayByUser();
        }
        // -------------------------------------------------------------------------------------------------------------
        // -------------------------------------------------------------------------------------------------------------
        private void parDatePoto_Click(object sender, RoutedEventArgs e)
        {
            DisplayPostByDate();
        }
    }
}
