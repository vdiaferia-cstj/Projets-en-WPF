using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2
{
    public class User
    {
        public int Id;
        public string FirstName;
        public string LastName;
        public string Image;
        public string Password;
        public string Email;
        public string ImageDeFond;
        public List<int> Fr = new List<int>();
        
        

        public override string ToString()
        {
            return $"{FirstName}  {LastName}";

        }
    }

}
