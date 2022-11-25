using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace TP2
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static new App Current { get { return (App)Application.Current; } }
        public static readonly string ApplicationBaseUri = "pack://application:,,,/TP2;component";
        public static Uri getUri(string image)
        {
            return new Uri(ApplicationBaseUri + image);
        }



        public Dictionary<int, Auto> Autos { get => _autos; }
        private readonly Dictionary<int, Auto> _autos = new Dictionary<int, Auto>()
        {
            {1,new Auto() { Image = "car1.jpg", Date = new DateTime(2021,11,19),Price = 6000, Maker = "Honda",Brand = "Accord",Year = 2014, Odometer = 170  }},
            {2,new Auto() { Image = "car2.jpg", Date = new DateTime(2021,11,1),Price = 5000, Maker = "Toyota",Brand = "Camry",Year = 2015, Odometer = 200  }},
            {3, new Auto(){ Image = "car3.jpg", Date = new DateTime(2021,11,21),Price = 8000, Maker="Nissan",Brand="Leaf",Year = 2013,Odometer= 210}},
            {4, new Auto(){ Image = "car4.jpg", Date = new DateTime(2021,11,21),Price = 10000, Maker="Toyota",Brand="Yaris",Year = 2021,Odometer= 20}},
            {5, new Auto(){ Image = "car5.jpg", Date = new DateTime(2021,11,23),Price = 1000, Maker="Honda",Brand="Civic",Year = 2001,Odometer= 350}},
            {6, new Auto(){ Image = "car6.jpg", Date = new DateTime(2021,11,23),Price = 6000, Maker="Honda",Brand="Civic",Year = 2011,Odometer= 140}},
            {7, new Auto(){ Image = "car7.jpg", Date = new DateTime(2021,11,25),Price = 20000, Maker="Toyota",Brand="Camry",Year = 2021,Odometer= 10}},
            {8, new Auto(){ Image = "car8.jpg", Date = new DateTime(2021,11,25),Price = 7000, Maker="Nissan",Brand="Infiniti",Year = 2015,Odometer= 150}},
            {9, new Auto(){ Image = "car9.jpg", Date = new DateTime(2021,11,27),Price = 9000, Maker="Nissan",Brand="Infiniti",Year = 2016,Odometer= 170}},
            {10, new Auto(){ Image = "car10.jpg",Date = new DateTime(2021,11,27),Price = 12000, Maker="Honda",Brand="Accord",Year = 2018,Odometer= 90}},
            {11, new Auto(){ Image = "car11.jpg",Date = new DateTime(2021,11,29),Price = 5000, Maker="Toyota",Brand="Yaris",Year = 2013,Odometer= 210}},
            {12, new Auto(){ Image = "car12.jpg",Date = new DateTime(2021,11,29),Price = 2000, Maker="Nissan",Brand="Altima",Year = 2003,Odometer= 320 }}


        };

        public Dictionary<int, User> Users { get => _user; }
        private readonly Dictionary<int, User> _user = new Dictionary<int, User>()
        {
            {1,new User() {Id=1, Image = "user1.jpg", FirstName= "Tom", LastName  ="Richards"}},
            {2,new User() {Id=2, Image = "user2.jpg", FirstName= "Elliot",LastName  ="Hart"}},
            {3,new User() {Id=3, Image = "user3.jpg", FirstName= "Rachel",LastName  ="Chapman"}},
            {4,new User() {Id=4, Image = "user4.jpg", FirstName= "Myriam",LastName  ="Leblanc"}},
            {5,new User() {Id=5, Image = "user5.jpg", FirstName= "Paul", LastName ="Burnham"}},



        };


        // ENLEVER TOUT LES NOMS DANS LA BASE DE DONNEE
        // DE FRIENDS
        public Dictionary<int, Friends> Friend { get => _friend; }
        private readonly Dictionary<int, Friends> _friend = new Dictionary<int, Friends>()
        {
             {1,new Friends() {UserId = 1,FriendId=2,  FirstNameUser= "Tom", FirstNameFriend  ="Elliot"}},
             {2,new Friends() {UserId = 1,FriendId=3,  FirstNameUser= "Tom", FirstNameFriend  ="Rachel"}},
             {3,new Friends() {UserId = 1,FriendId=4,  FirstNameUser= "Tom", FirstNameFriend  ="Myriam"}},
             {4,new Friends() {UserId = 2,FriendId=3,  FirstNameUser= "Elliot", FirstNameFriend  ="Rachel"}},
             {5,new Friends() {UserId = 3,FriendId=4,  FirstNameUser= "Rachel", FirstNameFriend  ="Myriam"}},
        };

        public Dictionary<int,Post> UnPost { get => _post; }
        private readonly Dictionary<int, Post> _post = new Dictionary<int, Post>()
        {
            {1, new Post(){Id = 1,Title="Nice snack with a book", Description="Salut les potes", Image = "/Assets/Posts/post1.jpg", DateAndTime = new DateTime(2021-11-20), Visibilty="Public" } },
            {2, new Post(){Id = 2,Title="Relaxing night at the beach", Description="Salut les potes", Image = "/Assets/Posts/post1.jpg", DateAndTime = new DateTime(2021-11-20), Visibilty="Public" } },
            {3, new Post(){Id = 3,Title="Trekking in the woods", Description="Salut les potes", Image = "/Assets/Posts/post1.jpg", DateAndTime = new DateTime(2021-11-20), Visibilty="Public" } },
            {4, new Post(){Id = 4,Title="King of the world!", Description="Salut les potes", Image = "/Assets/Posts/post1.jpg", DateAndTime = new DateTime(2021-11-20), Visibilty="Public" } },
            {5, new Post(){Id = 5,Title="After work", Description="Salut les potes", Image = "/Assets/Posts/post1.jpg", DateAndTime = new DateTime(2021-11-20), Visibilty="Public" } },
            {6, new Post(){Id = 1,Title="New Zealand 2017", Description="Salut les potes", Image = "/Assets/Posts/post1.jpg", DateAndTime = new DateTime(2021-11-20), Visibilty="FriendsOnly" } },
            {7, new Post(){Id = 1,Title="Sweden 2018", Description="Salut les potes", Image = "/Assets/Posts/post1.jpg", DateAndTime = new DateTime(2021-11-20), Visibilty="Public" } },
            {8, new Post(){Id = 1,Title="Internet cafe Sundays", Description="Salut les potes", Image = "/Assets/Posts/post1.jpg", DateAndTime = new DateTime(2021-11-20), Visibilty="Public" } },
            {9, new Post(){Id = 2,Title="Surprise!", Description="Salut les potes", Image = "/Assets/Posts/post1.jpg", DateAndTime = new DateTime(2021-11-20), Visibilty="Public" } },
            {10, new Post(){Id = 2,Title="Secret painting", Description="Salut les potes", Image = "/Assets/Posts/post1.jpg", DateAndTime = new DateTime(2021-11-20), Visibilty="Public" } }

        };

    }
}
