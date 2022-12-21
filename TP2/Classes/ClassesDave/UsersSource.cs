using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2.Classes
{
    public class UsersSource
    {
        public int Id;
        public string FirstName;
        public string Courriel;
        public string LastName;

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }

    }
}
