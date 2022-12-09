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

namespace TP2
{
    /// <summary>
    /// Logique d'interaction pour PostWallUserControl.xaml
    /// </summary>
    public partial class PostWallUserControl : UserControl
    {
        private Post Post_it;
        public static readonly string ApplicationBaseUri = "pack://application:,,,/TP2;component";
        public PostWallUserControl() { InitializeComponent(); }
        public PostWallUserControl(Post post, User userLoggedIn)
        {
            InitializeComponent();
            InformationDunUser(post);
            InformationDuPost(post, userLoggedIn);
        }
        private void InformationDunUser(Post post)
        {
            var TrouverIdPost = App.Current.Users.Values.Where(x => x.Id == post.IdUser);
            foreach (var item in TrouverIdPost)
            {
                Firstname.Text = item.FirstName;
                LastName.Text = item.LastName;
                imageUser.Source = new BitmapImage(App.getUri(item.Image));


            }
        }

        private void InformationDuPost(Post post, User userloggedIn)
        {
            Post_it = post;
            Publication.Source = new BitmapImage(App.getUri(post.Image));
            Title.Text = post.Title;
            Date.Text = post.DateAndTime.ToString("yyyy-MM-dd");
            Description.Text = post.Description;


            var thereaction = post.Reaction;

            var theid = post.Reaction.ContainsKey(post.IdUser);
            var theid2 = post.Reaction.Values.Select(x => x.Equals(theid)).ToList();

            foreach (var item in thereaction)
            {
                Debug.WriteLine(item.Key.ToString() + "  " + item.Value);

                //Si c'est le meme id que le user connecter
                if (userloggedIn.Id == item.Key)
                {

                    switch (item.Value)
                    {
                        case "sad":
                            sad.IsChecked = true;
                            break;
                        case "love":
                            love.IsChecked = true;
                            break;
                        case "angry":
                            angry.IsChecked = true;
                            break;
                        case "like":
                            like.IsChecked = true;
                            break;
                    }
                }

            }
        }
    }
}
