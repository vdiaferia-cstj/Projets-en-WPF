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


        public Dictionary<int, Auto> Autos { get => _autos; }
        private readonly Dictionary<int, Auto> _autos = new Dictionary<int, Auto>()
        {
            { 1, new Auto() { Image = "car1.jpg", Date = new DateTime(2021,11,19), Price = 6000, Maker = "Honda", Brand = "Accord", Year = 2014, Odometer = 170  } },
            { 2, new Auto() { Date = new DateTime(2021,11,19), Price = 6000, Maker = "Honda", Brand = "Accord", Year = 2014, Odometer = 170  } },


        };

        public Dictionary<int, User> Users { get => _user; }
        private readonly Dictionary<int, User> _user = new Dictionary<int, User>()
        {



        };

    }
}
