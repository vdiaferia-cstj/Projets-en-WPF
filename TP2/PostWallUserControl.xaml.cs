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
    /// Logique d'interaction pour PostWallUserControl.xaml
    /// </summary>
    public partial class PostWallUserControl : UserControl
    {
        private Post Post_it;
        public static readonly string ApplicationBaseUri = "pack://application:,,,/TP2;component";
        public PostWallUserControl() { InitializeComponent(); }

        public PostWallUserControl(Post post)
        {
            InitializeComponent();

            Post_it = post;
            Firstname.Text = post.Firstname;
            Publication.Source =  new BitmapImage(App.getUri(post.Image));
            Title.Text = post.Title;
            Date.Text = Convert.ToString(post.DateAndTime);
            Description.Text = post.Description;



        }
    }
}
