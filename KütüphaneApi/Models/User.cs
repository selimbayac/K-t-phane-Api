using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class User : IdentityUser<int>
    {
        public bool IsAdmin { get; set; }
       public string Purchased { get; set; }
        // Kullanıcının satın aldığı kitapları göstermek için ilişki
      
    }
}
