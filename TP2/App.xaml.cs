using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using TP2.Classes;

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


        public List<Product> Products { get => _products; }
        private readonly List<Product> _products = new List<Product>()
        {
           new NewProduct(){Id=1,Name="Choo-Choo Charles",Short="ccc",BasePrice=25.99,Tags = new string[]{"Horreur","Monde ouvert"},Image="choochoocharles.jpg",OS = "Mac", DateSortie=new DateTime(2022,12,13), Ratings = 37},
           new PopularProduct(){Id=2,Name="GTA V",Short="gta",BasePrice=49.99,Tags = new string[]{"Monde ouvert","Action","Multijoueur"},OS = "Windows",Image="gta5.jpg",Ratings = 560948,NbSales = 100000},
           new ProductOnSale(){Id=3,Name="Hunt Showdown",Short="hs",BasePrice=54,SalePrice=21.60,OS = "Windows",Image="r6.jpg",Tags=new string[]{"Tactique","Survie"},Ratings = 115201 },
           new NewProduct(){Id=4,Name="High On Life",Short="highonlife",BasePrice=68.99,Tags = new string[] {"FPS","Comédie" },Image="highonlife.jpg",OS="Mac",DateSortie=new DateTime(2022,12,14),Ratings = 975},
           new PopularProduct(){Id=5,Name="R6",Short="r6",BasePrice=39.99,Tags = new string[]{"Stratégie","Rageant","Multijoueur"},Image="r6.jpg",OS="Mac",Ratings=57941,NbSales = 1000000},
           new ComingSoonProduct(){Id=6,Name="The House of Da Vinci 3",Short="thodv",PreOrderPrice=89.99,BasePrice=69.99,Image="houseofdavinci3.jpg",DatePreOrderSortie=new DateTime(2023,01,01),OS="Mac",Ratings=0,Tags = new string[]{"Casse tête","Aventure"}},
           new ProductOnSale(){Id=8,Name="CSGO",Short="csgo",BasePrice=38.99,SalePrice=10.65,OS = "Windows",Image="r6.jpg",Tags=new string[]{"Tactique","Survie"},Ratings = 115201 },
           new Product(){Id=7,Name="Rust",Short="rust",BasePrice=50.99,OS="Windows",Tags = new string[]{"Rageant","Multijoueur","Monde ouvert"},Image="rust.jpg",Ratings=259093}
        };

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
            {1,new User() {Id=1, Image = "/Assets/Users/user1.jpg", FirstName= "Tom", LastName  ="Richards",  Fr = new List<int>{2,3,4}} },
            {2,new User() {Id=2, Image = "/Assets/Users/user2.jpg", FirstName= "Elliot",LastName  ="Hart",Fr = new List<int>{3,1}} },
            {3,new User() {Id=3, Image = "/Assets/Users/user3.jpg", FirstName= "Rachel",LastName  ="Chapman",Fr = new List<int>{4,1,2}}},
            {4,new User() {Id=4, Image = "/Assets/Users/user4.jpg", FirstName= "Myriam",LastName  ="Leblanc",Fr = new List<int>{3,1} } },
            {5,new User() {Id=5, Image = "/Assets/Users/user5.jpg", FirstName= "Paul", LastName ="Burnham"}},




    };


        public Dictionary<int, Post> UnPost { get => _post; }
        private readonly Dictionary<int, Post> _post = new Dictionary<int, Post>()
        {
            {1, new Post(){Id=1, IdUser = 1,Title="Nice snack with a book", Description="SOS, Gaïa SOS, Gaïa SOS, Gaïa SOS, Gaïa", Image = "/Assets/Posts/post1.jpg", DateAndTime = new DateTime(2021,11,21), Visibilty="Public",Reaction = new Dictionary<int, string>{} } },
            {2, new Post(){Id=2, IdUser = 2,Title="Relaxing night at the beach", Description="Honnetement la beach c'est sick en criss", Image = "/Assets/Posts/post2.jpg", DateAndTime = new DateTime(2021,11,22), Visibilty="Public",Reaction = new Dictionary<int, string>{{1,"like"} }  } },
            {3, new Post(){Id=3, IdUser = 3,Title="Trekking in the woods", Description="Orgore moe donc la vue", Image = "/Assets/Posts/post3.jpg", DateAndTime = new DateTime(2021,11,23), Visibilty="Public",Reaction = new Dictionary<int, string>{{1,"love"} } } } ,
            {4, new Post(){Id=4, IdUser = 4,Title="King of the world!", Description="bin oui", Image = "/Assets/Posts/post4.jpg", DateAndTime = new DateTime(2021,11,24), Visibilty="Public",Reaction = new Dictionary<int, string> { { 1, "sad" }, {2,"angry" }  } } },
            {5, new Post() { Id = 5, IdUser = 5,Title = "After work", Description = "La plupart du temps, en revenant de la job je me fais un esti de bon spagat", Image = "/Assets/Posts/post5.jpg", DateAndTime = new DateTime(2021, 11, 25), Visibilty = "Public", Reaction = new Dictionary<int, string> {  } } } ,
            {6, new Post() { Id = 6, IdUser = 1,Title = "New Zealand 2017", Description = "A la manifestatioooonnnnn, on revait de revolution !!!!!!", Image = "/Assets/Posts/post6.jpg", DateAndTime = new DateTime(2021, 11, 19), Visibilty = "FriendsOnly", Reaction = new Dictionary<int, string> { { 2, "love" } } } } ,
            {7, new Post(){Id=7, IdUser = 1,Title="Sweden 2018", Description="Les osti de voyage, quoi de plus plate comme post ", Image = "/Assets/Posts/post7.jpg", DateAndTime = new DateTime(2021,11,20), Visibilty="Public", Reaction = new Dictionary<int, string> { { 3, "sad" } } }  },
            {8, new Post(){Id=8, IdUser = 1,Title="Internet cafe Sundays", Description="Gros meeting pour bring back le trip des Power Rangers", Image = "/Assets/Posts/post8.jpg", DateAndTime = new DateTime(2021,11,20), Visibilty="Public", Reaction = new Dictionary<int, string> {  } } } ,
            {9, new Post(){Id=9, IdUser = 2,Title="Surprise!", Description="YOUPIDOU", Image = "/Assets/Posts/post9.jpg", DateAndTime = new DateTime(2021,11,20), Visibilty="Public", Reaction = new Dictionary<int, string> { { 1, "like" }, { 3, "like" } } } },
            {10,new Post(){Id=10, IdUser = 2,Title="Secret painting", Description="Tu veux je dise quoi en description", Image = "/Assets/Posts/post10.jpg", DateAndTime = new DateTime(2021,11,20), Visibilty="Public", Reaction = new Dictionary<int, string> { { 2, "sad" } } } }

        };


        public Dictionary<int, int> Cart = new Dictionary<int, int>();

        public Dictionary<int, UsersSource> UsersSource { get => _userSource; }
        private readonly Dictionary<int, UsersSource> _userSource = new Dictionary<int, UsersSource>()
        {
            {1,new UsersSource() {Id=1, Courriel="Lafortune@outlook.com", FirstName= "Simon", LastName  ="Lafortune",  } },
            {2,new UsersSource() {Id=2, Courriel="LR@hotmail.com", FirstName= "Ludo",LastName  ="Robichaud",} },
            {3,new UsersSource() {Id=3, Courriel="VFournier@outlook.com", FirstName= "Vincent",LastName  ="Fournier",}},
            {4,new UsersSource() {Id=4, Courriel="DiafCed@gmail.com", FirstName= "Cedrick",LastName  ="Diaferia",} },
            {5,new UsersSource() {Id=5, Courriel="dav@outlook.com", FirstName= "David", LastName ="Groulx"}},
    };

        public Dictionary<int, Article> Articles { get => _article; }
        private readonly Dictionary<int, Article> _article = new Dictionary<int, Article>()
        {
            {1,new Article() {id=1,Marque="Samsung",Categorie="Utilitaire", image="/Assets/LaSource/Polaroid.jpg",prix=15.99, nom="Polaroid qui a bin de l'allure ! ", disponibiliteEnLigne="Non Disponible", disponibiliteEnMagasin="Disponible", Avis="4" } },
            {2,new Article() {id=2,Marque="Samsung",Categorie="Utilitaire", image="/Assets/LaSource/Watch.jpg",prix=299.99, nom="montre (tout ce qui a de plus normal)", disponibiliteEnLigne="Non Disponible", disponibiliteEnMagasin="Non Disponible", Avis="2" } },
            {3,new Article() {id=3,Marque="Apple",Categorie="Accessoire", image="/Assets/LaSource/Controller.jpg",prix=79.99, nom="manette xbox", disponibiliteEnLigne="Disponible", disponibiliteEnMagasin="Disponible", Avis="4" } },
            {4,new Article() {id=4,Marque="Samsung",Categorie="Ecran", image="/Assets/LaSource/Tablette.jpg",prix=899.99, nom="belle tite tablette", disponibiliteEnLigne="Non Disponible", disponibiliteEnMagasin="Non Disponible", Avis="5" } },
            {5,new Article() {id=5,Marque="Apple",Categorie="Accessoire", image="/Assets/LaSource/Airpods.jpg",prix=299.99, nom="Un ecouteur ( y en manque un )", disponibiliteEnLigne="Disponible", disponibiliteEnMagasin="Disponible", Avis="0" } },
            {6,new Article() {id=6,Marque="Asus",Categorie="Ecran", image="/Assets/LaSource/UnEcran.jpg",prix=199.99, nom="ecran poche", disponibiliteEnLigne="Disponible", disponibiliteEnMagasin="Non Disponible", Avis="1" } },
    };
    }
}
